using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class AddSurveyJobHandler : ICommandHandler<AddSurveyJob>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;
        private readonly IDocumentRepository _documentRepository;

        public AddSurveyJobHandler(ISurveyJobRepository surveyJobRepository,
            IDocumentRepository documentRepository)
        {
            _surveyJobRepository = surveyJobRepository;
            _documentRepository = documentRepository;
        }

        public async Task HandleAsync(AddSurveyJob command)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(command.Id);
            if (surveyJob is not null)
            {
                throw new SurveyJobAlreadyExistsException(command.Id);
            }

            surveyJob = SurveyJob.Create(command.Id, command.BriefIssued, command.DueDate, command.SurveyType);
            if (command.DocumentLinks is not null)
            {
                await AddDocuments(surveyJob, command.DocumentLinks);              
            }

            await _surveyJobRepository.AddAsync(surveyJob);
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
    }
}