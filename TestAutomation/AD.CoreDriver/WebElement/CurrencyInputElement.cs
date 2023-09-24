using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace AD.CoreDriver.WebElement;

public class CurrencyInputElement : InputElementBase<decimal?>
{
    public CurrencyInputElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public decimal ValueToDecimal()
    {
        return ConvertStringToDecimal(Value);
    }

    public decimal TextToDecimal()
    {
        return ConvertStringToDecimal(Text);
    }

    private decimal ConvertStringToDecimal(string text)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            var isNegative = false;
            if (text.Contains("("))
            {
                isNegative = true;
            }
            var newText = Regex.Replace(text, "[^0-9.]", "");
            var amount = Convert.ToDecimal(newText);
            return (isNegative) ? -amount : amount;
        }
        throw new Exception("Trying to convert an empty/null text to decimal");
    }

    public override void TypeInput(decimal? input)
    {
        if (input.HasValue)
        {
            AddInput(input.ToString());
        }
    }
}