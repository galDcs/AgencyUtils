using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "AgentLogin")]
public class OfranGetAgentLoginResponse
{
    [XmlElement(ElementName = "Success")]
    public bool Success { get; set; }

    [XmlElement(ElementName = "Uniquserid")]
    public string Uniquserid { get; set; }

    [XmlElement(ElementName = "FirstName")]
    public string FirstName { get; set; }

    [XmlElement(ElementName = "LastName")]
    public string LastName { get; set; }

    [XmlElement(ElementName = "AgencyName")]
    public string AgencyName { get; set; }

    [XmlElement(ElementName = "AgencyPaymentType")]
    public string AgencyPaymentType { get; set; }

}