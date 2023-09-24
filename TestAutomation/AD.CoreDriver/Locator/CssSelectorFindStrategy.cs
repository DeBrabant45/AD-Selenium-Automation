using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class CssSelectorFindStrategy : FindStrategy
{
    public CssSelectorFindStrategy(string value) : base(value)
    {

    }

    public override By Convert() => By.CssSelector(Value);
}