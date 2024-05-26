using SurveyStore.Modules.SurveyJobs.Domain.Entities;
using SurveyStore.Modules.SurveyJobs.Domain.Repositories;
using SurveyStore.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace SurveyStore.Modules.SurveyJobs.Application.Commands.Handlers
{
    public class AddDocumentHandler : ICommandHandler<AddDocument>
    {
        private readonly IDocumentRepository _documentRepository;

        public AddDocumentHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task HandleAsync(AddDocument command)
        {
            var document = Document.Create(command.Id, command.DocumentType.ToLowerInvariant(), command.Link);

            await _documentRepository.AddAsync(document);    
        }
    }
}
