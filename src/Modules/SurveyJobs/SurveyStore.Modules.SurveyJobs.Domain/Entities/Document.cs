using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Linq;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class Document
    {
        public DocumentId Id { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public string Link { get; private set; }

        private Document(Guid id)
        {
            Id = id;
        }

        public void ChangeDocumentType(string documentType)
        {
            var docType = DocumentType.Create(documentType);
            DocumentType = docType;
        }
         
        public static Document Create(Guid id, string documentType, string link)
        {
            var document = new Document(id);
            document.ChangeDocumentType(documentType);

            return document;
        }
    }
}
