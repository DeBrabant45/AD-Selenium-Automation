using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AD.CoreDriver.WebElement;

public class DateInputElement : InputElementBase<DateTime?>
{
    public DateInputElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public DateTime DateValue => DateTime.Parse(Value);
    public DateTime DateText => DateTime.Parse(Text);

    public override void TypeInput(DateTime? input)
    {
        if (input.HasValue && input != DateTime.MinValue)
        {
            AddInput(input?.ToShortDateString());
        }
    }
}