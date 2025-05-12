using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ZooSystem.Infrastructure.DataAcess;

namespace ZooSystem.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static void Migrate(string? connectionString, IServiceProvider services)
    {
        if(!string.IsNullOrWhiteSpace(connectionString))
        {
            EnsureDatabaseCreated(connectionString);
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ZooSystemDbContext>();
            dbContext.Database.Migrate();
        }           
    }

    private static void EnsureDatabaseCreated(string connectionString)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        var database = connectionStringBuilder.InitialCatalog;

        connectionStringBuilder.Remove("Initial Catalog");

        using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

        var parameters = new DynamicParameters();
        parameters.Add("name", database);

        var records = dbConnection.Query("SELECT name FROM sys.databases WHERE name = @name", parameters);

        if (!records.Any())
        {
            dbConnection.Execute($"CREATE DATABASE [{database}]");
        }
    }
}
