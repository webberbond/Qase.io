using SeleniumExtras.WaitHelpers;

namespace SeleniumWrapper.Elements.Alert;

public class Alert : BaseElement, IAlert
{
    public Alert(By locator, string name) : base(locator, name)
    {
    }

    public void WaitToDissappear(Alert alert)
    {
        Logger.Instance.Info("Waiting to disappear");
        Wait.Until(_ => !IsDisplayed());
    }

    public string AlertText()
    {
        Logger.Instance.Info("Get alert text");
        return FindElement().Text;
    }
    
    public void WaitUntilCloses()
    {
        Logger.Instance.Info($"Wait until alert closes");
        Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[role='alert']")));
    }
}