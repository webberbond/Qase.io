using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Utilities;

namespace Qase.Tests.UI;

[AllureNUnit]
public class PlansTest : BaseTest
{
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();
    private readonly TestPlanModel _testPlanModel = new TestPlanModelDataFaker().Generate();
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Plans Test With Validations")]
    [AllureLink("Create Test Plan", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=1547098580")]
    public void TestPlanCreation()
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

        PlansPageSteps
            .OpenTestPlans()
            .ValidateIsTestPlansPageOpened()
            .CreatePlanButtonClick()
            .InputData(_testPlanModel)
            .AddTestCases()
            .CreatePlan()
            .ValidatePlanWasCreated(_testPlanModel);
        
        ScreenShotter.TakeScreenshot();
        
        ProjectsPageSteps
            .OpenSettingsPage()
            .DeleteProject()
            .ValidateProjectsPageIsOpened();
    }
}