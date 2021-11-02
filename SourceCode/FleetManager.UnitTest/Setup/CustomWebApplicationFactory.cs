﻿using FleetManagement.Framework.Constants;
using FleetManager.EFCore.Infrastructure.DbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Respawn;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data.Common;

namespace FleetManager.UnitTest.Integration.Setup
{
    // Based on https://adamstorr.azurewebsites.net/blog/integration-testing-with-aspnetcore-3-1-swapping-dependency-with-moq
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private DbConnection _connection;
        private readonly Checkpoint _checkpoint;

        protected readonly List<Action<IServiceCollection>> Registrations = new List<Action<IServiceCollection>>();

        public new virtual async Task<HttpClient> CreateClient()
        {
            var client = base.CreateClient();
            await ResetCheckpoint();
            return client;
        }

        protected CustomWebApplicationFactory(Action<IServiceCollection> registrations = null)
        {
            if (registrations == null)
            {
                Registrations.Add(collection => { });
            }
            else
            {
                Registrations.Add(registrations);
            }

            _checkpoint = new Checkpoint
            {
                SchemasToInclude = new[]
                {
                    "dbo"
                },
                TablesToIgnore = new[] { "__EFMigrationsHistory" },
                DbAdapter = DbAdapter.MySql
            };
        }

        protected Task ResetCheckpoint()
        {
            return ResetCheckpoint(Services);
        }

        protected virtual void ConfigureWebHostTestServices(IServiceCollection services)
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, b) =>
            {
                // Makes sure the tests use the appsettings within the current project
                b.SetBasePath(Directory.GetCurrentDirectory());
                b.AddJsonFile("testsettings.json");
                b.AddEnvironmentVariables();
                context.HostingEnvironment.EnvironmentName = Constants.Env.IntegrationTesting;
            });

            builder.ConfigureTestServices(services =>
            {
                ConfigureWebHostTestServices(services);

                Registrations.ForEach(x => x.Invoke(services));
            });
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder()
                .UseSerilog((
                    context,
                    configuration) =>
                {
                    configuration.MinimumLevel.Verbose();
                    configuration.WriteTo.Debug();
                    configuration.WriteTo.File("testlog.txt");
                });
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = base.CreateHost(builder);

            EnsureCreated(host.Services);

            return host;
        }

        private async Task ResetCheckpoint(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            if (_connection == null)
            {
                IConfigurationRoot configuration2 = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("testsettings.json")
                .Build();
                var connectionString = configuration.GetConnectionString("DatabaseContext");
                var builder = new DbContextOptionsBuilder<DatabaseContext>();
                builder.UseSqlServer(connectionString);
                var context = new DatabaseContext(builder.Options);
                _connection = context.Database.GetDbConnection();
                //_connection = new MySqlConnection(configuration.GetConnectionString(nameof(DatabaseContext)));
                _connection.Open();
            }

            await _checkpoint.Reset(_connection);
        }

        private static void EnsureCreated(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>())
                {
                    appContext.Database.EnsureCreated();
                }
            }
        }
    }
}