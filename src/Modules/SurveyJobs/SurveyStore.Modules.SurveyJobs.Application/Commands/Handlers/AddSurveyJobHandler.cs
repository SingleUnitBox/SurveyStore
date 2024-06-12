using SurveyStore.Modules.SurveyJobs.Application.Events;
using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.DomainServices;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Policies;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using SurveyStore.Shared.Abstractions.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class AddSurveyJobHandler : ICommandHandler<AddSurveyJob>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly ISurveyJobsDomainService _surveyJobsDomainService;
        private readonly ISurveyJobAssigningPolicy _surveyJobAssigningPolicy;
        private readonly IMessageBroker _messageBroker;

        public AddSurveyJobHandler(ISurveyJobRepository surveyJobRepository,
            IDocumentRepository documentRepository,
            ISurveyorRepository surveyorRepository,
            ISurveyJobsDomainService surveyJobsDomainService,
            ISurveyJobAssigningPolicy surveyJobAssigningPolicy)
        {
            _surveyJobRepository = surveyJobRepository;
            _documentRepository = documentRepository;
            _surveyorRepository = surveyorRepository;
            _surveyJobsDomainService = surveyJobsDomainService;
            _surveyJobAssigningPolicy = surveyJobAssigningPolicy;
        }

        public async Task HandleAsync(AddSurveyJob command)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(command.Id);
            if (surveyJob is not null)
            {
                throw new SurveyJobAlreadyExistsException(command.Id);
            }

            surveyJob = SurveyJob.Create(command.Id, command.Name, command.BriefIssued,
                command.DueDate, command.SurveyType, command.Budget, command.CostToDeliver);
            if (command.DocumentLinks is not null)
            {
                await AddDocuments(surveyJob, command.DocumentLinks);              
            }

            if (command.SurveyorEmails is not null)
            {
                await AssignSurveyors(surveyJob, command.SurveyorEmails);
            }

            await _surveyJobRepository.AddAsync(surveyJob);
            await _messageBroker.PublishAsync(new SurveyJobCreated(surveyJob.Id));
        }

        private async Task AddDocuments(SurveyJob surveyJob, IEnumerable<string> documentLinks)
        {
            foreach (var documentLink in documentLinks)
            {
                if (documentLink is not null)
                {
                    var document = await _documentRepository.GetByLinkAsync(documentLink);
                    if (document is null)
                    {
                        throw new DocumentNotFoundException(documentLink);
                    }

                    surveyJob.AddDocument(document);
                }
            }
        }

        private async Task AssignSurveyors(SurveyJob surveyJob, IEnumerable<string> surveyorEmails)
        {
            var surveyors = new HashSet<Surveyor>();
            foreach (var email in surveyorEmails)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var surveyor = await _surveyorRepository.GetByEmailAsync(email);
                    if (surveyor is null)
                    {
                        throw new SurveyorNotFoundException(email);
                    }

                    surveyors.Add(surveyor);
                }
            }

            if (!_surveyJobAssigningPolicy.CanJobBeAssigned(surveyJob, surveyors))
            {
                throw new SurveyJobBudgetExceededException(surveyJob.Id);
            }

            foreach (var surveyor in surveyors)
            {
                var openSurveyJobs = (await _surveyJobRepository.BrowseForSurveyorAsync(surveyor.Id))
                    .Where(sj => sj.IssuedAt is null);
                _surveyJobsDomainService.AssignSurveyor(surveyJob, openSurveyJobs, surveyor);
            }
        }
    }
}