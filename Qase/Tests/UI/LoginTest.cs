using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.TestData;
using Qase.Tests.Settings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class LoginTest : ErrorLoginTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Error Login Test With Validations")]
    [AllureLink("Error Login", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=233756267")]
    public void ErrorAuthorization()
    {
        LoginPageSteps
            .OpenPage()
            .UserLogin(Authentication.FakeUser().Email, Authentication.FakeUser().Password);
        
        Assert.That(LoginPageSteps.GetErrorMessage(), Is.EqualTo("These credentials do not match our records."), "Checking error message's text if credentials are wrong");
    }
}