using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class RepositoryPageSteps
{
    private IWebDriver WebDriver { get; }
    
    public RepositoryPageSteps(IWebDriver webDriver) 
    {
        WebDriver = webDriver;
    }
    
    private RepositoryPage RepositoryPage => new(WebDriver);

    [AllureStep("Create New Test Case")]
    public RepositoryPageSteps CreateNewTestCase()
    {
        RepositoryPage.CreateNewTestCase();

        return this;
    }
    
    [AllureStep("Input Data")]
    public RepositoryPageSteps InputInformation(TestCaseModel testCase)
    {
        RepositoryPage
            .InputTitle(testCase.Title)
            .InputDescription(testCase.Description)
            .InputPreConditions(testCase.PreConditions)
            .InputPostConditions(testCase.PostConditions);

        return this;
    }
    
    [AllureStep("Save Test Case")]
    public RepositoryPageSteps ClickSaveTestCaseButton()
    {
        RepositoryPage.ClickSaveTestCaseButton();
        
        return this;
    }
}