using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Utilities;

namespace Qase.Tests.UI;

[AllureNUnit]
public class LoginTest : BaseTest
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Login Test With Validations")]
    public void Authorization()
    {
        MainPageSteps
            .OpenSite()
            .ValidateIsMainPageOpened()
            .ClickLoginButton()
            .ValidateIsLoginPageOpened();

        LoginSteps
            .InputData(Email, Password)
            .LoginButtonClick()
            .ValidateIsProjectsPageOpened();
        
        ScreenShotter.TakeScreenshot();
    }

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Error Login Test With Validations")]
    public void AuthorizationError()
    {
        MainPageSteps
            .OpenSite()
            .ValidateIsMainPageOpened()
            .ClickLoginButton()
            .ValidateIsLoginPageOpened();

        LoginSteps
            .InputData(Email, "123456")
            .LoginButtonClick()
            .ValidateErrorMessage();
        
        ScreenShotter.TakeScreenshot();
    }
}