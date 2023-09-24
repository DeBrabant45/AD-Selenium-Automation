using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AD.CoreDriver.WebElement;

public class ButtonElement : ElementBase
{
    public ButtonElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public void Click()
    {
        WaitToBeClickable();
        WebElement?.Click();
    }
}