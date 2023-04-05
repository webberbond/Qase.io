using OpenQA.Selenium;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class TestCasePageComponents
{
    public readonly Button RepositoryButton = new(By.CssSelector("a[title='Repository']"), "Repository button");
    
    public readonly Button CreateTestCaseButton = new(By.CssSelector("#create-case-button"), "Create test case button");
   
    public readonly TextField TitleInput = new(By.CssSelector("#title"), "Title input");

    public readonly TextField DescriptionInput = new(By.XPath("//input[@id='0-description']"), "Description input");

    public readonly TextField PreConditionsInput = new(By.XPath("//input[@id='0-preconditions']"), "Preconditions input");
    
    public readonly TextField PostConditionsInput = new(By.XPath("//input[@id='0-postconditions']"), "Postconditions input");

    public readonly Button SaveTestCaseButton = new(By.CssSelector("button[id='save-case']"), "Save test case button");

    public readonly TextField InfoField = new(By.CssSelector(".o0Jd8j"), "Info field");
}