using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Capgemini.Infra.Migrations.MigrationsConfig
{
    public static class MigratorServices
    {
        public static void CreateMysqlService(string connectionString)
        {
            var migrationsAssembly = GetMigrationClass.Get();

            if (migrationsAssembly.Any())
            {
                var serviceProvider = new ServiceCollection().AddFluentMigratorCore()
                    .ConfigureRunner(
                        builder =>
                            builder
                           .AddMySql4()
                           .WithGlobalConnectionString(connectionString)
                           .ScanIn(migrationsAssembly).For.All())
                        .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                UpdateDatabase(scope.ServiceProvider);
            }
        }
        public static void CreateService(string connectionString)
        {
            var migrationsAssembly = GetMigrationClass.Get();

            if (migrationsAssembly.Any())
            {
                var serviceProvider = new ServiceCollection().AddFluentMigratorCore()
                    .ConfigureRunner(
                        builder =>
                            builder
                           .AddSqlServer()
                           .WithGlobalConnectionString(connectionString)
                           .ScanIn(migrationsAssembly).For.All())
                        .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}
