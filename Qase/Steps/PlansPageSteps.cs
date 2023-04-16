using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class PlansPageSteps
{
    private IWebDriver WebDriver { get; }
    
    public PlansPageSteps(IWebDriver webDriver) 
    {
        WebDriver = webDriver;
    }
    
    private PlansPage PlansPage => new(WebDriver);

    [AllureStep("Create New Test Plan")]
    public PlansPageSteps CreateNewTestPlan()
    {
        PlansPage.OpenTestPlans();
        PlansPage.CreatePlanButtonClick();

        return this;
    }
    
    [AllureStep("Input Information")]
    public PlansPageSteps InputInformation(TestPlanModel testPlan)
    {
        PlansPage
            .InputTitle(testPlan.PlanTitle)
            .InputDescription(testPlan.PlanDescription);

        return this;
    }
    
    [AllureStep("Add Test Cases")]
    public PlansPageSteps AddTestCases()
    {
        PlansPage
            .AddTestCasesButtonClick()
            .CreatedTestCaseButtonClick()
            .CreatedTestCaseCheckboxButtonClick()
            .DoneButtonClick();

        return this;
    }
    
    [AllureStep("Save Test Plan")]
    public PlansPageSteps SaveTestPlan()
    {
        PlansPage.SubmitPlanButtonClick();
        
        return this;
    }
}