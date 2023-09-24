namespace AD.CoreDriver.WebElement;

public interface IElement
{
    string Text { get; }
    string Value { get; }
    bool? Enabled { get; }
    bool? Displayed { get; }
    bool? Selected { get; }
    void WaitToBeClickable();
    void WaitToExists();
    void WaitToBeVisible();
    void WaitToVanish();
    void WaitForStaleness();
}