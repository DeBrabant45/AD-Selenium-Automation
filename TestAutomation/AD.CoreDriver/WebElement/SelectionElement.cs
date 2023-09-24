using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AD.CoreDriver.WebElement;

public class SelectionElement : ElementBase
{
    public SelectionElement(IWebElement webElement, WebDriverWait webDriverWait, By by) : 
        base(webElement, webDriverWait, by)
    {

    }

    public void SelectByValue(string option)
    {
        CreateSelectElement().SelectByValue(option);
    }

    public void SelectByText(string option)
    {
        CreateSelectElement().SelectByText(option);
    }

    private SelectElement CreateSelectElement()
    {
        WaitToBeClickable();
        return new SelectElement(WebElement);
    }
}
