namespace SeleniumWrapper.Utils;

public class LocalBrowserFactory : BrowserFactory
{
    public LocalBrowserFactory(BrowserProfile? browserProfile)
    {
        BrowserProfile = browserProfile;
    }

    private BrowserProfile? BrowserProfile { get; }

    protected override WebDriver WebDriver
    {
        get
        {
            var browserName = BrowserProfile!.BrowserName;
            var driverSettingsOptions = BrowserProfile.BrowserSettings;
            var driverSettings = new ChromeOptions();
            driverSettings.AddArguments(driverSettingsOptions);
            var options = driverSettings;
            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    Logger.Instance.Debug("initialize Chrome Window");
                    WebDriver webDriver = new ChromeDriver(options);
                    return webDriver;
                default:
                    throw new InvalidEnumArgumentException($"WebDriver for browser {browserName} is not supported");
            }
        }
    }
}

public enum BrowserEnum
{
    Chrome,
    Edge,
    FireFox
}