using SurveyStore.Modules.SurveyJobs.Application.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class AddDocumentHandler : ICommandHandler<AddDocument>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ISurveyJobRepository _surveyJobRepository;

        public AddDocumentHandler(IDocumentRepository documentRepository,
            ISurveyJobRepository surveyJobRepository)
        {
            _documentRepository = documentRepository;
            _surveyJobRepository = surveyJobRepository;
        }

        public async Task HandleAsync(AddDocument command)
        {
            var document = await _documentRepository.GetByLinkAsync(command.Link);
            if (document is not null)
            {
                throw new DocumentAlreadyExistsException(command.Link);
            }

            document = Document.Create(command.Id, command.DocumentType.ToLowerInvariant(), command.Link);
            if (command.SurveyJobId.HasValue)
            {
                var surveyJob = await _surveyJobRepository.GetByIdAsync(command.SurveyJobId.Value);
                if (surveyJob is null)
                {
                    throw new SurveyJobNotFoundException(command.SurveyJobId.Value);
                }

                document.ChangeSurveyJob(surveyJob);
                surveyJob.AddDocument(document);

                await _surveyJobRepository.UpdateAsync(surveyJob);
            }

            await _documentRepository.AddAsync(document);
            
        }
    }
}
