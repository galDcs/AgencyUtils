using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetAgentLogin")]
public class OfranGetAgentLoginRequest
{
    [XmlElement(ElementName = "username")]
    public string Username { get; set; }

    [XmlElement(ElementName = "password")]
    public string Password { get; set; }

    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }

    public OfranGetAgentLoginRequest()
    {
    }
}