using Microsoft.EntityFrameworkCore;
using Piro.FhirServer.Application.Domain.Model;

namespace Piro.FhirServer.Application.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
    public virtual DbSet<ResourceStore> ResourceStore { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResourceStore>().HasKey(x => x.Id);
        // modelBuilder.Entity<ResourceStore>().HasIndex(x => new { x.DiagnosticProviderCode, x.OrderRepositoryCode }).IsUnique();

        modelBuilder.Entity<ResourceStore>().Property(x => x.Type);
        
        base.OnModelCreating(modelBuilder);
    }
    
}