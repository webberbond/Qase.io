namespace SeleniumWrapper.Elements;

public abstract class BaseElement
{
    protected readonly WebDriverWait Wait = new(WebDriver, TimeSpan.FromSeconds(10));

    protected BaseElement(By locator, string name)
    {
        Locator = locator;
        Name = name;
    }

    private By Locator { get; }

    protected string Name { get; }

    private static WebDriver WebDriver => BrowserService.Browser.WebDriver;
    
    protected IJavaScriptExecutor JavaScriptExecutor => WebDriver;

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }

    protected IWebElement FindElement()
    {
        Logger.Instance.Info($"Find element with locator {Locator}");
        return Wait.Until(webDriver => webDriver.FindElement(Locator));
    }

    protected void ClearField()
    {
        FindElement().Clear();
        FindElement().Clear();
        FindElement().Clear();
    }
}