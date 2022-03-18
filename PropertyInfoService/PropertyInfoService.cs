using Microsoft.EntityFrameworkCore;
using PricedCodes2Project.DataAccess.Context;
using PricedCodes2Project.DataAccess.Models;
using PricedCodes2Project.DataTransferObjects;

namespace PricedCodes2Project.PropertyInfoService
{
    public class PropertyInfoService : IPropertyInfoService
    {
        private readonly AppDbContext _context;

        public PropertyInfoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IEnumerable<PropertyDto>> GetPropertyInfoForPostcodesAsync (List<string> postCodes)
        {

            var propertyList = await _context.Property.Where(x=> postCodes.Contains(x.PostCode)).ToListAsync();

            var dtoList = new List<PropertyDto>();
            foreach (var property in propertyList) {

                dtoList.Add(PropertyDto.CreateFromModel(property));
            }
     return dtoList;
        }
    }
}
