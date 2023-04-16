using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.Settings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class RunsTest : RunsTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Creation of New Test Run With Validations")]
    [AllureLink("Create Test Run", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=856280847")]
    public void CreateTestRun()
    {
        RunsPageSteps
            .CreateNewTestRun()
            .InputInformation(TestRunModel)
            .AddTestsFromRepository()
            .StartTestRun()
            .CompleteTestRun();

        Assert.That(RunsPage.IsShareReportButtonDisplayed, Is.True, "Checking that the button 'Share Report' is displayed after creating a test run.");
    }
}