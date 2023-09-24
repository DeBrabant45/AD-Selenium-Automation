using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AD.CoreDriver.WebElement;

public abstract class InputElementBase<T> : ElementBase
{
    protected InputElementBase(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public abstract void TypeInput(T? input);

    protected void AddInput(string input)
    {
        WaitToBeVisible();
        WaitToBeClickable();
        WebElement?.Click();
        WebElement?.Clear();
        WebElement?.SendKeys(input);
        WebElement?.SendKeys(Keys.Tab);
    }
}
