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

    public readonly TextField DefectActualResultInput = new(By.CssSelector(".ProseMirror.toastui-editor-contents"), "Defect Description Input");

    public readonly Button DefectsButton = new(By.CssSelector("a[title='Defects'] span[class='nbWgel']"), "Defects button");

    public readonly TextField DefectTitleInput = new(By.CssSelector("#title"), "Defect Title Input");
}