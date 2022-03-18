using PricedCodes2Project.DataAccess.Models;
using PricedCodes2Project.DataTransferObjects;

namespace PricedCodes2Project.PostcodePositionService
{
    public interface IPostCodePositionService
    {
         Task <IEnumerable<PostCodePositionDto>> GetPositionForPostcodeAsync(List<string> pcode);
        Task<IEnumerable<PostCodePositionDto>> GetLocalPostcodesForPositionAsync(decimal latitude, decimal longitude);
    }
}
