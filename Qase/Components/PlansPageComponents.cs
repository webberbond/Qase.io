using OpenQA.Selenium;
using SeleniumWrapper.Elements.Alert;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class PlansPageComponents
{
    public readonly Alert Alert = new(By.CssSelector("[role='alert']"), "Alert message");
    
    public readonly Button TestPlanButton = new(By.CssSelector("a[title='Test Plans']"), "Test Plan");
    
    public readonly Button CreatePlanButton = new(By.XPath("//div[@class='k7tMJI']//a[@id='createButton']"), "Create Plan");
    
    public readonly TextField TitleInput = new(By.CssSelector("#title"), "Title Input");
    
    public readonly TextField DescriptionInput = new(By.CssSelector(".ProseMirror.toastui-editor-contents"), "Description Input");
    
    public readonly Button AddCasesButton = new(By.CssSelector("#edit-plan-add-cases-button"), "Add cases button");
    
    public readonly Button CreatedTestCaseButton = new(By.CssSelector("div[id='suite-0'] p[class='suite-title']"), "Created test case button");

    public readonly Button CreatedTestCaseCheckboxButton = new(By.CssSelector("div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']"), "Created test case button");
    
    public readonly Button DoneButton = new(By.CssSelector("button[class='LzLtDS tscvgR MBIQEc'] span[class='UdZcu9']"), "Done button");

    public readonly Button SubmitPlanButton = new(By.CssSelector("#save-plan"), "Submit Plan");
}