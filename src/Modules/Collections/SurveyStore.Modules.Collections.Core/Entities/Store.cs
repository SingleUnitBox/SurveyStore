using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }

        public static Store Create(Guid id, string name)
            => new Store
            {
                Id = id,
                Name = name,
            };
    }
}
