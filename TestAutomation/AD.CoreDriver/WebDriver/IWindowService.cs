namespace AD.CoreDriver.WebDriver;

public interface IWindowService
{
    public void SwitchToWindow(int window);
    public void CloseWindow(int window);
    public void SwitchToIFrame(string frame);
    public void SwitchToDefaultContent();
    public void AcceptAlert();
    public void DismissAlert();
}