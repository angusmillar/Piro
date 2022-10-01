using Microsoft.EntityFrameworkCore;
using Piro.FhirServer.Application.Domain.Repositories;
using Piro.FhirServer.Application.Repository.Repositories;
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
    
    //Database
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<AppContext>(options =>
        options.UseNpgsql(connectionString));
    
    builder.Services.AddScoped<FhirResourceRepository>(); 
    builder.Services.AddSingleton<IGetResourceByFhirId>(x => x.GetRequiredService<FhirResourceRepository>()); 
    builder.Services.AddSingleton<IAddFhirResource>(x => x.GetRequiredService<FhirResourceRepository>());
    
    // Add services to the container.
    builder.Services.AddControllersWithViews();
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
