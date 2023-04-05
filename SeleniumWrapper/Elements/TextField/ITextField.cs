namespace SeleniumWrapper.Elements.TextField;

public interface ITextField
{
    string GetText();

    void SendTextWithClear(string text);
    
    void SendText(string text);

    string GetValue();
}