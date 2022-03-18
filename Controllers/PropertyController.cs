using Microsoft.AspNetCore.Mvc;
using PricedCodes2Project.DataAccess.Models;
using PricedCodes2Project.PostcodePositionService;
using Newtonsoft.Json;
using PricedCodes2Project.PropertyInfoService;
using PricedCodes2Project.ApplicationService;

namespace Project1.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPostCodePositionService _postCodePositionService;
        private readonly IPropertyInfoService _propertyInfoService;
        private readonly IApplicationService _applicationService; 

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
       // private readonly IPostCodePositionService _postCodePoisitionService;
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger, IPostCodePositionService postCodePositionService,
            IPropertyInfoService propertyInfoService, IApplicationService applicationService)
        {
            _logger = logger;
            _postCodePositionService = postCodePositionService;
            _propertyInfoService = propertyInfoService;
            _applicationService = applicationService;
          
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();

        }

        [HttpGet]
        
    
       /* public async Task<ActionResult> GetPostCodePosition(string postCode)
        {
            var testCall = await _postCodePositionService.GetPositionForPostcodeAsync(new List<string> { postCode });
           
            
            var testData = new List<string> { "test", "test" };

            if (testCall.FirstOrDefault().PostCode != null)
            {

                var longitude = testCall.FirstOrDefault().Longitude;
                var latitude = testCall.FirstOrDefault().Latitude;


                var positionsInRange = await _postCodePositionService.GetLocalPostcodesForPositionAsync(latitude, longitude);

                var postcodesInRange = new List<string>();
                foreach (var position in positionsInRange) 
                {
                    postcodesInRange.Add(position.PostCode);
                }


                var testCallOnPropertyInfoForPostcodes = await _propertyInfoService.GetPropertyInfoForPostcodesAsync(postcodesInRange);

                return new JsonResult(new {Data = testCallOnPropertyInfoForPostcodes }); 
            }
        
            return new JsonResult (new { Data = testCall }) ;
        }*/

        public async Task<ActionResult> GetAllLocalSoldPricesForPostCode (string postcode) 
        {
            var allLocalSold = await _applicationService.GetAllLocalSoldPropertiesForPostCodeAsync(postcode);

            return new JsonResult(new { Data = allLocalSold });
        }
    }
}
