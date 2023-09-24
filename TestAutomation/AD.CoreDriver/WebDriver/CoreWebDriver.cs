using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AD.CoreDriver.WebElement;
using AD.CoreDriver.Locator;

namespace AD.CoreDriver.WebDriver;

public class CoreWebDriver : IDriver
{
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;
    private ElementFinderService _elementFinderService;
    private readonly ElementFactory _elementFactory;

    public CoreWebDriver()
    {
        _elementFactory = new ElementFactory();
    }

    public void GoToUrl(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public void Quit()
    {
        _webDriver.Quit();
    }

    public void Start(Browser browser, List<string> browserOptions)
    {
        var webDriverfactory = new BrowserFactory();
        _webDriver = webDriverfactory.InitBrowser(browser, browserOptions);
        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        _elementFinderService = new ElementFinderService(_webDriverWait);
    }

    public void WaitForAjax()
    {
        var js = (IJavaScriptExecutor) _webDriver;
        _webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
    }

    public void WaitUntilPageLoadsCompletely()
    {
        var js = (IJavaScriptExecutor) _webDriver;
        _webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
    }

    public void SwitchToWindow(int window)
    {
        _webDriver.SwitchTo().Window(_webDriver.WindowHandles[window]);
    }

    public void CloseWindow(int window)
    {
        _webDriver.SwitchTo().Window(_webDriver.WindowHandles[window]).Close();
    }

    public void SwitchToIFrame(string frame)
    {
        _webDriver.SwitchTo().Frame(frame);
    }

    public void SwitchToDefaultContent()
    {
        _webDriver.SwitchTo().DefaultContent();
    }

    public void AcceptAlert()
    {
        _webDriver.SwitchTo().Alert().Accept();
    }

    public void DismissAlert()
    {
        _webDriver.SwitchTo().Alert().Dismiss();
    }
   
    public void SaveScreenShot(string filePath)
    {
        try
        {
            ((ITakesScreenshot) _webDriver).GetScreenshot().SaveAsFile(filePath);
            Console.WriteLine("Screenshot added to " + filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception while taking screenshot with " + filePath);
            Console.WriteLine(e.Message);
        }
    }

    public TElement Find<TElement>(FindStrategy findStrategy) where TElement : IElement
    {
        var nativeElement = _elementFinderService.Find(findStrategy);
        return _elementFactory.Create<TElement>(nativeElement, _webDriverWait, findStrategy.Convert());
    }

    public TElement FindElementById<TElement>(string id) where TElement : IElement
    {
        return Find<TElement>(new IdFindStrategy(id));
    }

    public TElement FindElementByAttribute<TElement>(string attribute, string value) where TElement : IElement
    {
        return Find<TElement>(new AttributeFindStrategy(attribute, value));
    }

    public TElement FindElementByXPath<TElement>(string xpath) where TElement : IElement
    {
        return Find<TElement>(new XPathFindStrategy(xpath));
    }

    public TElement FindElementByTag<TElement>(string tag) where TElement : IElement
    {
        return Find<TElement>(new TagNameFindStrategy(tag));
    }

    public TElement FindElementByClass<TElement>(string cssClass) where TElement : IElement
    {
        return Find<TElement>(new ClassNameFindStrategy(cssClass));
    }

    public TElement FindElementByLinkText<TElement>(string linkText) where TElement : IElement
    {
        return Find<TElement>(new LinkTextFindStrategy(linkText));
    }

    public TElement FindElementByCssSelector<TElement>(string css) where TElement : IElement
    {
        return Find<TElement>(new CssSelectorFindStrategy(css));
    }

    public TElement FindElementByPTIDataField<TElement>(string element, string dataField) where TElement : IElement
    {
        return Find<TElement>(new PTIDataFieldFindStrategy(element, dataField));
    }

    public TElement FindElementByAttributePTIDataRow<TElement>(string element, string attribute, int row) where TElement : IElement
    {
        return Find<TElement>(new PTIDataRowFindStrategy(element, attribute, row));
    }

    public List<TElement> FindAll<TElement>(FindStrategy findStrategy) where TElement : IElement
    {
        var nativeElements = _elementFinderService.FindAll(findStrategy);
        var resultElements = new List<TElement>();
        foreach (var nativeElement in nativeElements)
        {
            resultElements.Add(_elementFactory.Create<TElement>(nativeElement, _webDriverWait, findStrategy.Convert()));
        }

        return resultElements;
    }

    public List<TElement> FindAllElementsById<TElement>(string id) where TElement : IElement
    {
        return FindAll<TElement>(new IdFindStrategy(id));
    }

    public List<TElement> FindAllElementsByAttribute<TElement>(string attribute, string value) where TElement : IElement
    {
        return FindAll<TElement>(new AttributeFindStrategy(attribute, value));
    }

    public List<TElement> FindAllElementsByXPath<TElement>(string xpath) where TElement : IElement
    {
        return FindAll<TElement>(new XPathFindStrategy(xpath));
    }

    public List<TElement> FindAllElementsByTag<TElement>(string tag) where TElement : IElement
    {
        return FindAll<TElement>(new TagNameFindStrategy(tag));
    }

    public List<TElement> FindAllElementsByClass<TElement>(string cssClass) where TElement : IElement
    {
        return FindAll<TElement>(new ClassNameFindStrategy(cssClass));
    }

    public List<TElement> FindAllElementsByCssSelector<TElement>(string css) where TElement : IElement
    {
        return FindAll<TElement>(new CssSelectorFindStrategy(css));
    }

    public List<TElement> FindAllElementsByLinkText<TElement>(string linkText) where TElement : IElement
    {
        return FindAll<TElement>(new LinkTextFindStrategy(linkText));
    }

    public List<TElement> FindAllElementsByPTIDataField<TElement>(string element, string dataField) where TElement : IElement
    {
        return FindAll<TElement>(new PTIDataFieldFindStrategy(element, dataField));
    }

    public List<TElement> FindAllElementsByPTIDataField<TElement>(string element, string attribute, int row) where TElement : IElement
    {
        return FindAll<TElement>(new PTIDataRowFindStrategy(element, attribute, row));
    }
}