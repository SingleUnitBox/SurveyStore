using System;
using SurveyStore.Modules.Users.Core.DAL;
using SurveyStore.Shared.Tests;

namespace SurveyStore.Modules.Users.Tests.Integration.Commons
{
    public class TestUsersDbContext : IDisposable
    {
        internal UsersDbContext DbContext { get; }

        public TestUsersDbContext()
        {
            DbContext = new UsersDbContext(DbHelper.GetOptions<UsersDbContext>());
        }

        public void Dispose()
        {
            DbContext?.Database.EnsureDeleted();
            DbContext?.Dispose();
        }
    }
}
