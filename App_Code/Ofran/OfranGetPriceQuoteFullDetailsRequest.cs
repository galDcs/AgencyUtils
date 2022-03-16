using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "GetPriceQuoteFullDetails")]
public class OfranGetPriceQuoteFullDetailsRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "code")]
    public string Code { get; set; }
    [XmlElement(ElementName = "languageCode")]
    public string LanguageCode { get; set; }
}
