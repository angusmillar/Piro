// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;
using Piro.FhirServer.Application.Repository.Repositories;
using Piro.FhirServer.Application.Services;
using AppContext = Piro.FhirServer.Application.Repository.AppContext;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
                
            .AddDbContext<AppContext>(options => options.UseNpgsql("Host=localhost; Database=piro; Username=postgres; Password=su"))
            
            .AddScoped<IResourceStoreService, ResourceStoreService>()
            .AddScoped<IResourceTypeService, ResourceTypeService>()
            
            .AddScoped<ResourceStoreRepository>()
            .AddScoped<IResourceStoreGetByFhirId>(x => x.GetRequiredService<ResourceStoreRepository>())
            .AddScoped<IResourceStoreAdd>(x => x.GetRequiredService<ResourceStoreRepository>())
            
            .AddScoped<ResourceTypeRepository>()
            .AddScoped<IResourceTypeAdd>(x => x.GetRequiredService<ResourceTypeRepository>())
            .AddScoped<IResourceTypeGetByName>(x => x.GetRequiredService<ResourceTypeRepository>())
            
        )
    .Build();


Run(host.Services);

await host.RunAsync();

static void Run(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    Console.WriteLine("...Started Scope");

    var patientResourceType = new ResourceType(id: null, name: "Patient");
    var organizationResourceType = new ResourceType(id: null, name: "Organization");
    
    IResourceTypeService resourceTypeService = provider.GetRequiredService<IResourceTypeService>();
    try
    {
        ResourceType? dbPatientResourceType = resourceTypeService.GetByName(patientResourceType.Name);
        if (dbPatientResourceType is not null)
        {
            patientResourceType = dbPatientResourceType;
        }
        else
        {
            resourceTypeService.Add(patientResourceType);
        }
        
        ResourceType? dbOrganizationResourceType = resourceTypeService.GetByName(organizationResourceType.Name);
        if (dbOrganizationResourceType is not null)
        {
            organizationResourceType = dbOrganizationResourceType;
        }
        else
        {
            resourceTypeService.Add(organizationResourceType);    
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
    
    var fhirResource = new ResourceStore(
        id: null,
        fhirId: "Test-1",
        resourceTypeId: patientResourceType.Id!.Value,
        resourceType: patientResourceType,
        referenceIndexList: new List<IndexReference>(),
        stringIndexList: new List<IndexString>(),
        backResourceReferenceIndexList: new List<IndexReference>());
    
    var indexString = new IndexString(id: null, value: "Angus", resourceStoreId: null,
        resourceStore: fhirResource,
        searchParameterId: 100);
    
    var indexResourceReference = new IndexReference(
        id: null,
        fhirId: "Org-1",
        versionId: null,
        resourceTypeId: organizationResourceType.Id!.Value,
        resourceType: organizationResourceType,
        targetResourceStoreId: null,
        targetResourceStore: null,
        resourceStoreId: null,
        resourceStore: fhirResource,
        searchParameterId: 200);
    
    fhirResource.StringIndexList.Add(indexString);
    fhirResource.ReferenceIndexList.Add(indexResourceReference);
    
    IResourceStoreService resourceStoreService = provider.GetRequiredService<IResourceStoreService>();
    try
    {
        resourceStoreService.Add(fhirResource);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
    
    
    Console.WriteLine("...Ended Scope");


}

