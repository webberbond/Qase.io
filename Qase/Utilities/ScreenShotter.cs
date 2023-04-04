using Allure.Net.Commons;
using Qase.Tests;

namespace Qase.Utilities;

public abstract class ScreenShotter : BaseTest
{
    public static void TakeScreenshot()
    {
        var webDriver = WebDriver;
        var screenshot = webDriver.GetScreenshot();
        var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".png";
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", filename);
        screenshot.SaveAsFile(path);

        AllureLifecycle.Instance.AddAttachment(path);
    }
}