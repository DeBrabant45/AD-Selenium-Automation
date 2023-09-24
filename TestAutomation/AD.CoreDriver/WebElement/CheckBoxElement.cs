using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AD.CoreDriver.WebElement;

public class CheckBoxElement : ElementBase
{
    public CheckBoxElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public void ClickCheck()
    {
        if (Selected == false)
        {
            Click();
        }
    }

    public void ClickUncheck()
    {
        if (Selected == true)
        {
            Click();
        }
    }

    private void Click()
    {
        WaitToBeClickable();
        WebElement?.Click();
    }
}
