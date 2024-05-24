using System;

namespace SurveyStore.Shared.Abstractions.Kernel.Types
{
    public class DocumentId : TypeId
    {
        public DocumentId(Guid id) : base(id)
        {
            
        }

        public static implicit operator DocumentId(Guid value) => new(value);
        public static implicit operator Guid(DocumentId id) => id.Value;

        public override string ToString()
            => this.Value.ToString();
    }
}