using PricedCodes2Project.DataAccess.Models;

namespace PricedCodes2Project.DataTransferObjects
{
    public class PostCodePositionDto
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        internal static PostCodePositionDto CreateFromModel(PostCodePosition position) 
        {
            return new PostCodePositionDto
            {
                Id = position.Id,
                PostCode = position.PostCode,
                Latitude = position.Latitude,
                Longitude = position.Longitude
            };
        }
    }
}
