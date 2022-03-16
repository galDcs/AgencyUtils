using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "Envelope")]
public class SabreResponse<T>
{
    [XmlElement(ElementName = "Body")]
    public T Body { get; set; }
}