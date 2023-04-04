namespace SeleniumWrapper.Elements.Alert;

public interface IAlert
{
    void WaitToDissappear(Alert alert);

    string AlertText();

    void WaitUntilCloses();
}