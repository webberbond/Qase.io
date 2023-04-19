using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class PlansPageSteps
{
    private readonly PlansPage _plansPage;
    
    public PlansPageSteps(IWebDriver webDriver) 
    {
        _plansPage = new PlansPage(webDriver);
    }

    [AllureStep("Create New Test Plan")]
    public PlansPageSteps CreateNewTestPlan()
    {
        _plansPage.OpenTestPlans();
        _plansPage.CreatePlanButtonClick();

        return this;
    }
    
    [AllureStep("Input Information")]
    public PlansPageSteps InputInformation(TestPlanModel testPlan)
    {
        _plansPage
            .InputTitle(testPlan.PlanTitle)
            .InputDescription(testPlan.PlanDescription);

        return this;
    }
    
    [AllureStep("Add Test Cases")]
    public PlansPageSteps AddTestCases()
    {
        _plansPage
            .AddTestCasesButtonClick()
            .CreatedTestCaseButtonClick()
            .CreatedTestCaseCheckboxButtonClick()
            .DoneButtonClick();

        return this;
    }
    
    [AllureStep("Save Test Plan")]
    public PlansPageSteps SaveTestPlan()
    {
        _plansPage.SubmitPlanButtonClick();
        
        return this;
    }
    
    [AllureStep("Get Test Plan Title")]
    public string GetTestPlanTitle()
    {
        return _plansPage.GetTestPlanTitle();
    }
}