using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class RunsPageSteps
{
    private IWebDriver WebDriver { get; }
    
    public RunsPageSteps(IWebDriver webDriver) 
    {
        WebDriver = webDriver;
    }
    
    private RunsPage RunsPage => new(WebDriver);
    
    [AllureStep("Create New Test Run")]
    public RunsPageSteps CreateNewTestRun()
    {
        RunsPage.OpenTestRunsPage();
        RunsPage.StartNewTestRun();
        
        return this;
    }

    [AllureStep("Input Data")]
    public RunsPageSteps InputInformation(TestRunsModel testRun)
    {
        RunsPage
            .InputTestRunDescription(testRun.Description);

        return this;
    }
    
    [AllureStep("Add Tests From Repository")]
    public RunsPageSteps AddTestsFromRepository()
    {
        RunsPage
            .AddTestsFromRepository()
            .TestCaseButtonClick()
            .TestCaseCheckBoxClick()
            .DoneButtonClick();

        return this;
    }
    
    [AllureStep("Start Test Run")]
    public RunsPageSteps StartTestRun()
    {
        RunsPage.StartRunButtonClick();
        
        return this;
    }

    [AllureStep("Complete Test Run")]
    public RunsPageSteps CompleteTestRun()
    {
        RunsPage
            .CompleteRunButtonClick()
            .CompleteConfirmButtonClick();
        
        return this;
    }
}