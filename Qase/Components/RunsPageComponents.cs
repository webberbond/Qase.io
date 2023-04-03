using OpenQA.Selenium;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class RunsPageComponents
{
    public readonly Button TestRunsButton = new(By.CssSelector("a[title='Test Runs']"), "Create New Run Button");
    
    public readonly Button StartNewTestRunButton = new(By.CssSelector(".UdZcu9"), "Create New Run Button");
    
    public readonly TextField TestRunDescriptionField = new(By.CssSelector(".ProseMirror.toastui-editor-contents"), "Test Run Description Field");
    
    public readonly Button AddTestsFromRepositoryButton = new(By.CssSelector("button[class='ZOc1sW']"), "Add Tests From Repository Button");

    public readonly Button TestCaseButton = new(By.CssSelector("div[id='suite-0'] p[class='suite-title']"), "Created test case button");

    public readonly Button TestCaseCheckboxButton = new(By.CssSelector("div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']"), "Created test case button");
   
    public readonly Button DoneButton = new(By.XPath("//span[normalize-space()='Done']"), "Done button");
    
    public readonly Button StartRunButton = new(By.CssSelector("button[type='submit'] span[class='UdZcu9']"), "Start A Run Button");
    
    public readonly Button CompleteConfirmButton = new(By.XPath("//span[normalize-space()='Complete']"), "Complete Confirm Button");

    public readonly Button CompleteRunButton = new(By.CssSelector("#complete-run-button"), "Complete Run Button");

    public readonly Button ShareReportButton = new(By.CssSelector("#share-report-button"), "Share Report Button");

    public readonly Button RunAgainButton = new(By.XPath("//button[normalize-space()='Run again']"), "Run Again button");
}