using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class RepositoryPageSteps
{
    private readonly RepositoryPage _repositoryPage;
    
    public RepositoryPageSteps(IWebDriver webDriver) 
    {
        _repositoryPage = new RepositoryPage(webDriver);
    }

    [AllureStep("Create New Test Case")]
    public RepositoryPageSteps CreateNewTestCase()
    {
        _repositoryPage.CreateNewTestCase();

        return this;
    }
    
    [AllureStep("Input Data")]
    public RepositoryPageSteps InputInformation(TestCaseModel testCase)
    {
        _repositoryPage
            .InputTitle(testCase.Title)
            .InputDescription(testCase.Description)
            .InputPreConditions(testCase.PreConditions)
            .InputPostConditions(testCase.PostConditions);

        return this;
    }
    
    [AllureStep("Save Test Case")]
    public RepositoryPageSteps ClickSaveTestCaseButton()
    {
        _repositoryPage.ClickSaveTestCaseButton();
        
        return this;
    }
    
    [AllureStep("Get Alert Text")]
    public string GetAlertText()
    {
        return _repositoryPage.GetAlertText();
    }
}