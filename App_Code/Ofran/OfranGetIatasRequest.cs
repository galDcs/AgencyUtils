using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetIatas")]
public class OfranGetIatasRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
}