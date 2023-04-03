namespace SeleniumWrapper.Elements.TextField;

public interface ITextField
{
    string GetText();

    void SendText(string text);

    string GetValue();
}