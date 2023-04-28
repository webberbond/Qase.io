using OpenQA.Selenium;
using Qase.Utilities;

namespace Qase.Pages;

public abstract class BasePage
{
    protected IWebDriver WebDriver { get; }

    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    private IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);
    
    protected abstract By UniqueWebLocator { get; }

    private readonly string? _baseUrl = new Configurator().BaseUrl;
    
    protected abstract string UrlPath { get; }

    public void OpenPage()
    {
        var uri = new Uri(_baseUrl?.TrimEnd('/') + UrlPath, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(uri);
    }

    public bool IsPageOpened
    {
        get
        {
            bool isOpened;
            try
            {
                isOpened = UniqueWebElement.Displayed;
            }
            catch (Exception)
            {
                isOpened = false;
            }

            return isOpened;
        }
    }
}