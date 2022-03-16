using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "SessionCloseRQ")]
public class SabreSessionCloseRQRequest
{
    [XmlElement(ElementName = "POS")]
    public POSClass POS { get; set; }
    [XmlAttribute(AttributeName = "Version")]
    public string Version { get; set; }


    [XmlRoot(ElementName = "Source")]
    public class Source
    {
        [XmlAttribute(AttributeName = "PseudoCityCode")]
        public string PseudoCityCode { get; set; }
    }

    [XmlRoot(ElementName = "POS")]
    public class POSClass
    {
        [XmlElement(ElementName = "Source")]
        public Source Source { get; set; }
    }

}


