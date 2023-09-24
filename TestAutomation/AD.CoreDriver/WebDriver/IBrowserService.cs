using System.Collections.Generic;

namespace AD.CoreDriver.WebDriver;

public interface IBrowserService
{
    public void WaitForAjax();
    public void WaitUntilPageLoadsCompletely();
    public void Start(Browser browser, List<string> browserOptions);
    public void Quit();
}