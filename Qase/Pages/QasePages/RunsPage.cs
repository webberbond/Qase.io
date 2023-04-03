using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class RunsPage : BasePage
{
    public RunsPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Test runs']");

    private static RunsPageComponents RunsPageComponents => new();

    public RunsPage OpenRunsPage()
    {
        RunsPageComponents.TestRunsButton.Click();

        return this;
    }

    public RunsPage StartNewRunButtonClick()
    {
        RunsPageComponents.StartNewTestRunButton.Click();

        return this;
    }

    public RunsPage InputDescription(string testRunDescription)
    {
        RunsPageComponents.TestRunDescriptionField.SendText(testRunDescription);

        return this;
    }

    public RunsPage AddTestFromRepositoryButtonClick()
    {
        RunsPageComponents.AddTestsFromRepositoryButton.Click();

        return this;
    }

    public RunsPage TestCaseButtonClick()
    {
        RunsPageComponents.TestCaseButton.Click();

        return this;
    }

    public RunsPage TestCaseCheckboxButtonClick()
    {
        RunsPageComponents.TestCaseCheckboxButton.Click();

        return this;
    }

    public RunsPage DoneButtonClick()
    {
        RunsPageComponents.DoneButton.Click();

        return this;
    }

    public RunsPage StartRun()
    {
        RunsPageComponents.StartRunButton.Click();

        return this;
    }

    public static bool IsShareReportButtonDisplayed()
    {
        return RunsPageComponents.ShareReportButton.IsDisplayed();
    }

    public RunsPage CompleteRunButtonClick()
    {
        RunsPageComponents.CompleteRunButton.Click();

        return this;
    }

    public RunsPage CompleteRunConfirmButtonClick()
    {
        RunsPageComponents.CompleteConfirmButton.Click();

        return this;
    }

    public static bool IsRunAgainButtonDisplayed()
    {
        return RunsPageComponents.RunAgainButton.IsDisplayed();
    }
}