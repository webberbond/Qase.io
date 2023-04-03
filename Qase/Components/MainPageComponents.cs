using OpenQA.Selenium;
using SeleniumWrapper.Elements.Button;

namespace Qase.Components;

public class MainPageComponents
{
    public readonly Button LoginButton = new(By.CssSelector("#signin"), "Login button");
}