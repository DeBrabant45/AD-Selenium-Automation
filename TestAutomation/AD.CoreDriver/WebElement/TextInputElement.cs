using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AD.CoreDriver.WebElement;

public class TextInputElement : InputElementBase<string>
{
    public TextInputElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public override void TypeInput(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            AddInput(input);
        }
    }
}