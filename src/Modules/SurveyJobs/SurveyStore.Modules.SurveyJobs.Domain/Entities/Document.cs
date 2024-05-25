using SurveyStore.Modules.SurveyJobs.Domain.Exceptions;
using SurveyStore.Modules.SurveyJobs.Domain.ValueObjects;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;

namespace SurveyStore.Modules.SurveyJobs.Domain.Entities
{
    public class Document
    {
        public DocumentId Id { get; private set; }
        public DocumentType DocumentType { get; private set; }
        public string Link { get; private set; }
        public SurveyJob SurveyJob { get; private set; }

        private Document(Guid id)
        {
            Id = id;
        }

        public void ChangeDocumentType(string documentType)
        {
            var docType = DocumentType.Create(documentType);
            DocumentType = docType;
        }

        public void ChangeLink(string link)
        {
            if (!link.StartsWith("http://"))
            {
                throw new InvalidLinkException(link);
            }

            Link = link;
        }

        public void ChangeSurveyJob(SurveyJob surveyJob)
        {
            SurveyJob = surveyJob;
        }
         
        public static Document Create(Guid id, string documentType, string link)
        {
            var document = new Document(id);
            document.ChangeDocumentType(documentType);
            document.ChangeLink(link);

            return document;
        }
    }
}
