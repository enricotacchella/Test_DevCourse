using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Mongo.Test
{
    public class ServiceProviderStartupBase : IDisposable
    {
        protected ITennisContext db;
        protected IServiceProvider Services { get; set; }

        public async Task DeleteDatabaseAsync()
        {
            db = Services?.GetService<IPriceHistoryContext>()!;
            await db.DeleteCollectionAsync();
        }

        public void Dispose()
        {
            DeleteDatabaseAsync().Wait();
        }
    }
}