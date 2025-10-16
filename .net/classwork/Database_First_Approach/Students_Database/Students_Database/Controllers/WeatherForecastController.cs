using Microsoft.AspNetCore.Mvc;
using Students_Database.Models;

namespace Students_Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};
        private readonly CollageContext _dbcontext;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,CollageContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Student> Get()
        {
            return _dbcontext.Students.ToList();
        }
    }
}
