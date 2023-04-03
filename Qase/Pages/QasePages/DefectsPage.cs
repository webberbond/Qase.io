using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class DefectsPage : BasePage
{
    public DefectsPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Defects']");

    private static DefectsPageComponents DefectsPageComponents => new();

    public DefectsPage OpenDefects()
    {
        DefectsPageComponents.DefectsButton.Click();

        return this;
    }

    public DefectsPage NewDefectButtonClick()
    {
        DefectsPageComponents.CreateNewDefectButton.Click();

        return this;
    }

    public DefectsPage InputDefectTitle(string defectTitle)
    {
        DefectsPageComponents.DefectTitleInput.SendText(defectTitle);

        return this;
    }

    public DefectsPage InputDefectActualResult(string defectActualResult)
    {
        DefectsPageComponents.DefectActualResultInput.SendText(defectActualResult);

        return this;
    }

    public DefectsPage ClickCreateDefectButton()
    {
        DefectsPageComponents.CreateDefectButton.Click();

        return this;
    }

    public static bool AlertDisplayed()
    {
        return DefectsPageComponents.Alert.IsDisplayed();
    }

    public static string AlertMessage()
    {
        return DefectsPageComponents.Alert.AlertText();
    }
}