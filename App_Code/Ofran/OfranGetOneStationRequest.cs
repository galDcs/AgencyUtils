using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetOneStation")]
public class OfranGetOneStationRequest
{
    [XmlElement(ElementName = "stationID")]
    public string StationID { get; set; }
    [XmlElement(ElementName = "dropoffDate")]
    public string DropoffDate { get; set; }
}

