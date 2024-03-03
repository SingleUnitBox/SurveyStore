using SurveyStore.Modules.Stores.Core.DAL;
using SurveyStore.Shared.Tests;
using System;

namespace SurveyStore.Modules.Stores.Tests.Integration.Common
{
    public class TestStoresDbContext : IDisposable
    {
        public StoresDbContext DbContext { get; }
        public TestStoresDbContext()
        {
            DbContext = new StoresDbContext(DbHelper.GetOptions<StoresDbContext>());
        }
        public void Dispose()
        {
            DbContext?.Database.EnsureDeleted();
            DbContext?.Dispose();
        }
    }
}
