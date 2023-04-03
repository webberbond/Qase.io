using OpenQA.Selenium;
using SeleniumWrapper.Elements.Button;
using SeleniumWrapper.Elements.TextField;

namespace Qase.Components;

public class LoginPageComponents
{
    public readonly TextField EmailInputField = new(By.CssSelector("#inputEmail"), "Email field");
    
    public readonly TextField PasswordInputField = new(By.CssSelector("#inputPassword"), "Password field");

    public readonly Button SubmitButton = new(By.CssSelector("#btnLogin"), "Login button");

    public readonly TextField ErrorMessageField = new(By.CssSelector(".form-control-feedback"), "Error message");
}