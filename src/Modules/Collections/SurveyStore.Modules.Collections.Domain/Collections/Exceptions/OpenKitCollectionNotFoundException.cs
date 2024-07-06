using SurveyStore.Shared.Abstractions.Exceptions;
using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Collections.Domain.Collections.Exceptions
{
    public class OpenKitCollectionNotFoundException : SurveyStoreException
    {
        public Guid KitId { get; }
        public OpenKitCollectionNotFoundException(Guid kitId)
            : base($"Open kit collection with id '{kitId}' was not found.")
        {
            KitId = kitId;
        }
    }
}
