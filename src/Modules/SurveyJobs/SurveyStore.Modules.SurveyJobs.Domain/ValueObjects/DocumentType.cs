using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using SurveyStore.Shared.Abstractions.Types;
using System.Linq;
using System.Xml.Linq;

namespace SurveyStore.Modules.SurveyJobs.Domain.ValueObjects
{
    public class DocumentType
    {
        public string Name { get; set; }
        private DocumentType()
        {

        }

        public void ChangeDocumentType(string documentType)
        {
            var documentTypes = DocumentTypes.GetDocumentTypes();
            if (!documentTypes.Contains(documentType))
            {
                throw new InvalidDocumentTypeException(documentType);
            }

            Name = documentType;
        }

        public static DocumentType Create(string documentType)
        {
            var document = new DocumentType();
            document.ChangeDocumentType(documentType);

            return document;
        }
    }
}
