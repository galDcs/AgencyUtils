using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "PriceQuote")]
public class OfranCreatePriceQuoteResponse
{
    [XmlElement(ElementName = "PriceQuoteNo")]
    public string PriceQuoteNo { get; set; }
    [XmlElement(ElementName = "Code")]
    public string Code { get; set; }
    [XmlElement(ElementName = "Successful")]
    public bool Successful { get; set; }
    [XmlElement(ElementName = "FailureReason")]
    public string FailureReason { get; set; }
}