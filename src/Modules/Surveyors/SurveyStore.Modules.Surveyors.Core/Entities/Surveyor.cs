using System;
using System.Collections.Generic;

namespace SurveyStore.Modules.Surveyors.Domain.Entities
{
    public class Surveyor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }
        public IEnumerable<SurveyEquipment> Equipment { get; set; }
        private List<SurveyEquipment> _equipment = new();
    }
}
