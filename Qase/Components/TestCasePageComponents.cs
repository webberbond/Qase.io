using OpenQA.Selenium;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class TestCasePageComponents
{
    public readonly Button RepositoryButton = new(By.CssSelector("a[title='Repository']"), "Repository button");
    
    public readonly Button CreateTestCaseButton = new(By.CssSelector("#create-case-button"), "Create test case button");
   
    public readonly TextField TitleInput = new(By.CssSelector("#title"), "Title input");

    public readonly TextField DescriptionInput = new(By.CssSelector("div[class='col-12 form-group'] div[class='ProseMirror toastui-editor-contents']"), "Description input");

    public readonly TextField PreConditionsInput = new(By.XPath("(//div[@class='ProseMirror toastui-editor-contents'])[2]"), "Preconditions input");
    
    public readonly TextField PostConditionsInput = new(By.XPath("(//div[@contenteditable='true'])[6]"), "Postconditions input");

    public readonly Button SaveTestCaseButton = new(By.CssSelector("button[id='save-case'] span[class='UdZcu9']"), "Save test case button");

    public readonly TextField InfoField = new(By.CssSelector(".zttQ3P"), "Info field");
}