using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EliteABP.Develop.HttpApi.Controllers;

[Route("[controller]")]
public class WeatherForecastController : AbpControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<int> Get()
    {
        Logger.LogInformation("");
        return Enumerable.Range(1, 5).ToArray();
    }
}