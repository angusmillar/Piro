using Microsoft.EntityFrameworkCore;
using Piro.FhirServer.Application.Domain.Models;

namespace Piro.FhirServer.Application.Repository;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options) { }
    
    public virtual DbSet<ResourceType> ResourceType { get; set; } = null!;
    public virtual DbSet<FhirResource> FhirResource { get; set; } = null!;
    public virtual DbSet<IndexResourceReference> IndexResourceReference { get; set; } = null!;
    public virtual DbSet<IndexString> IndexString { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //-- ResourceType ------------------------------------------------------------------------------------
        modelBuilder.Entity<ResourceType>().HasKey(x => x.Id);
        modelBuilder.Entity<ResourceType>().HasIndex(x => x.Name);
        
        //-- Resource ---------------------------------------------------------------------------------------------
        modelBuilder.Entity<FhirResource>().HasKey(x => x.Id);
        modelBuilder.Entity<FhirResource>().HasIndex(x => x.FhirId);
        
        //A resource has only one ResourceType, and ResourceTypes are not deleted when a Resource is deleted
        modelBuilder.Entity<FhirResource>()
            .HasOne<ResourceType>(x => x.ResourceType)
            .WithMany()
            .HasForeignKey(x => x.ResourceTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        //A resource has many ResourceReferenceIndexes each with a key back to the Resource  
        modelBuilder.Entity<FhirResource>()
            .HasMany<IndexResourceReference>()
            .WithOne(x => x.SourceFhirResource)
            .HasForeignKey(x => x.SourceResourceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FhirResource>()
            .HasMany<IndexString>()
            .WithOne(x => x.SourceFhirResource)
            .HasForeignKey(x => x.SourceResourceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        
        //-- IndexResourceReference ------------------------------------------------------------------------------------
        modelBuilder.Entity<IndexResourceReference>().HasKey(x => x.Id);
        
        modelBuilder.Entity<IndexResourceReference>().HasIndex(x => x.TargetFhirId);

        modelBuilder.Entity<IndexResourceReference>().Property(x => x.TargetResourceId).IsRequired(false);
        
        modelBuilder.Entity<IndexResourceReference>()
            .HasOne<FhirResource>(x => x.TargetResource)
            .WithMany(x => x.BackResourceReferenceIndexList)
            .HasForeignKey(x => x.TargetResourceId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        
        //-- IndexString ------------------------------------------------------------------------------------
        modelBuilder.Entity<IndexString>().HasKey(x => x.Id);
        
        modelBuilder.Entity<IndexString>().HasIndex(x => x.Value);
        
        
        
        base.OnModelCreating(modelBuilder);
    }
    
}