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
    [AllureLink("Successful Login","https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=0")]
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
    [AllureLink("Error Login", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=233756267")]
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