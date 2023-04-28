using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class DefectsPageSteps
{
    private readonly DefectsPage _defectsPage;
    
    public DefectsPageSteps(IWebDriver webDriver)
    {
        _defectsPage = new DefectsPage(webDriver);
    }

    [AllureStep("Open Defects Page")]
    public DefectsPageSteps OpenDefectsPage()
    {
        _defectsPage.CreateNewDefect();

        return this;
    }
    
    [AllureStep("Create New Defect")]
    public DefectsPageSteps CreateNewDefect(DefectsModel defectsModel)
    {
        _defectsPage
            .InputDefectTitle(defectsModel.DefectTitle)
            .InputDefectActualResult(defectsModel.ActualResult)
            .CreateDefect();
        
        return this;
    }
    
    [AllureStep("Get Defect Title")]
    public string GetDefectTitle()
    {
        return _defectsPage.GetDefectTitle();
    }
}