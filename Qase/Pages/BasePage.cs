using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase.Config;
using SeleniumExtras.WaitHelpers;
using SeleniumWrapper.Forms;
using SeleniumWrapper.Helpers;
using SeleniumWrapper.Utils;

namespace Qase.Pages;

public abstract class BasePage : BaseForm
{
    protected static readonly string? BaseUrl = AppConfiguration.BaseUrl;

    private readonly WebDriverWait _wait = new(WebDriver, TimeSpan.FromSeconds(15));

    protected BasePage(Browser browser) : base(browser)
    {
        Browser = browser;
    }

    protected Browser Browser { get; }
    
    private static WebDriver WebDriver => BrowserService.Browser.WebDriver;

    protected abstract override By UniqueWebLocator { get; }

    public new bool IsPageOpened()
    {
        try
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(UniqueWebLocator));
            return true;
        }
        catch (TimeoutException)
        {
            Logger.Instance.Info("Page was not opened");
            return false;
        }
    }
}