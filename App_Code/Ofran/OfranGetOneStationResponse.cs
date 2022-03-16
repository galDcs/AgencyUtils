using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "Station")]
public class OfranGetOneStationResponse
{
    [XmlElement(ElementName = "StationId")]
    public string StationId { get; set; }
    [XmlElement(ElementName = "StationName")]
    public string StationName { get; set; }
    [XmlElement(ElementName = "Address")]
    public string Address { get; set; }
    [XmlElement(ElementName = "City")]
    public string City { get; set; }
    [XmlElement(ElementName = "State")]
    public string State { get; set; }
    [XmlElement(ElementName = "Zip")]
    public string Zip { get; set; }
    [XmlElement(ElementName = "Days")]
    public Days DaysField { get; set; }

    [XmlRoot(ElementName = "OpenHours")]
    public class OpenHours
    {
        [XmlElement(ElementName = "OpenHour")]
        public string OpenHour { get; set; }
    }

    [XmlRoot(ElementName = "Sunday")]
    public class Sunday : Day
    {
    }

    [XmlRoot(ElementName = "Monday")]
    public class Monday : Day
    {
    }

    [XmlRoot(ElementName = "Tuesday")]
    public class Tuesday : Day
    {
    }

    [XmlRoot(ElementName = "Wednesday")]
    public class Wednesday : Day
    {
    }

    [XmlRoot(ElementName = "Thursday")]
    public class Thursday : Day
    {
    }

    [XmlRoot(ElementName = "Friday")]
    public class Friday : Day
    {
    }

    [XmlRoot(ElementName = "Saturday")]
    public class Saturday : Day
    {       
    }

    [XmlRoot(ElementName = "Days")]
    public class Days
    {
        [XmlElement(ElementName = "Sunday")]
        public Sunday Sunday { get; set; }
        [XmlElement(ElementName = "Monday")]
        public Monday Monday { get; set; }
        [XmlElement(ElementName = "Tuesday")]
        public Tuesday Tuesday { get; set; }
        [XmlElement(ElementName = "Wednesday")]
        public Wednesday Wednesday { get; set; }
        [XmlElement(ElementName = "Thursday")]
        public Thursday Thursday { get; set; }
        [XmlElement(ElementName = "Friday")]
        public Friday Friday { get; set; }
        [XmlElement(ElementName = "Saturday")]
        public Saturday Saturday { get; set; }
    }

    public class Day
    {
        [XmlElement(ElementName = "OpenHours")]
        public OpenHours OpenHours { get; set; }
    }
}