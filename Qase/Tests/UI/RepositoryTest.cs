using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.Settings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class RepositoryTest : RepositoryTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Creation of New Test Case With Validations")]
    [AllureLink("Create Test Case", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=1138196004")]
    public void CreateNewTestCase()
    {
        Assert.That(RepositoryPageSteps.GetAlertText(), Is.EqualTo("Test case was created successfully!"), "Checking if alert text is correct after creating a test case.");
    }
}