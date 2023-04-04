using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class MainPage : BasePage
{
    public MainPage(Browser browser) : base(browser)
    {
    }

    private WebDriver WebDriver => Browser.WebDriver;

    protected override By UniqueWebLocator => By.CssSelector(".cover-new.text-left.pt-5.max-w-6xl");
    
    private static MainPageComponents MainPageComponents => new();

    public MainPage OpenPage()
    {
        WebDriver.Navigate().GoToUrl(BaseUrl);

        return this;
    }

    public MainPage ClickLogin()
    {
        MainPageComponents.LoginButton.Click();

        return this;
    }
}