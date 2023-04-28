﻿using Allure.Net.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Qase.Tests.UISettings;

namespace Qase.Utilities;

public class ScreenShotter : LoginTestSettings
{
    public void TakeScreenshot(IWebDriver webDriver)
    {
        var screenshot = webDriver.TakeScreenshot();
        var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".png";
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", filename);
        screenshot.SaveAsFile(path);

        AllureLifecycle.Instance.AddAttachment(path);
    }
}