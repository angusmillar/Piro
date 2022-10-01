// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Domain.Repositories;
using Piro.FhirServer.Application.Repository.Repositories;
using Piro.FhirServer.Application.Runner;
using Piro.FhirServer.Application.Services;
using AppContext = Piro.FhirServer.Application.Repository.AppContext;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
                
            .AddDbContext<AppContext>(options => options.UseNpgsql("Host=localhost; Database=piro; Username=postgres; Password=su"))
            
            .AddScoped<LoadTestOne>()
            .AddScoped<IResourceStoreService, ResourceStoreService>()
            .AddScoped<IResourceTypeService, ResourceTypeService>()
            
            .AddScoped<ResourceStoreRepository>()
            .AddScoped<IResourceStoreGetByFhirId>(x => x.GetRequiredService<ResourceStoreRepository>())
            .AddScoped<IResourceStoreAdd>(x => x.GetRequiredService<ResourceStoreRepository>())
            .AddScoped<IResourceStoreSearch>(x => x.GetRequiredService<ResourceStoreRepository>())
            
            .AddScoped<ResourceTypeRepository>()
            .AddScoped<IResourceTypeAdd>(x => x.GetRequiredService<ResourceTypeRepository>())
            .AddScoped<IResourceTypeGetByName>(x => x.GetRequiredService<ResourceTypeRepository>())
            
        )
    .Build();


//await Load(host.Services);
Search(host.Services);

await host.RunAsync();

static void Search(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    Console.WriteLine("...Started Scope");
    
    LoadTestOne loadTestOne = provider.GetRequiredService<LoadTestOne>();

    loadTestOne.Search();

    Console.WriteLine("...Ended Scope");
    
}

static async Task Load(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    Console.WriteLine("...Started Scope");
    
    LoadTestOne loadTestOne = provider.GetRequiredService<LoadTestOne>();

    await loadTestOne.Load();

    Console.WriteLine("...Ended Scope");
}

