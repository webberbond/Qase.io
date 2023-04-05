using OpenQA.Selenium;
using SeleniumWrapper.Elements.Alert;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class DefectsPageComponents
{
    public readonly Alert Alert = new(By.CssSelector("[role='alert']"), "Alert");

    public readonly Button CreateDefectButton = new(By.CssSelector("button[type='submit']"), "Create defect");

    public readonly Button CreateNewDefectButton = new(By.CssSelector(".btn.btn-primary"), "Create New Defect");

    public readonly TextField DefectTitleInput = new(By.XPath("//input[@id='title']"), "Defect Title Input");
    
    public readonly TextField DefectActualResultInput = new(By.XPath("//input[@id='actual_result']"), "Defect Description Input");

    public readonly Button DefectsButton = new(By.CssSelector("a[title='Defects']"), "Defects button");
}