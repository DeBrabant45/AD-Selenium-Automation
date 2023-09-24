using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class PTIDataFieldFindStrategy : FindStrategy
{
    private string _element;

    public PTIDataFieldFindStrategy(string element, string value) : base(value)
    {
        _element = element;
    }

    public override By Convert() => By.XPath($"//{_element}[@ptidatafld='{Value}']");
}