namespace SeleniumWrapper.Elements.Label;

public class Label : BaseElement, ILabel
{
    public Label(By locator, string name) : base(locator, name)
    {
    }

    public string GetValue()
    {
        Logger.Instance.Info($"Get value from {Name} label");
        return FindElement().GetAttribute("value");
    }

    public string GetText()
    {
        Logger.Instance.Info($"Get text from {Name} label");
        return FindElement().Text;
    }

    public string GetInnerHtml()
    {
        Logger.Instance.Info($"Get inner html from {Name} label");
        return FindElement().GetAttribute("innerHTML");
    }
}