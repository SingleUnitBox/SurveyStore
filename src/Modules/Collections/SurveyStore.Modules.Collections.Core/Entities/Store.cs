using System;
using System.ComponentModel.DataAnnotations;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
