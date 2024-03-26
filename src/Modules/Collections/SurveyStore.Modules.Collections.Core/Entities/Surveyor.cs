using System;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Core.Entities
{
    public class Surveyor
    {
        public SurveyorId Id { get; set; }
        public string FullName { get; set; }

        public static Surveyor Create(Guid id, string firstName, string surname)
            => new Surveyor()
            {
                Id = id,
                FullName = firstName + " " + surname,
            };
    }
}
