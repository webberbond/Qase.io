using NUnit.Allure.Attributes;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class RepositoryPageSteps : BaseStep
{
    private RepositoryPage RepositoryPage => new(Browser);
    
    public RepositoryPageSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Validate Repository Page Is Opened")]
    public RepositoryPageSteps ValidateIsRepositoryPageOpened()
    {
        RepositoryPage.IsPageOpened();

        return this;
    }

    [AllureStep("Click Repository Button")]
    public RepositoryPageSteps ClickRepositoryButton()
    {
        RepositoryPage.ClickRepositoryButton();

        return this;
    }

    [AllureStep("Create New Test Case")]
    public RepositoryPageSteps CreateNewTestCase()
    {
        RepositoryPage.CreateNewTestCase();

        return this;
    }

    [AllureStep("Input Data")]
    public RepositoryPageSteps InputData(TestCaseModel testCase)
    {
        RepositoryPage
            .InputTitle(testCase.Title)
            .InputDescription(testCase.Description)
            .InputPreConditions(testCase.PreConditions)
            .InputPostConditions(testCase.PostConditions);

        return this;
    }

    [AllureStep("Save Test Case")]
    public RepositoryPageSteps SaveTestCase()
    {
        RepositoryPage.ClickSaveTestCaseButton();

        return this;
    }

    [AllureStep("Validate Test Case Was Created Successfully")]
    public RepositoryPageSteps ValidateTestCaseCreated()
    {
        RepositoryPage.ValidateTestCaseCreated();

        return this;
    }
}