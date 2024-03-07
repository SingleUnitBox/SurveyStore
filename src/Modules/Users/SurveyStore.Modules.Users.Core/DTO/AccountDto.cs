using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.DTO
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Dictionary<string, IEnumerable<string>> Claims { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
