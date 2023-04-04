namespace SeleniumWrapper.Elements.Button;

public class Button : BaseElement, IButton
{
    public Button(By locator, string name) : base(locator, name)
    {
    }

    public void Click()
    {
        Logger.Instance.Info($"Click {Name} button");
        FindElement().Click();
    }
}