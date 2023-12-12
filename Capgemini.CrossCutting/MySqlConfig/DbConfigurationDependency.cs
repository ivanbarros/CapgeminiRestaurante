using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;


namespace Capgemini.CrossCutting.MySqlConfig
{
    public static class DbConfigurationDependency
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            
                services.AddScoped(c =>
                {
                    return new SqlConnection(configuration["sqlDb:connectionString"]);
                });
                services.AddScoped<IDbConnection>(c =>
                {
                    var dbConnection = c.GetService<SqlConnection>();
                    dbConnection.Open();

                    return dbConnection;
                });

                services.AddScoped(c =>
                {
                    return c.GetService<IDbConnection>().BeginTransaction();
                });
            }
        public static void AddMySqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(c =>
            {
                return new MySqlConnection(configuration["mysqlDb:connectionString"]);
            });
            services.AddScoped<IDbConnection>(c =>
            {
                var dbConnection = c.GetService<MySqlConnection>();
                dbConnection.Open();

                return dbConnection;
            });

            services.AddScoped(c =>
            {
                return c.GetService<IDbConnection>().BeginTransaction();
            });
        }
    }
}
