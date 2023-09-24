using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AD.CoreDriver.WebElement;

namespace AD.CoreDriver.WebDriver;

public class ElementFactory
{
    public TElement Create<TElement>(IWebElement webElement, WebDriverWait webDriverWait, By by) where TElement : IElement
    {
        return (TElement) Activator.CreateInstance(typeof(TElement), webElement, webDriverWait, by);
    }
}