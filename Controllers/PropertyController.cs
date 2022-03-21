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
        private readonly IApplicationService _applicationService; 
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger, IPostCodePositionService postCodePositionService,
            IPropertyInfoService propertyInfoService, IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLocalSoldPricesForPostCode (string postcode) 
        {
            var allLocalSold = await _applicationService.GetAllLocalSoldPropertiesForPostCodeAsync(postcode);

            return new JsonResult(new { Data = allLocalSold });
        }
    }
}
