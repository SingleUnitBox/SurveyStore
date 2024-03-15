using SurveyStore.Shared.Abstractions.Kernel.Types;
using System.ComponentModel.DataAnnotations;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class Store
    {
        public StoreId Id { get; set; }
        [MaxLength(20)] 
        public string Name { get; set; }
    }
}
