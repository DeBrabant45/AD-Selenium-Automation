using System.Collections.Generic;
using AD.CoreDriver.Locator;
using AD.CoreDriver.WebElement;

namespace AD.CoreDriver.WebDriver;

public interface IElementFindService
{
    TElement Find<TElement>(FindStrategy findStrategy) where TElement : IElement;
    TElement FindElementByAttribute<TElement>(string attribute, string value) where TElement : IElement;
    TElement FindElementById<TElement>(string id) where TElement : IElement;
    TElement FindElementByXPath<TElement>(string xpath) where TElement : IElement;
    TElement FindElementByTag<TElement>(string tag) where TElement : IElement;
    TElement FindElementByClass<TElement>(string cssClass) where TElement : IElement;
    TElement FindElementByCssSelector<TElement>(string css) where TElement : IElement;
    TElement FindElementByLinkText<TElement>(string linkText) where TElement : IElement;
    TElement FindElementByPTIDataField<TElement>(string element, string dataField) where TElement : IElement;
    TElement FindElementByAttributePTIDataRow<TElement>(string element, string attribute, int row) where TElement : IElement;

    List<TElement> FindAll<TElement>(FindStrategy findStrategy) where TElement : IElement;
    List<TElement> FindAllElementsById<TElement>(string id) where TElement : IElement;
    List<TElement> FindAllElementsByAttribute<TElement>(string attribute, string value) where TElement : IElement;
    List<TElement> FindAllElementsByXPath<TElement>(string xpath) where TElement : IElement;
    List<TElement> FindAllElementsByTag<TElement>(string tag) where TElement : IElement;
    List<TElement> FindAllElementsByClass<TElement>(string cssClass) where TElement : IElement;
    List<TElement> FindAllElementsByCssSelector<TElement>(string css) where TElement : IElement;
    List<TElement> FindAllElementsByLinkText<TElement>(string linkText) where TElement : IElement;
    List<TElement> FindAllElementsByPTIDataField<TElement>(string element, string dataField) where TElement : IElement;
    List<TElement> FindAllElementsByPTIDataField<TElement>(string element, string attribute, int row) where TElement : IElement;
}