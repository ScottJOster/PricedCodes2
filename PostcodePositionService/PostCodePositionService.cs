using Microsoft.EntityFrameworkCore;
using PricedCodes2Project.DataAccess.Context;
using PricedCodes2Project.DataAccess.Models;
using PricedCodes2Project.DataTransferObjects;

namespace PricedCodes2Project.PostcodePositionService
{
    public class PostcodePositionService : IPostCodePositionService
    {
       
        private readonly AppDbContext _context;

        public PostcodePositionService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostCodePositionDto>> GetLocalPostcodesForPositionAsync(decimal? latitude, decimal? longitude)
        {
            //one degree of lat roughly 69 miles
            //base on 0.005 degree 
            // obviousy possible to make this more dynamic by passing mile range and using seperate methods for calcs to keep solid
            var minLat = latitude - 0.005m;
            var maxLat = latitude + 0.005m;
            var minLong = longitude - 0.005m;
            var maxLong = longitude + 0.005m;

            var localPostCodes = await _context.PostcodePosition.Where(x => (x.Latitude <= maxLat) && (x.Latitude >= minLat) 
            && (x.Longitude <= maxLong) && (x.Longitude >= minLong)).ToListAsync();
            if (localPostCodes.FirstOrDefault().PostCode != null)
            {
                var dtoList = new List<PostCodePositionDto>();

                foreach (var localPostCode in localPostCodes)
                {
                    dtoList.Add(PostCodePositionDto.CreateFromModel(localPostCode));
                }

                return dtoList;
            }
            else throw new Exception("Unable to find local properties in db");
        }

       

        public async Task <IEnumerable<PostCodePositionDto>> GetPositionForPostcodeAsync(List<string> postCodes)
        {

            var postcodePositions = await _context.PostcodePosition.Where(x => postCodes.Contains(x.PostCode)).ToListAsync(); 

            var postCodePositionsDto = new List<PostCodePositionDto>();
            {
                foreach (var position in postcodePositions)
                {
                    postCodePositionsDto.Add(PostCodePositionDto.CreateFromModel(position));
                }

                return postCodePositionsDto;
            }
             throw new Exception("No poistion available for postcode provided");
        }
    }
}
