using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ClientTest3.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CallForwardController : ControllerBase
{
    private readonly ILogger<CallForwardController> _logger;

    public CallForwardController(ILogger<CallForwardController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetForwardedWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        using HttpClient client = new();
        
        string jsonResponse = await client.GetStringAsync("http://webapplication2:8080/WeatherForecast/GetWeatherForecast");

        IEnumerable<WeatherForecast>? results = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(jsonResponse);
        Debug.Assert(results != null);

        return results;
    }
}
