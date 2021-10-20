﻿using FleetManagement.Domain.Models;
using FleetManager.EFCore.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace FleetManager.UnitTest.Features.DriverZone.Factory
{
    public class DriverZoneClientFactory /*: AuthenticatedFixture<DriverZoneClientFactory>*/
    {
        private readonly string _assemblyName;
        protected readonly List<Action<IServiceCollection>> Registrations = new List<Action<IServiceCollection>>();
        private readonly Mock<IGenericRepository<Driver>> _mockDriverRepository;

        public DriverZoneClientFactory()
        {
            _assemblyName = Assembly.GetAssembly(typeof(DriverZoneClientFactory)).GetName().Name;
            _mockDriverRepository = new Mock<IGenericRepository<Driver>>();
        }

        public DriverZoneClientFactory GetDriverDetails(int driverId)
        {
            var entityResponse = ReadResponseFromEmbeddedFile<Driver>(_assemblyName, $"GetDriverDetails");

            _mockDriverRepository.Setup(x =>
                x.GetBy(
                    It.IsAny<CancellationToken>(), 
                    It.Is<Expression<Func<Driver, bool>>>(x => x.Equals(driverId)), 
                    It.IsAny<Func<IQueryable<Driver>, IIncludableQueryable<Driver, object>>>()))
                .ReturnsAsync(entityResponse);

            return this;
        }

        public override Task<HttpClient> CreateClient()
        {
            Registrations.Add(services => { services.SwapTransient(provider => _mockDriverRepository.Object); });

            return base.CreateClient();
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

        public static class FileUtils
        {
            /// <summary>
            /// Get the content of the embedded resources as as MemoryStream
            /// </summary>
            /// <param name="assemblyName">Name of the assembly</param>
            /// <param name="resource">Filename of the resource. If the file is located in a subfolder, use dots instead of slashes</param>
            /// <returns></returns>
            public static MemoryStream LoadEmbeddedResourceAsStream(
                string assemblyName, string resource)
            {
                var ms = new MemoryStream();

                var assembly = Assembly.Load(new AssemblyName(assemblyName));

                var resources = assembly.GetManifestResourceNames();
                var embeddedResource = resources.SingleOrDefault(x => x.EndsWith(resource));

                if (embeddedResource == null)
                    throw new Exception($"Can't find embedded resource {resource} in {assemblyName}. Resources found: {string.Join(", ", resources.ToList())}");

                using (var stream = assembly.GetManifestResourceStream(embeddedResource))
                {
                    if (stream == null)
                        throw new InvalidOperationException();

                    stream.CopyTo(ms);
                }
                return ms;
            }

            /// <summary>
            /// Get the content of the embedded resources as string
            /// </summary>
            /// <param name="assemblyName">Name of the assembly</param>
            /// <param name="resource">Filename of the resource. If the file is located in a subfolder, use dots instead of slashes</param>
            /// <returns></returns>
            public static async Task<string> LoadEmbeddedResourceAsString(
                string assemblyName, string resource)
            {
                string output;

                var ms = LoadEmbeddedResourceAsStream(assemblyName, resource);
                ms.Position = 0;

                using (var reader = new StreamReader(ms))
                    output = await reader.ReadToEndAsync();


                return output;
            }
        }
    }
}
