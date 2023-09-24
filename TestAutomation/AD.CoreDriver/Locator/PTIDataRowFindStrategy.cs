using OpenQA.Selenium;

namespace AD.CoreDriver.Locator;

public class PTIDataRowFindStrategy : FindStrategy
{
    private string _attribute;
    private string _row;

    public PTIDataRowFindStrategy(string value, string attribute, int row) : 
        base(value)
    {
        _attribute = attribute;
        _row = row.ToString();
    }

    public override By Convert() => By.XPath($"//{Value}[@{_attribute} and @ptidatarow='{_row}']");
}