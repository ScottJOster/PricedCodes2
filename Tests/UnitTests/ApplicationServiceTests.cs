using NUnit;
using Moq;
using PricedCodes2Project.PropertyInfoService;
using PricedCodes2Project.PostcodePositionService;
using PricedCodes2Project.ApplicationService;
using PricedCodes2Project.DataTransferObjects;
using NUnit.Framework;


namespace PricedCodes2Project.Tests.UnitTests

{
    public class ApplicationServiceTests
    {

     [Test]
     public async Task GetAllLocalSoldPropertiesForPostCodeAsync_WhenNoPoistionForPosytCode_ContainsErrorMessage() 
        {

            //Arrange

            var fakePropertyInfoService = new Mock<IPropertyInfoService>();

            var fakePositionDto = new PostCodePositionDto { Latitude = null };

            var fakePostcodeList = new List<string>
            {
                "test"
            };

            var fakePostCodePoistionService = new Mock<IPostCodePositionService>();
            fakePostCodePoistionService.Setup(x => x.GetPositionForPostcodeAsync(fakePostcodeList)).ReturnsAsync(new List<PostCodePositionDto> {fakePositionDto });

            var fakeAppService = new ApplicationService.ApplicationService(fakePropertyInfoService.Object, fakePostCodePoistionService.Object);
            
            //Act

            var result = await fakeAppService.GetAllLocalSoldPropertiesForPostCodeAsync("test");

           //Assert

            StringAssert.Contains("Unable To Find Position", result.FirstOrDefault().ErrorMessage);
        
        }

        [Test]
        public async Task GetAllLocalSoldPropertiesForPostCodeAsync_WhenNoLocalPostcodesExist_ContainsErrorMessage()
        {

            //Arrange

            var fakePropertyInfoService = new Mock<IPropertyInfoService>();

            var fakeSearchPositionDto = new PostCodePositionDto { Latitude = 10.10000m, Longitude = -2.404m, PostCode = "Test" };

            var fakeSearchPositionReturnDto = new PostCodePositionDto { Latitude = null };

            var fakePostcodeList = new List<string>
            {
                "test"
            };

            var fakePostCodePoistionService = new Mock<IPostCodePositionService>();
            fakePostCodePoistionService.Setup(x => x.GetPositionForPostcodeAsync(fakePostcodeList)).ReturnsAsync(new List<PostCodePositionDto> { fakeSearchPositionDto });
            fakePostCodePoistionService.Setup(x => x.GetLocalPostcodesForPositionAsync(fakeSearchPositionDto.Latitude, fakeSearchPositionDto.Longitude)).ReturnsAsync(new List<PostCodePositionDto> { fakeSearchPositionReturnDto });

            var fakeAppService = new ApplicationService.ApplicationService(fakePropertyInfoService.Object, fakePostCodePoistionService.Object);

            //Act

            var result = await fakeAppService.GetAllLocalSoldPropertiesForPostCodeAsync("test");

            //Assert

            StringAssert.Contains("Unable To Find Any Postcodes", result.First().ErrorMessage);

        }
    }
}
