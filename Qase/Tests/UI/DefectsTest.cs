using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.UISettings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class DefectsTest : DefectsTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Defects Test With Validations")]
    [AllureLink("Create Defect", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=1673022051")]
    public void CreateDefect()
    {
        DefectsPageSteps
            .OpenDefectsPage()
            .CreateNewDefect(DefectsModel);
        
        Assert.That(DefectsPageSteps.GetDefectTitle(), Is.EqualTo(DefectsModel.DefectTitle), "Checking if alert text is correct after creating a test defect.");
    }
}