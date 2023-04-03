using FluentAssertions;
using NUnit.Allure.Attributes;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class DefectsPageSteps : BaseStep
{
    private DefectsPage DefectsPage => new(Browser);
    
    public DefectsPageSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Open Defects Page")]
    public DefectsPageSteps OpenDefectsPage()
    {
        DefectsPage.OpenDefects();

        return this;
    }

    [AllureStep("Validate Defects Page Is Opened Successfully")]
    public DefectsPageSteps ValidateIsDefectsPageOpened()
    {
        DefectsPage.IsPageOpened();

        return this;
    }

    [AllureStep("Create New Defect")]
    public DefectsPageSteps CreateNewDefect()
    {
        DefectsPage.NewDefectButtonClick();

        return this;
    }

    [AllureStep("Input Data")]
    public DefectsPageSteps InputData(DefectsModel defects)
    {
        DefectsPage
            .InputDefectTitle(defects.DefectTitle)
            .InputDefectActualResult(defects.ActualResult);

        return this;
    }

    [AllureStep("Submit Defect")]
    public DefectsPageSteps SubmitDefect()
    {
        DefectsPage.ClickCreateDefectButton();

        return this;
    }

    [AllureStep("Validate Defect Was Created Successfully")]
    public DefectsPageSteps ValidateDefectWasCreated()
    {
        DefectsPage.AlertDisplayed().Should().BeTrue();
        DefectsPage.AlertMessage().Should().Be("Defect was created successfully!");

        return this;
    }
}