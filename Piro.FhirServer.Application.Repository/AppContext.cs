using Microsoft.EntityFrameworkCore;
using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Repository;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options) { }
    
    public virtual DbSet<ResourceType> ResourceType { get; set; } = null!;
    public virtual DbSet<ResourceStore> ResourceStore { get; set; } = null!;
    public virtual DbSet<IndexReference> IndexReference { get; set; } = null!;
    public virtual DbSet<IndexString> IndexString { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //-- ResourceType ------------------------------------------------------------------------------------
        modelBuilder.Entity<ResourceType>().HasKey(x => x.Id);
        modelBuilder.Entity<ResourceType>().HasIndex(x => x.Name);
        
        //-- Resource ---------------------------------------------------------------------------------------------
        modelBuilder.Entity<ResourceStore>().HasKey(x => x.Id);
        modelBuilder.Entity<ResourceStore>().HasIndex(x => x.FhirId);
        
        //A resource has only one ResourceType, and ResourceTypes are not deleted when a Resource is deleted
        modelBuilder.Entity<ResourceStore>()
            .HasOne<ResourceType>(x => x.ResourceType)
            .WithMany()
            .HasForeignKey(x => x.ResourceTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        
        //-- IndexResourceReference ------------------------------------------------------------------------------------
        modelBuilder.Entity<IndexReference>().HasKey(x => x.Id);
        
        modelBuilder.Entity<IndexReference>().HasIndex(x => x.FhirId);

        modelBuilder.Entity<IndexReference>().Property(x => x.TargetResourceStoreId).IsRequired(false);
        modelBuilder.Entity<IndexReference>().Property(x => x.ResourceStoreId).IsRequired();
        
        modelBuilder.Entity<IndexReference>()
            .HasOne<ResourceStore>(x => x.TargetResourceStore)
            .WithMany(x => x.BackResourceReferenceIndexList)
            .HasForeignKey(x => x.TargetResourceStoreId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<IndexReference>()
            .HasOne<ResourceType>(x => x.ResourceType)
            .WithMany()
            .HasForeignKey(x => x.ResourceTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        
        //-- IndexString ------------------------------------------------------------------------------------
        modelBuilder.Entity<IndexString>().HasKey(x => x.Id);
        
        modelBuilder.Entity<IndexString>().HasIndex(x => x.Value);

        modelBuilder.Entity<IndexString>().Property(x => x.ResourceStoreId).IsRequired();
        
        
        
        base.OnModelCreating(modelBuilder);
    }
    
}