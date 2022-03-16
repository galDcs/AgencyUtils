using System.Xml.Serialization;

[XmlRoot(ElementName = "GetReservationRQ", Namespace = "http://webservices.sabre.com/pnrbuilder/v1_19")]
public class SabreGetReservationRQ
{
    [XmlElement(ElementName = "Locator")]
    public string Locator { get; set; }
    [XmlElement(ElementName = "RequestType")]
    public string RequestType { get; set; }
    [XmlElement(ElementName = "ReturnOptions")]
    public ReturnOptions ReturnOptionsX { get; set; }

    [XmlAttribute(AttributeName = "Version")]
    public string Version { get; set; }

    [XmlRoot(ElementName = "SubjectAreas")]
    public class SubjectAreas
    {
        [XmlElement(ElementName = "SubjectArea")]
        public string SubjectArea { get; set; }
    }

    [XmlRoot(ElementName = "ReturnOptions")]
    public class ReturnOptions
    {
        [XmlElement(ElementName = "SubjectAreas")]
        public SubjectAreas SubjectAreas { get; set; }
        [XmlElement(ElementName = "ViewName")]
        public string ViewName { get; set; }
        [XmlElement(ElementName = "ResponseFormat")]
        public string ResponseFormat { get; set; }
        [XmlAttribute(AttributeName = "PriceQuoteServiceVersion")]
        public string PriceQuoteServiceVersion { get; set; }
    }
}


