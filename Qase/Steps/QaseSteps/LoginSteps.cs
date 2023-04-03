using FluentAssertions;
using NUnit.Allure.Attributes;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class LoginSteps : BaseStep
{
    private LoginPage LoginPage => new(Browser);
    private ProjectsPage ProjectsPage => new(Browser);
    
    public LoginSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Log in with {0} and {1}")]
    public LoginSteps InputData(string email, string password)
    {
        LoginPage
            .InputEmail(email)
            .InputPassword(password);

        return this;
    }

    [AllureStep("Login Button Click")]
    public LoginSteps LoginButtonClick()
    {
        LoginPage.SubmitButton();

        return this;
    }

    [AllureStep("Validate Page Is Opened")]
    public LoginSteps ValidateIsProjectsPageOpened()
    {
        ProjectsPage.IsPageOpened();

        return this;
    }

    [AllureStep("Validate Error Message")]
    public LoginSteps ValidateErrorMessage()
    {
        LoginPage.ErrorMessageDisplayed().Should().BeTrue();
        LoginPage.ErrorMessageText().Should().Be("These credentials do not match our records.");

        return this;
    }
}