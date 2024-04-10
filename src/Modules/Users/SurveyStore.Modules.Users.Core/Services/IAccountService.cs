using SurveyStore.Modules.Users.Core.DTO;
using SurveyStore.Shared.Abstractions.Auth;
using System;
using System.Threading.Tasks;

namespace SurveyStore.Modules.Users.Core.Services
{
    public interface IAccountService
    {
        Task<AccountDto> GetAsync(Guid id);
        //Task<JsonWebToken> SignInAsync(SignInDto signInDto);
        //Task SignUpAsync(SignUpDto signUpDto);
    }
}
