using PricedCodes2Project.DataAccess.Models;
using PricedCodes2Project.DataTransferObjects;

namespace PricedCodes2Project.PropertyInfoService
{
    public interface IPropertyInfoService
    {
        Task <IEnumerable<PropertyDto>> GetPropertyInfoForPostcodesAsync(List<string> postCodes);
    }
}
