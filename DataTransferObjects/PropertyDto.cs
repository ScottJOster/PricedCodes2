using PricedCodes2Project.DataAccess.Models;

namespace PricedCodes2Project.DataTransferObjects
{
    public class PropertyDto
    {
        public int? Id { get; set; }
        public string? PostCode { get; set; }
        public int? SoldPrice { get; set; }
        public string? PropertyType { get; set; }
        public string? ErrorMessage { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        internal static PropertyDto CreateFromModel(Property property) 
        {
            return new PropertyDto
            {
                Id = property?.Id,
                PostCode = property?.PostCode,
                SoldPrice = property?.SoldPrice,
                PropertyType = property?.PropertyType
            };
        }
        internal static PropertyDto AddPositionToDto(PropertyDto propertyDto,decimal latitude, decimal longitude)
        {
            propertyDto.Latitude = latitude;
            propertyDto.Longitude = longitude;
            return propertyDto;

        }
        //dont need below just do same in app service
        internal static PropertyDto CreateDtoWithErrorMessage( string errorMessage)
        {
            return new PropertyDto { ErrorMessage = errorMessage };
           
        }
    }
}
