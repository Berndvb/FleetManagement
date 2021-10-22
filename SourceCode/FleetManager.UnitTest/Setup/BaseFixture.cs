using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetManager.UnitTest.Integration.Resources;
using FleetManagement.WriteAPI;
using Microsoft.Extensions.DependencyInjection;
using FleetManager.EFCore.Infrastructure.DbContext;
using System.Net.Http;

namespace FleetManager.UnitTest.Integration.Setup
{
    public class BaseFixture<T> : CustomWebApplicationFactory<Startup>
        where T : class
    {
        private readonly List<object> _toBeAddedObjects;

        protected BaseFixture()
        {
            _toBeAddedObjects = new List<object>();
        }

        public override async Task<HttpClient> CreateClient()
        {
            var httpClient = await base.CreateClient();

            using (var scope = Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                await dbContext.AddRangeAsync(_toBeAddedObjects);
                await dbContext.SaveChangesAsync();
                _toBeAddedObjects.Clear();
            }

            return httpClient;
        }

        public TK ReadResponseFromEmbeddedFile<TK>(string assemblyName, string fileName)
        {
            var stream = FileUtils.LoadEmbeddedResourceAsStream(assemblyName, fileName);
            var serializer = new JsonSerializer();
            stream.Position = 0;
            using (var sr = new StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<TK>(jsonTextReader);
                }
            }
        }
    }
}
