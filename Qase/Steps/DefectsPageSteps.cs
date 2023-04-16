using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class DefectsPageSteps
{
    private IWebDriver WebDriver { get; }
    
    public DefectsPageSteps(IWebDriver webDriver) 
    {
        WebDriver = webDriver;
    }
    
    private DefectsPage DefectsPage => new(WebDriver);

    [AllureStep("Open Defects Page")]
    public DefectsPageSteps OpenDefectsPage()
    {
        DefectsPage.CreateNewDefect();

        return this;
    }
    
    [AllureStep("Create New Defect")]
    public DefectsPageSteps CreateNewDefect(DefectsModel defectsModel)
    {
        DefectsPage.InputDefectTitle(defectsModel.DefectTitle);
        DefectsPage.InputDefectActualResult(defectsModel.ActualResult);
        DefectsPage.CreateDefect();
        
        return this;
    }
}