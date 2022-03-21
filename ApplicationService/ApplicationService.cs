
using PricedCodes2Project.DataTransferObjects;
using PricedCodes2Project.PostcodePositionService;
using PricedCodes2Project.PropertyInfoService;

namespace PricedCodes2Project.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        private readonly IPropertyInfoService _propertyInfoService;

        private readonly IPostCodePositionService _postCodePositionService;
       
        public ApplicationService(IPropertyInfoService propertyInfoService, IPostCodePositionService postCodePositionService)
        {
            _propertyInfoService = propertyInfoService;
            _postCodePositionService = postCodePositionService;
        }

        public async Task<List<PropertyDto>> GetAllLocalSoldPropertiesForPostCodeAsync(string postCode)
        {
            var positionForPostcode = await _postCodePositionService.GetPositionForPostcodeAsync(new List<string> { postCode });

            if (positionForPostcode.First().Latitude == null) { return new List<PropertyDto> { PropertyDto.CreateDtoWithErrorMessage("Unable To Find Position For Postcode Entered") }; };
               
               var postCodePositionsInRange = await _postCodePositionService.GetLocalPostcodesForPositionAsync(positionForPostcode.First().Latitude, positionForPostcode.First().Longitude);

            if (postCodePositionsInRange.First().Latitude == null) { return new List<PropertyDto> { PropertyDto.CreateDtoWithErrorMessage("Unable To Find Any Postcodes Within Range") }; };
                  
               var postCodesList = postCodePositionsInRange.Select(x => x.PostCode).ToList();
               var localSoldProperties = await _propertyInfoService.GetPropertyInfoForPostcodesAsync(postCodesList);
                  
            if (localSoldProperties.Count() < 1) { return new List<PropertyDto> { PropertyDto.CreateDtoWithErrorMessage("No Sales in Range") };};

                    var allPropertyInfo = new List<PropertyDto>();

                    foreach (var property in localSoldProperties)
                    {
                       var positionForSoldProperty = postCodePositionsInRange.FirstOrDefault(x => x.PostCode == property.PostCode);
                          allPropertyInfo.Add(PropertyDto.AddPositionToDto(property, positionForSoldProperty.Latitude, positionForSoldProperty.Longitude));
                    }

                    return allPropertyInfo;

                }
            }
        }


