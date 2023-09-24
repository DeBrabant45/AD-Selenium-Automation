using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public abstract class FindStrategy
{
    protected FindStrategy(string value)
    {
        Value = value;
    }
    public string Value { get; }
    public abstract By Convert();
}