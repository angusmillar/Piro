using Microsoft.AspNetCore.Mvc;
using Piro.FhirServer.Application.Domain.Models;
using Piro.FhirServer.Application.Services;
using Piro.FhirServer.UI.Domain;

namespace Piro.FhirServer.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IResourceStoreService _resourceStoreService;
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IResourceStoreService resourceStoreService)
    {
      _logger = logger;
      _resourceStoreService = resourceStoreService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {

      await _resourceStoreService.Add(new ResourceStore(null, "5", 1, new ResourceType(null, "Patient"),
        new List<IndexReference>(), new List<IndexString>(), new List<IndexReference>()));
      
      
      var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToList();
      //_logger.LogInformation("Log List: {@Item}", list.First());
      return list;
    }
  }
}