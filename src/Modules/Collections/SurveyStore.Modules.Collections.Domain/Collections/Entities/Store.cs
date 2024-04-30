using SurveyStore.Shared.Abstractions.Kernel.Types;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class Store
    {
        public StoreId Id { get; private set; }
        [MaxLength(20)]
        public string Name { get; private set; }

        public Store(StoreId id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Store Create(Guid id, string name)
            => new(id, name);
    }
}
