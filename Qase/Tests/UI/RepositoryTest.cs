using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Utilities;

namespace Qase.Tests.UI;

[AllureNUnit]
public class RepositoryTest : BaseTest
{
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Creation of New Test Case With Validations")]
    public void CreateTestCase()
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
        
        ScreenShotter.TakeScreenshot();
        
        ProjectsPageSteps
            .OpenSettingsPage()
            .DeleteProject()
            .ValidateProjectsPageIsOpened();
    }
}