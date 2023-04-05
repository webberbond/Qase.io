using OpenQA.Selenium;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class PlansPageComponents
{
    public readonly TextField TestPlanTitle = new(By.XPath("//a[@class='defect-title']"), "Test Plan Title");
    
    public readonly Button TestPlanButton = new(By.CssSelector("a[title='Test Plans']"), "Test Plan");
    
    public readonly Button CreatePlanButton = new(By.XPath("(//a[@id='createButton'])[1]"), "Create Plan");
    
    public readonly TextField TitleInput = new(By.XPath("//input[@id='title']"), "Title Input");
    
    public readonly TextField DescriptionInput = new(By.XPath("//input[@type='text']"), "Description Input");
    
    public readonly Button AddCasesButton = new(By.CssSelector("#edit-plan-add-cases-button"), "Add cases button");
    
    public readonly Button CreatedTestCaseButton = new(By.CssSelector("div[id='suite-0'] p[class='suite-title']"), "Created test case button");

    public readonly Button CreatedTestCaseCheckboxButton = new(By.CssSelector("div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']"), "Created test case button");
    
    public readonly Button DoneButton = new(By.XPath("//span[normalize-space()='Done']"), "Done button");

    public readonly Button SubmitPlanButton = new(By.CssSelector("#save-plan"), "Submit Plan");
}