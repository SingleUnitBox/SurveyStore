using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Surveyors.Core.Entities
{
    public class Surveyor
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        public static Surveyor Create(Guid id, string email)
            => new()
            {
                Id = id,
                Email = email,
            };
    }
}
