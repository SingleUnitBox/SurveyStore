using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Equipment.Core.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
