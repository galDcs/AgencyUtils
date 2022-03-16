using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetPrebooks")]
public class OfranGetPrebooksRequest
{
    [XmlElement(ElementName = "subContractID")]
    public string SubContractId { get; set; }
    [XmlElement(ElementName = "languageCode")]
    public string LanguageCode { get; set; }
}