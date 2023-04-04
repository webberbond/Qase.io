using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class PlansPage : BasePage
{
    public PlansPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Test plans']");

    private static PlansPageComponents PlansPageComponents => new();

    public PlansPage OpenTestPlans()
    {
        PlansPageComponents.TestPlanButton.Click();

        return this;
    }

    public PlansPage CreatePlanButtonClick()
    {
        PlansPageComponents.CreatePlanButton.Click();

        return this;
    }

    public PlansPage InputTitle(string planTitle)
    {
        PlansPageComponents.TitleInput.SendText(planTitle);

        return this;
    }

    public PlansPage InputDescription(string planDescription)
    {
        PlansPageComponents.DescriptionInput.SendText(planDescription);

        return this;
    }

    public PlansPage AddCasesButtonClick()
    {
        PlansPageComponents.AddCasesButton.Click();

        return this;
    }

    public PlansPage CreatedTestCaseButtonClick()
    {
        PlansPageComponents.CreatedTestCaseButton.Click();

        return this;
    }

    public PlansPage CreatedTestCaseCheckboxButtonClick()
    {
        PlansPageComponents.CreatedTestCaseCheckboxButton.Click();

        return this;
    }

    public PlansPage DoneButtonClick()
    {
        PlansPageComponents.DoneButton.Click();

        return this;
    }

    public PlansPage CreatePlan()
    {
        PlansPageComponents.SubmitPlanButton.Click();

        return this;
    }
    
    public static bool ValidateTestPlanWasCreated(string planTitle)
    {
        var contains = PlansPageComponents.TestPlanTitle.GetText().Contains(planTitle);

        return contains;
    }
}