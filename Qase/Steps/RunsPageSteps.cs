using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class RunsPageSteps
{
    private readonly RunsPage _runsPage;
    
    public RunsPageSteps(IWebDriver webDriver) 
    {
        _runsPage = new RunsPage(webDriver);
    }

    [AllureStep("Create New Test Run")]
    public RunsPageSteps CreateNewTestRun()
    {
        _runsPage.OpenTestRunsPage();
        _runsPage.StartNewTestRun();
        
        return this;
    }

    [AllureStep("Input Data")]
    public RunsPageSteps InputInformation(TestRunsModel testRun)
    {
        _runsPage
            .InputTestRunDescription(testRun.Description);

        return this;
    }
    
    [AllureStep("Add Tests From Repository")]
    public RunsPageSteps AddTestsFromRepository()
    {
        _runsPage
            .AddTestsFromRepository()
            .TestCaseButtonClick()
            .TestCaseCheckBoxClick()
            .DoneButtonClick();

        return this;
    }
    
    [AllureStep("Start Test Run")]
    public RunsPageSteps StartTestRun()
    {
        _runsPage.StartRunButtonClick();
        
        return this;
    }

    [AllureStep("Complete Test Run")]
    public RunsPageSteps CompleteTestRun()
    {
        _runsPage
            .CompleteRunButtonClick()
            .CompleteConfirmButtonClick();
        
        return this;
    }
    
    [AllureStep("Check if button is displayed")]
    public bool CheckIfButtonIsDisplayed()
    {
       return _runsPage.IsShareReportButtonDisplayed();
    }
}