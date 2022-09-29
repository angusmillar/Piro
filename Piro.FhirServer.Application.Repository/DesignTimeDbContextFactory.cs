using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Piro.FhirServer.Application.Repository;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public DesignTimeDbContextFactory()
    {
        //Use below to debug this class while running Migration commands.
        //Debugger.Launch();
    }
    
    public AppDbContext CreateDbContext(string[] args)
    {
        // Get environment
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
        
        // Build config
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();
        
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseNpgsql(connectionString);
        builder.EnableSensitiveDataLogging();
        return new AppDbContext(builder.Options);
    }
}