using System.Threading.Tasks;
using VisitorSystem.Models.TokenAuth;
using VisitorSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace VisitorSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: VisitorSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}