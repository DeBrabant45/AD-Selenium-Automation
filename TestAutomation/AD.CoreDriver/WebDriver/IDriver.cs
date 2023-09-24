using AD.CoreDriver.WebElement;

namespace AD.CoreDriver.WebDriver;

public interface IDriver : IBrowserService, INavigationService, IElementFindService, IWindowService, IScreenShot
{
   
}