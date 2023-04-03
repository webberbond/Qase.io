namespace SeleniumWrapper.Elements.Alert;

public class Alert : BaseElement, IAlert
{
    public Alert(By locator, string name) : base(locator, name)
    {
    }

    public void WaitToDissappear(Alert alert)
    {
        Wait.Until(_ => FindElement().Displayed == false);
    }

    public string AlertText()
    {
        return FindElement().Text;
    }
}