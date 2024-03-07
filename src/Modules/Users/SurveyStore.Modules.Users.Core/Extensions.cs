using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SurveyStore.Modules.Users.Core.DAL;
using SurveyStore.Modules.Users.Core.DAL.Repositories;
using SurveyStore.Modules.Users.Core.Entities;
using SurveyStore.Modules.Users.Core.Repositories;
using SurveyStore.Modules.Users.Core.Services;
using SurveyStore.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SurveyStore.Modules.Users.Api")]
namespace SurveyStore.Modules.Users.Core
{
    public static class Extensions
    {
        internal static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserRepository, PostgresUserRepository>();
            services.AddPostgres<UsersDbContext>();

            return services;
        }
    }
}
