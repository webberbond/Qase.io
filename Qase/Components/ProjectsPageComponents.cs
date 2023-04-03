using OpenQA.Selenium;
using SeleniumWrapper.Elements.Alert;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class ProjectsPageComponents
{
    public readonly Alert Alert = new(By.CssSelector("[role='alert']"), "Alert message");

    public readonly Button CreateProjectButton = new(By.CssSelector("#createButton"), "Create project button");
   
    public readonly TextField ProjectNameInput = new(By.CssSelector("#project-name"), "Project name input");
   
    public readonly TextField ProjectCodeInput = new(By.CssSelector("#project-code"), "Project code input");
    
    public readonly TextField ProjectDescriptionInput = new(By.CssSelector("#description-area"), "Project description input");

    public readonly Button CreateProjectSubmitButton = new(By.XPath("//span[normalize-space()='Create project']"), "Create project submit button");
   
    public readonly Button ConfirmDeleteProjectButton = new(By.XPath("//button[@type='button']//span[@class='UdZcu9'][normalize-space()='Delete project']"), "Confirm delete project button");
    
    public readonly Button ProjectSettingsButton = new(By.XPath("//span[normalize-space()='Settings']"), "Project settings button");
    
    public readonly Button UpdateProjectSettingsButton = new(By.CssSelector("button[type='submit'] span[class='UdZcu9']"), "Update project settings button");

    public readonly Button DeleteProjectButton = new(By.XPath("//span[normalize-space()='Delete project']"), "Delete project button");
}