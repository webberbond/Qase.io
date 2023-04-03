using FluentAssertions;
using NUnit.Allure.Attributes;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class RunsPageSteps : BaseStep
{
    private RunsPage RunsPage => new(Browser);
    
    public RunsPageSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Open Runs Page")]
    public RunsPageSteps OpenRunsPage()
    {
        RunsPage.OpenRunsPage();

        return this;
    }

    [AllureStep("Validate Runs Page Is Opened")]
    public RunsPageSteps ValidateIsRunsPageOpened()
    {
        RunsPage.IsPageOpened();

        return this;
    }

    [AllureStep("Create New Test Run")]
    public RunsPageSteps CreateNewRun()
    {
        RunsPage.StartNewRunButtonClick();

        return this;
    }

    [AllureStep("Input Data")]
    public RunsPageSteps InputData(TestRunsModel testRun)
    {
        RunsPage.InputDescription(testRun.Description);

        return this;
    }

    [AllureStep("Add Tests From Repository")]
    public RunsPageSteps AddTestsFromRepository()
    {
        RunsPage
            .AddTestFromRepositoryButtonClick()
            .TestCaseButtonClick()
            .TestCaseCheckboxButtonClick()
            .DoneButtonClick();

        return this;
    }

    [AllureStep("Start Test Run")]
    public RunsPageSteps StartTestRun()
    {
        RunsPage.StartRun();

        return this;
    }

    [AllureStep("Validate Test Run Was Created")]
    public RunsPageSteps ValidateTestRunWasCreated()
    {
        RunsPage.IsShareReportButtonDisplayed().Should().BeTrue();

        return this;
    }

    [AllureStep("Complete Test Run")]
    public RunsPageSteps CompleteTestRun()
    {
        RunsPage
            .CompleteRunButtonClick()
            .CompleteRunConfirmButtonClick();

        return this;
    }

    [AllureStep("Validate Test Run Was Completed")]
    public RunsPageSteps ValidateTestRunWasCompleted()
    {
        RunsPage.IsRunAgainButtonDisplayed().Should().BeTrue();

        return this;
    }
}