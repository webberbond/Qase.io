using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Utilities;

namespace Qase.Tests.UI;

[AllureNUnit]
public class RunsTest : BaseTest
{
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();
    private readonly TestRunsModel _testRunModel = new TestRunsModelDataFaker().Generate();

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Creation of New Test Run With Validations")]
    [AllureLink("Create Test Run", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=856280847")]
    public void CreateTestRun()
    {
        MainPageSteps
            .OpenSite()
            .ValidateIsMainPageOpened()
            .ClickLoginButton()
            .ValidateIsLoginPageOpened();

        LoginSteps
            .InputData(Email, Password)
            .LoginButtonClick()
            .ValidateIsProjectsPageOpened();

        ProjectsPageSteps
            .CreateNewProject()
            .InputData(_testProjectModel)
            .ClickSubmitButton()
            .ValidateDetails(_testProjectModel);

        RepositoryPageSteps
            .ClickRepositoryButton()
            .ValidateIsRepositoryPageOpened()
            .CreateNewTestCase()
            .InputData(_testCaseModel)
            .SaveTestCase()
            .ValidateTestCaseCreated();

        RunsPageSteps
            .OpenRunsPage()
            .ValidateIsRunsPageOpened()
            .CreateNewRun()
            .InputData(_testRunModel)
            .AddTestsFromRepository()
            .StartTestRun()
            .ValidateTestRunWasCreated()
            .CompleteTestRun()
            .ValidateTestRunWasCompleted();
        
        ScreenShotter.TakeScreenshot();

        ProjectsPageSteps
            .OpenSettingsPage()
            .DeleteProject()
            .ValidateProjectsPageIsOpened();
    }
}