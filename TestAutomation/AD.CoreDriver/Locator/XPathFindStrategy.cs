using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class XPathFindStrategy : FindStrategy
{
    public XPathFindStrategy(string value) : base(value)
    {

    }

    public override By Convert() => By.XPath(Value);
}