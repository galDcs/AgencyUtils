using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "Stations")]
public class OfranGetStationsListResponse
{
    [XmlElement(ElementName = "PickupStationOptions")]
    public PickupStationOptions mPickupStationOptions { get; set; }
    [XmlElement(ElementName = "DropOffStationOptions")]
    public DropOffStationOptions mDropOffStationOptions { get; set; }

    [XmlRoot(ElementName = "PickupStation")]
    public class PickupStation
    {
        [XmlElement(ElementName = "stationId")]
        public string StationId { get; set; }
        [XmlElement(ElementName = "stationName")]
        public string StationName { get; set; }
    }

    [XmlRoot(ElementName = "PickupStationOptions")]
    public class PickupStationOptions
    {
        [XmlElement(ElementName = "PickupStation")]
        public List<PickupStation> PickupStation { get; set; }
    }

    [XmlRoot(ElementName = "DropOffStation")]
    public class DropOffStation
    {
        [XmlElement(ElementName = "stationId")]
        public string StationId { get; set; }
        [XmlElement(ElementName = "stationName")]
        public string StationName { get; set; }
    }

    [XmlRoot(ElementName = "DropOffStationOptions")]
    public class DropOffStationOptions
    {
        [XmlElement(ElementName = "DropOffStation")]
        public List<DropOffStation> DropOffStation { get; set; }
    }

}


