using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;

namespace AD.CoreDriver.WebDriver;

public class BrowserFactory
{
    public IWebDriver InitBrowser(Browser browser, List<string> browserOptions)
    {
        switch (browser)
        {
            case Browser.Chrome:
                return CreateChromeDriver(browserOptions);
            case Browser.Firefox:
                return CreateFireFoxDriver(browserOptions);
            case Browser.Edge:
                return CreateEdgeDriver(browserOptions);
            case Browser.Opera:
                return CreateOperaDriver(browserOptions);
            case Browser.Safari:
                return CreateSafariDriver();
            case Browser.InternetExplorer:
                return CreateInternetExplorerDriver();
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }
    }

    private IWebDriver CreateChromeDriver(List<string> browserOptions)
    {
        var chromeOptions = new ChromeOptions();
        browserOptions.ForEach(options =>
        {
            if (!string.IsNullOrEmpty(options))
            {
                chromeOptions.AddArguments(options);
            }
        });
        chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
        return new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
    }

    private IWebDriver CreateOperaDriver(List<string> browserOptions)
    {
        var operaOptions = new OperaOptions();
        browserOptions.ForEach(options =>
        {
            if (!string.IsNullOrEmpty(options))
            {
                operaOptions.AddArguments(options);
            }
        });
        return new OperaDriver(Environment.CurrentDirectory);
    }

    private IWebDriver CreateEdgeDriver(List<string> browserOptions)
    {
        var edgeOptions = new EdgeOptions();
        browserOptions.ForEach(options =>
        {
            if (!string.IsNullOrEmpty(options))
            {
                edgeOptions.AddArguments(options);
            }
        });
        return new EdgeDriver(Environment.CurrentDirectory);
    }

    private IWebDriver CreateFireFoxDriver(List<string> browserOptions)
    {
        var fireFoxOptions = new FirefoxOptions();
        browserOptions.ForEach(options =>
        {
            if (!string.IsNullOrEmpty(options))
            {
                fireFoxOptions.AddArguments(options);
            }
        });
        return new FirefoxDriver(Environment.CurrentDirectory);
    }

    private IWebDriver CreateInternetExplorerDriver()
    {
        return new InternetExplorerDriver(Environment.CurrentDirectory);
    }

    private IWebDriver CreateSafariDriver()
    {
        return new SafariDriver(Environment.CurrentDirectory);
    }
}
