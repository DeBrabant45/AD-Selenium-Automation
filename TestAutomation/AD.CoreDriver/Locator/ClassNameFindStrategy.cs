using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class ClassNameFindStrategy : FindStrategy
{
    public ClassNameFindStrategy(string value) : base(value)
    {

    }

    public override By Convert() => By.ClassName(Value);
}