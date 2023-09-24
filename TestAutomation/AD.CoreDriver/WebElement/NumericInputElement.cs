using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AD.CoreDriver.WebElement;

public class NumericInputElement : InputElementBase<int?>
{
    public NumericInputElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {
    }

    public override void TypeInput(int? input)
    {
        if (input.HasValue)
        {
            AddInput(input.ToString());
        }
    }

    public int ValueToInt() => ConvertStringToInt(Value);

    public int TextToInt() => ConvertStringToInt(Text);

    public int ConvertStringToInt(string text)
    {
        if (!int.TryParse(text, out int value))
        {
            throw new Exception("Trying to convert an empty/null text to Int");
        }
        return value;
    }
}