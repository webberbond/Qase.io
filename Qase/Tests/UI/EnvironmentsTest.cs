using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.Settings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class EnvironmentsTest : EnvironmentTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Error Login Test With Validations")]
    public void EnvironmentCreationTest()
    {
        EnvironmentsPageSteps
            .CreateNewEnvironment()
            .InputInformation(TestEnvironmentModel)
            .SaveEnvironment();
        
        Assert.That(EnvironmentsPageSteps.GetEnvironmentTitle(), Is.EqualTo(TestEnvironmentModel.EnvironmentTitle), "Checking error message's text if credentials are wrong");
    }
}