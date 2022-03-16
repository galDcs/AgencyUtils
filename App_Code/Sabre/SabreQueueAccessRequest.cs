using System.Xml.Serialization;

[XmlRoot(ElementName = "QueueAccessRQ", Namespace = "http://webservices.sabre.com/sabreXML/2011/10")]
public class SabreQueueAccessRequest
{
    [XmlElement(ElementName = "Navigation")]
    public NavigationClass Navigation { get; set; }

    [XmlRoot(ElementName = "Navigation")]
    public class NavigationClass
    {
        [XmlAttribute(AttributeName = "Action")]
        public string Action { get; set; }
    }

    [XmlElement(ElementName = "QueueIdentifier")]
    public QueueIdentifier QueueIdentifierX { get; set; }
    [XmlAttribute(AttributeName = "ReturnHostCommand")]
    public string ReturnHostCommand { get; set; }
    [XmlAttribute(AttributeName = "Version")]
    public string Version { get; set; }

    [XmlRoot(ElementName = "QueueIdentifier")]
    public class QueueIdentifier
    {
        [XmlElement(ElementName = "List")]
        public List List { get; set; }
        [XmlAttribute(AttributeName = "Number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "PseudoCityCode")]
        public string PseudoCityCode { get; set; }
    }

    [XmlRoot(ElementName = "List")]
    public class List
    {
        [XmlAttribute(AttributeName = "Ind")]
        public string Ind { get; set; }

        [XmlAttribute(AttributeName = "PrimaryPassenger")]
        public string PrimaryPassenger { get; set; }
    }
}
