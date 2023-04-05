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

    public void SendTextWithClear(string text)
    {
        Logger.Instance.Info($"Clear {Name} text field");
        ClearField();
        WaitUntilFieldIsEmpty();

        Logger.Instance.Info($"Sending keys {Name} text field");
        FindElement().SendKeys(text);
    }

    public void SendText(string text)
    {
        Logger.Instance.Info($"Sending keys {Name} text field");
        FindElement().SendKeys(text);
    }
    
    public string GetValue()
    {
        Logger.Instance.Info($"Get value from {Name} text field");
        return FindElement().GetAttribute("value");
    }

    private void WaitUntilFieldIsEmpty()
    { 
        Logger.Instance.Info($"Wait until {Name} text field is empty");
        Wait.Until(_ => string.IsNullOrEmpty(GetValue()));
    }

    public void SendTextWithActions(string text)
    {
        Logger.Instance.Info($"Sending keys {Name} text field");
        Actions.Click().SendKeys(text).Build().Perform();
    }
}