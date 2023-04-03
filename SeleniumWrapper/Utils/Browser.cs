namespace SeleniumWrapper.Utils;

public class Browser : IBrowser
{
    public Browser(WebDriver webDriver)
    {
        WebDriver = webDriver;
        BrowserWait =
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(BrowserService.BrowserProfile.ConditionTimeWait));
        MaximizeWindow();
    }

    public WebDriverWait BrowserWait { get; }
    public WebDriver WebDriver { get; }

    public bool IsStarted => WebDriver.SessionId != null;

    public void GoToUrl(Uri uri)
    {
        GoToUrl(uri.ToString());
    }

    private void GoToUrl(string uri)
    {
        Logger.Instance.Info($"Go To Url {uri}");
        WebDriver.Navigate().GoToUrl(uri);
    }

    public void Quit()
    {
        Logger.Instance.Info("Quit Browser");
        WebDriver.Quit();
    }

    private void MaximizeWindow()
    {
        Logger.Instance.Info("Maximize Window");
        WebDriver.Manage().Window.Maximize();
    }

    public void BackPage()
    {
        Logger.Instance.Info("Navigate To Previous Page");
        WebDriver.Navigate().Back();
    }
}