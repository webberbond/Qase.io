using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.Settings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class ProjectsTest : ProjectsTestSettings
{
    [Test]
    [Parallelizable]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Projects Test With Validations")]
    [AllureLink("Create Test Project", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=676356653")]
    public void TestProjectCreation()
    {
        ProjectsPageSteps
            .CreateNewProject()
            .InputInformation(TestProjectModel)
            .ClickSubmitButton()
            .OpenProjectSettings();
        
        Assert.Multiple(() =>
        {
            Assert.That(ProjectsPage.GetProjectName(), Is.EqualTo(TestProjectModel.ProjectName), "Checking if actual project name is equal to generated.");
            Assert.That(ProjectsPage.GetProjectCode(), Is.EqualTo(TestProjectModel.ProjectCode), "Checking if actual project code is equal to generated.");
            Assert.That(ProjectsPage.GetProjectDescription(), Is.EqualTo(TestProjectModel.ProjectDescription), "Checking if actual project description is equal to generated.");
        });
    }
}