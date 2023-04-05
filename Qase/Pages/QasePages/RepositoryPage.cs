using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class RepositoryPage : BasePage
{
    public RepositoryPage(Browser browser) : base(browser)
    {
    }
    
    protected override By UniqueWebLocator => By.XPath("//h1[@class='fGDnu0']");

    private static TestCasePageComponents TestCasePageComponents => new();

    public RepositoryPage ClickRepositoryButton()
    {
        TestCasePageComponents.RepositoryButton.Click();

        return this;
    }

    public RepositoryPage CreateNewTestCase()
    {
        TestCasePageComponents.CreateTestCaseButton.Click();

        return this;
    }

    public RepositoryPage InputTitle(string testCaseTitle)
    {
        TestCasePageComponents.TitleInput.SendText(testCaseTitle);

        return this;
    }

    public RepositoryPage InputDescription(string testCaseDescription)
    {
        TestCasePageComponents.DescriptionInput.SendText(testCaseDescription);

        return this;
    }

    public RepositoryPage InputPreConditions(string testCasePreConditions)
    {
        TestCasePageComponents.PreConditionsInput.SendText(testCasePreConditions);

        return this;
    }

    public RepositoryPage InputPostConditions(string testCasePostConditions)
    {
        TestCasePageComponents.PostConditionsInput.SendText(testCasePostConditions);

        return this;
    }

    public RepositoryPage ClickSaveTestCaseButton()
    {
        TestCasePageComponents.SaveTestCaseButton.Click();

        return this;
    }

    public static bool ValidateTestCaseCreated()
    {
        var contains = TestCasePageComponents.InfoField.GetText().Contains("1 test");

        return contains;
    }
}