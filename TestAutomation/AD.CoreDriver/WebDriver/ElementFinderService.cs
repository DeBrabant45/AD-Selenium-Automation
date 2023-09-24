using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using AD.CoreDriver.Locator;
using SeleniumExtras.WaitHelpers;

namespace AD.CoreDriver.WebDriver;

public class ElementFinderService 
{
    private readonly WebDriverWait _driverWait;

    public ElementFinderService(WebDriverWait driverWait)
    {
        _driverWait = driverWait;
    }

    public IWebElement Find(FindStrategy findStrategy)
    {
        IWebElement element = _driverWait.Until(ExpectedConditions.ElementExists(findStrategy.Convert()));
        return element;
    }

    public IEnumerable<IWebElement> FindAll(FindStrategy findStrategy)
    {
        IEnumerable<IWebElement> results = 
            _driverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(findStrategy.Convert()));

        return results;
    }
}