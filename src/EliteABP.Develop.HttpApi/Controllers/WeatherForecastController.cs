using Microsoft.AspNetCore.Mvc;

namespace EliteABP.Develop.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<int> Get()
    {
        return Enumerable.Range(1, 5).ToArray();
    }
}