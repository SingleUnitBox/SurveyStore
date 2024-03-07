using System.ComponentModel.DataAnnotations;

namespace SurveyStore.Modules.Users.Core.DTO
{
    public class SignInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
