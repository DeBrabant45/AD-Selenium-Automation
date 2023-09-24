using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class IdFindStrategy : FindStrategy
{
    public IdFindStrategy(string value) : base(value)
    {

    }

    public override By Convert() => By.Id(Value);
}