namespace SeleniumWrapper.Elements.TextField;

public class TextField : BaseElement, ITextField
{
    public TextField(By locator, string name) : base(locator, name)
    {
    }

    public string GetText()
    {
        Logger.Instance.Info($"Take text from {Name} text field");
        return FindElement().Text;
    }

    public void SendText(string text)
    {
        Logger.Instance.Info($"Clear {Name} text field");
        ClearField();

        Logger.Instance.Info($"Sending keys {Name} text field");
        FindElement().SendKeys(text);
    }

    public string GetValue()
    {
        Logger.Instance.Info($"Get value from {Name} text field");
        return FindElement().GetAttribute("value");
    }
}