using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly EshopContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, EshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<List<ShopProduct>> GetPro()
        {

            List<ShopProduct> ItemTable = await (from sp in _context.ShopProducts
                             join qt in _context.QuantityTypes on
                             sp.QuantityType equals qt.QuantityTypeId                  
                             orderby sp.Id
                             select new ShopProduct
                             {
                                 Id = sp.Id,
                                 ProductId = sp.ProductId,
                                 ProductName = sp.ProductName,
                                 QuantityTypeNavigation = new QuantityType()
                                 {
                                     QuantityTypeId = qt.QuantityTypeId,
                                     QuantityTypeName = qt.QuantityTypeName
                                 }
                             }).ToListAsync();
            return ItemTable;
        }
    }
}
