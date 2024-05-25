using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using SurveyStore.Shared.Abstractions.Types;
using System;
using System.Linq;
using System.Reflection;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class Document
    {
        public DocumentId Id { get; private set; }
        public DocumentTypes DocumentType { get; private set; }
        public string Link { get; private set; }

        private Document(Guid id)
        {
            Id = id;
        }

        public void ChangeDocumentType(string documentType)
        {
            var documentTypes = typeof(DocumentTypes)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly)
                .Select(field => field.GetValue(null).ToString());

            if (!documentTypes.Contains(documentType))
            {
                throw new InvalidDocumentTypeException(documentType);
            }

            DocumentType = documentType;
        }

        public static Document Create(Guid id, string documentType, string link)
        {
            var document = new Document(id);

            return document;
        }
    }
}
