using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Steps;
using Qase.Tests.UISettings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class LogoutTest : LoginTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Logout Test With Validations")]
      public void TestPlanCreation()
    {
        var logoutPageSteps = new LogoutPageSteps(WebDriver);

        logoutPageSteps
            .Logout();
           
        
        Assert.That(logoutPageSteps.VerifyPageIsOpened(), Is.EqualTo(true), "Checking if alert text is correct after creating a test plan.");
    }
    
    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}