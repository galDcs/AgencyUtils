using System.Xml.Serialization;

[XmlRoot(ElementName = "SessionCloseRS", Namespace = "http://www.opentravel.org/OTA/2002/11")]
public class SabreSessionCloseRSResponse
{
    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }
    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }
    [XmlAttribute(AttributeName = "status")]
    public string Status { get; set; }
}


