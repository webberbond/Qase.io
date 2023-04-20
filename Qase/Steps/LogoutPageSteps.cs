using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class LogoutPageSteps
{
    private readonly LogoutPage _logoutPage;
    
    public LogoutPageSteps(IWebDriver webDriver)
    {
        _logoutPage = new LogoutPage(webDriver);
    }
    
    [AllureStep("Logout")]
    public LogoutPageSteps Logout()
    {
        _logoutPage.OpenProfile();
        _logoutPage.LogoutButtonClick();
        
        return this;
    }
    
    [AllureStep("Verify Page Is Opened")]
    public bool VerifyPageIsOpened()
    {
        return _logoutPage.IsPageOpened;
    }
}