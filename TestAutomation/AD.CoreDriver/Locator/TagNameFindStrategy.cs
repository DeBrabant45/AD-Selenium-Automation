using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class TagNameFindStrategy : FindStrategy
{
    public TagNameFindStrategy(string value) : base(value)
    {

    }

    public override By Convert() => By.TagName(Value);
}