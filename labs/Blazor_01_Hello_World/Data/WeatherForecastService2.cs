using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_01_Hello_World.Data
{
    public class WeatherForecastService2
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var random = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select
                (index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)]
            }).ToArray());
        }

        public Task<Test[]> GetTestAsync(DateTime startDate)
        {
            var random = new Random();
            return Task.FromResult(Enumerable.Range(1, 3).Select(index => new Test
            {
                Date=startDate.AddDays(index),
                TemperatureC=random.Next(-20,30),
                Summary = "A Summary"
            }

            ).ToArray());
        }
    }
}
