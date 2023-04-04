using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Utilities;

namespace Qase.Tests.UI;

[AllureNUnit]
public class DefectsTest : BaseTest
{
    private readonly DefectsModel _defectsModel = new DefectsModelDataFaker().Generate();
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Defects Test With Validations")]
    public void CreateDefect()
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
            .ValidateDetails(_testProjectModel);

        DefectsPageSteps
            .OpenDefectsPage()
            .ValidateIsDefectsPageOpened()
            .CreateNewDefect()
            .InputData(_defectsModel)
            .SubmitDefect()
            .ValidateDefectWasCreated();
        
        ScreenShotter.TakeScreenshot();
        
        ProjectsPageSteps
            .OpenSettingsPage()
            .DeleteProject()
            .ValidateProjectsPageIsOpened();
    }
}