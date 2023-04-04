using SeleniumWrapper.Elements.Label;

namespace SeleniumWrapper.Forms;

public abstract class BaseForm
{
    protected BaseForm(Browser browser)
    {
        Browser = browser;
    }

    private Browser Browser { get; }

    protected abstract By UniqueWebLocator { get; }


    private BaseElement UniqueElement => new Label(UniqueWebLocator, "Unique Element ");

    public bool IsPageOpened => UniqueElement.IsDisplayed();

    public void WaitForPageOpened()
    {
        try
        {
            Browser.BrowserWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException error)
        {
            var errorMessage = $"Page with unique locator'{UniqueWebLocator}' wasn't opened";
            Logger.Instance.Fatal(errorMessage);
            throw new AssertionException(errorMessage, error);
        }
    }
}