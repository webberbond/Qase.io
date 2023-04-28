using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class EnvironmentsPageSteps
{
    private readonly EnvironmentsPage _environmentsPage;
    
    public EnvironmentsPageSteps(IWebDriver webDriver) 
    {
        _environmentsPage = new EnvironmentsPage(webDriver);
    }
    
    [AllureStep("Create New Environment")]
    public EnvironmentsPageSteps CreateNewEnvironment()
    {
        _environmentsPage
            .OpenTestEnvironment()
            .CreateNewEnvironmentButtonClick();
        
        return this;
    }
    
    [AllureStep("Input Information")]
    public EnvironmentsPageSteps InputInformation(TestEnvironmentModel testEnvironment)
    {
        _environmentsPage
            .InputEnvironmentTitle(testEnvironment.EnvironmentTitle)
            .InputEnvironmentSlug(testEnvironment.EnvironmentSlug)
            .InputEnvironmentDescription(testEnvironment.EnvironmentDescription)
            .InputEnvironmentHost(testEnvironment.EnvironmentHost);
        
        return this;
    }
    
    [AllureStep("Save Environment")]
    public EnvironmentsPageSteps SaveEnvironment()
    {
        _environmentsPage.SaveTestEnvironment();
        
        return this;
    }
    
    [AllureStep("Get Environment Title")]
    public string GetEnvironmentTitle()
    {
        return _environmentsPage.GetEnvironmentTitle();
    }
}