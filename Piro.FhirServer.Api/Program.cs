using System.Buffers;
using Microsoft.EntityFrameworkCore;
using Piro.FhirServer.Api;
using Piro.FhirServer.Api.ContentFormatters;
using Piro.FhirServer.Application.Decorators;
using Piro.FhirServer.Application.Domain.Repositories;
using Piro.FhirServer.Application.Repository.Repositories;
using Piro.FhirServer.Application.Services;
using Serilog;
using AppContext = Piro.FhirServer.Application.Repository.AppContext;

//Test Git

Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .WriteTo.File(path: @$"./application-start-.log", rollingInterval: RollingInterval.Day)
  .CreateBootstrapLogger();

Log.Information($"Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));


    builder.Services.AddScoped<ResourceStoreService>();
    builder.Services.AddScoped<IResourceStoreService>(sp =>
    {
        var resourceStoreService = sp.GetRequiredService<ResourceStoreService>();
        
        var resourceStoreLoggingLogger = sp.GetRequiredService<ILogger<ResourceStoreLoggingDecorator>>();
        IResourceStoreService loggingDecorator = new ResourceStoreLoggingDecorator(resourceStoreLoggingLogger, resourceStoreService);
        
        var resourceStoreTimerLogger = sp.GetRequiredService<ILogger<ResourceStoreTimerDecorator>>();
        IResourceStoreService timerDecorator = new ResourceStoreTimerDecorator(resourceStoreTimerLogger, loggingDecorator);
    
        return timerDecorator;
    });
    
    
    //Database
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<AppContext>(options =>
        options.UseNpgsql(connectionString));
    
    builder.Services.AddScoped<ResourceStoreRepository>(); 
    builder.Services.AddScoped<IResourceStoreGetByFhirId>(x => x.GetRequiredService<ResourceStoreRepository>()); 
    builder.Services.AddScoped<IResourceStoreAdd>(x => x.GetRequiredService<ResourceStoreRepository>());
    builder.Services.AddScoped<IResourceStoreSearch >(x => x.GetRequiredService<ResourceStoreRepository>());
    
    
    
    builder.Services.AddScoped<ResourceTypeRepository>();
    builder.Services.AddScoped<IResourceTypeAdd>(x => x.GetRequiredService<ResourceTypeRepository>());
    builder.Services.AddScoped<IResourceTypeGetByName>(x => x.GetRequiredService<ResourceTypeRepository>());
    
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    
    builder.Services.AddMvcCore(config =>
    {        
        config.InputFormatters.Clear();
        //config.InputFormatters.Add(new XmlFhirInputFormatter());
        config.InputFormatters.Add(new JsonFhirInputFormatter());
    
        config.OutputFormatters.Clear();
        //config.OutputFormatters.Add(new XmlFhirOutputFormatter());
        config.OutputFormatters.Add(new JsonFhirOutputFormatter());
   

        // And include our custom content negotiator filter to handle the _format parameter
        // (from the FHIR spec:  http://hl7.org/fhir/http.html#mime-type )
        // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters
        config.Filters.Add(new FhirFormatParameterFilter());
        config.Filters.Add(new FhirVersionParameterFilter());
        
    });
    
    builder.Services.AddRazorPages();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseAuthorization();
    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information($"Shut down complete");
    Log.CloseAndFlush();
}
