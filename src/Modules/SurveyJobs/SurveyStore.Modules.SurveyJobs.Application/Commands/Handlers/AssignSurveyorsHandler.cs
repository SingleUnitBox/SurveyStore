using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.DomainServices;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Policies;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class AssignSurveyorsHandler : ICommandHandler<AssignSurveyors>
    {
        private readonly ISurveyJobRepository _surveyJobRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        private readonly ISurveyJobAssigningPolicy _policy;
        private readonly ISurveyJobsDomainService _assignSurveyorService;

        public AssignSurveyorsHandler(ISurveyJobRepository surveyJobRepository,
            ISurveyorRepository surveyorRepository,
            ISurveyJobAssigningPolicy policy,
            ISurveyJobsDomainService assignSurveyorService)
        {
            _surveyJobRepository = surveyJobRepository;
            _surveyorRepository = surveyorRepository;
            _policy = policy;
            _assignSurveyorService = assignSurveyorService;
        }
        public async Task HandleAsync(AssignSurveyors command)
        {
            var surveyJob = await _surveyJobRepository.GetByIdAsync(command.SurveyJobId);
            if (surveyJob is null)
            {
                throw new SurveyJobNotFoundException(command.SurveyJobId);
            }

            var surveyors = new HashSet<Surveyor>();
            foreach (var email in command.SurveyorEmails)
            {
                var surveyor = await _surveyorRepository.GetByEmailAsync(email);
                if (surveyor is null)
                {
                    throw new SurveyorNotFoundException(email);
                }

                surveyors.Add(surveyor);
            }

            if (!_policy.CanJobBeAssign(surveyJob, surveyors))
            {
                throw new SurveyJobBudgetExceededException(command.SurveyJobId);
            }

            foreach (var surveyor in surveyors)
            {
                var openSurveyJobs = await _surveyJobRepository.BrowseForSurveyorAsync(surveyor.Id);
                _assignSurveyorService.AssignSurveyor(surveyJob, openSurveyJobs, surveyor);
            }
            
            await _surveyJobRepository.UpdateAsync(surveyJob);

            //surveyor.AddSurveyJob(surveyJob);
            //await _surveyorRepository.UpdateAsync(surveyor);
        }
    }
}