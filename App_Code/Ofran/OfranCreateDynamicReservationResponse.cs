using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "Reservation")]
    public class OfranCreateDynamicReservationResponse
{
        [XmlElement(ElementName = "Successful")]
        public bool Successful { get; set; }
        [XmlElement(ElementName = "ReservationNo")]
        public string ReservationNo { get; set; }
        [XmlElement(ElementName = "ReservationStatus")]
        public string ReservationStatus { get; set; }
        [XmlElement(ElementName = "FailureReason")]
        public string FailureReason { get; set; }
    }


