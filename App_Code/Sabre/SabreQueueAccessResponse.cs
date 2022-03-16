using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

public class SabreQueueAccessResponse
{
    [XmlElement(ElementName = "QueueAccessRS")]
    public QueueAccessRS QueueAccess { get; set; }

    [XmlRoot(ElementName = "QueueAccessRS")]
    public class QueueAccessRS
    {
        public ApplicationResultsClass ApplicationResults { get; set; }
        [XmlElement(ElementName = "Line")]
        public List<LineClass> Line { get; set; }
        public ParagraphClass Paragraph { get; set; }
    }

    [XmlRoot(ElementName = "HostCommand")]
    public class HostCommand
    {
        [XmlAttribute(AttributeName = "LNIATA")]
        public string LNIATA { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SystemSpecificResults")]
    public class SystemSpecificResults
    {
        [XmlElement(ElementName = "HostCommand")]
        public HostCommand HostCommand { get; set; }
    }

    [XmlRoot(ElementName = "Success")]
    public class Success
    {
        [XmlElement(ElementName = "SystemSpecificResults")]
        public SystemSpecificResults SystemSpecificResults { get; set; }
        [XmlAttribute(AttributeName = "timeStamp")]
        public string TimeStamp { get; set; }
    }

    [XmlRoot(ElementName = "ApplicationResults")]
    public class ApplicationResultsClass
    {
        [XmlElement(ElementName = "Success")]
        public Success Success { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

    [XmlRoot(ElementName = "Source")]
    public class Source
    {
        [XmlAttribute(AttributeName = "AgentSine")]
        public string AgentSine { get; set; }
        [XmlAttribute(AttributeName = "PseudoCityCode")]
        public string PseudoCityCode { get; set; }
    }

    [XmlRoot(ElementName = "POS")]
    public class POS
    {
        [XmlElement(ElementName = "Source")]
        public Source Source { get; set; }
    }

    [XmlRoot(ElementName = "UniqueID")]
    public class UniqueID
    {
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
    }

    [XmlRoot(ElementName = "Line")]
    public class LineClass
    {
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }
        [XmlElement(ElementName = "PassengerName")]
        public string PassengerName { get; set; }
        [XmlElement(ElementName = "POS")]
        public POS POS { get; set; }
        [XmlElement(ElementName = "UniqueID")]
        public UniqueID UniqueID { get; set; }
        [XmlAttribute(AttributeName = "Number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "Paragraph")]
    public class ParagraphClass
    {
        [XmlElement(ElementName = "Text")]
        public List<string> Text { get; set; }
    }
}