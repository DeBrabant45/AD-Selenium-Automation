using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class AttributeFindStrategy : FindStrategy
{
    public AttributeFindStrategy(string attributeID, string value) : base(value)
    {
        AttributeID = attributeID;
    }

    public string AttributeID { get; }
    public override By Convert() => By.XPath(string.Format("//*[@{0} = '{1}']", AttributeID, Value));
}
