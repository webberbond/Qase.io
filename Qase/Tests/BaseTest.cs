using OpenQA.Selenium;
using Qase.Config;
using Qase.Steps.QaseSteps;
using SeleniumWrapper.Utils;

namespace Qase.Tests;

public class BaseTest
{
    protected const string Email = "sergey.zrch@gmail.com";
    protected const string Password = "Deadspace456,";

    private Browser Browser { get; set; } = null!;

    protected static WebDriver WebDriver => BrowserService.Browser.WebDriver;

    protected MainPageSteps MainPageSteps { get; private set; } = null!;

    protected LoginSteps LoginSteps { get; private set; } = null!;

    protected ProjectsPageSteps ProjectsPageSteps { get; private set; } = null!;

    protected PlansPageSteps PlansPageSteps { get; private set; } = null!;

    protected RepositoryPageSteps RepositoryPageSteps { get; private set; } = null!;

    protected DefectsPageSteps DefectsPageSteps { get; private set; } = null!;

    protected RunsPageSteps RunsPageSteps { get; private set; } = null!;

    [SetUp]
    public void SetUp()
    {
        Browser = BrowserService.StartBrowser(AppConfiguration.BrowserProfile);

        MainPageSteps = new MainPageSteps(Browser);

        LoginSteps = new LoginSteps(Browser);

        ProjectsPageSteps = new ProjectsPageSteps(Browser);

        PlansPageSteps = new PlansPageSteps(Browser);

        RepositoryPageSteps = new RepositoryPageSteps(Browser);

        DefectsPageSteps = new DefectsPageSteps(Browser);

        RunsPageSteps = new RunsPageSteps(Browser);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}