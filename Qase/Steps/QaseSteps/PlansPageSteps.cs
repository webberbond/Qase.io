using FluentAssertions;
using NUnit.Allure.Attributes;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class PlansPageSteps : BaseStep
{
    private PlansPage PlansPage => new(Browser);
    
    public PlansPageSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Open Test Plans")]
    public PlansPageSteps OpenTestPlans()
    {
        PlansPage.OpenTestPlans();

        return this;
    }

    [AllureStep("Validate Test Plans Page Is Opened Successfully")]
    public PlansPageSteps ValidateIsTestPlansPageOpened()
    {
        PlansPage.IsPageOpened();

        return this;
    }

    [AllureStep("Click Create Plan Button")]
    public PlansPageSteps CreatePlanButtonClick()
    {
        PlansPage.CreatePlanButtonClick();

        return this;
    }

    [AllureStep("Input Data")]
    public PlansPageSteps InputData(TestPlanModel testPlan)
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
            .AddCasesButtonClick()
            .CreatedTestCaseButtonClick()
            .CreatedTestCaseCheckboxButtonClick()
            .DoneButtonClick();

        return this;
    }

    [AllureStep("Submit Test Plan")]
    public PlansPageSteps CreatePlan()
    {
        PlansPage.CreatePlan();

        return this;
    }

    [AllureStep("Validate Test Plan Was Created Successfully")]
    public PlansPageSteps ValidatePlanWasCreated()
    {
        Thread.Sleep(3000);
        PlansPage.AlertDisplayed().Should().BeTrue();
        PlansPage.AlertMessage().Should().Be("Test plan was created successfully!");

        return this;
    }
}