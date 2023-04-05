using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Utilities;

namespace Qase.Tests.UI;

[AllureNUnit]
public class ProjectsTest : BaseTest
{
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();
    private readonly TestProjectModel _testProjectModelToUpdate = new TestProjectModelDataFaker().Generate();

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Projects Test With Validations")]
    [AllureLink("Create Test Project", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=676356653")]
    public void TestProjectCreationUpdationDeletion()
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
            .ValidateProjectsPageIsOpened()
            .CreateNewProject()
            .InputData(_testProjectModel)
            .ClickSubmitButton()
            .ValidateDetails(_testProjectModel)
            .UpdateProject(_testProjectModelToUpdate)
            .ValidateProjectWasUpdated()
            .ValidateDetails(_testProjectModelToUpdate)
            .DeleteProject()
            .ValidateProjectsPageIsOpened();
        
        ScreenShotter.TakeScreenshot();
    }
}