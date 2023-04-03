using SeleniumWrapper.Utils;

namespace Qase.Steps;

public abstract class BaseStep
{
    protected BaseStep(Browser browser)
    {
        Browser = browser;
    }

    protected Browser Browser { get; }
}