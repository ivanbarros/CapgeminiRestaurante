using FluentMigrator;
using System;
using System.Linq;
using System.Reflection;

namespace Capgemini.Infra.Migrations.MigrationsConfig
{
    public static class GetMigrationClass
    {
        public static Assembly[] Get()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x =>
                    typeof(Migration).IsAssignableFrom(x) &&
                    x != typeof(Migration) &&
                    x.GetCustomAttributes(typeof(MigrationAttribute), true).Length > 0)
                .Select(x => x.Assembly).ToArray();
        }
    }
}
