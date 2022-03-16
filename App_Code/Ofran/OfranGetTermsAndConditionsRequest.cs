using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetTermsAndConditions")]
public class OfranGetTermsAndConditionsRequest
{
    [XmlElement(ElementName = "lang")]
    public string Lang { get; set; }
    [XmlElement(ElementName = "destinationID")]
    public string DestinationID { get; set; }
}