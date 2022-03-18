using PricedCodes2Project.DataTransferObjects;

namespace PricedCodes2Project.ApplicationService
{
    public interface IApplicationService
    {
        Task<List<PropertyDto>> GetAllLocalSoldPropertiesForPostCodeAsync(string postCode);
    }
}
