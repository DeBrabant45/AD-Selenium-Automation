using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AD.CoreDriver.WebElement;

public abstract class ElementBase : IElement
{
    protected IWebElement WebElement;
    protected WebDriverWait WebDriverWait;
    protected readonly By By;

    protected ElementBase(IWebElement webElement, WebDriverWait webDriverWait, By by)
    {
        WebElement = webElement;
        WebDriverWait = webDriverWait;
        By = by;
    }

    public string Text => WebElement?.Text;

    public string Value => WebElement?.GetAttribute("value");

    public bool? Enabled => WebElement?.Enabled;

    public bool? Displayed => WebElement?.Displayed;

    public bool? Selected => WebElement?.Selected;

    public void WaitToBeClickable() => WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(By));

    public void WaitToExists() => WebDriverWait.Until(ExpectedConditions.ElementExists(By));

    public void WaitToBeVisible() => WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By));

    public void WaitToVanish() => WebDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By));

    public void WaitForStaleness() => WebDriverWait.Until(ExpectedConditions.StalenessOf(WebElement));
}