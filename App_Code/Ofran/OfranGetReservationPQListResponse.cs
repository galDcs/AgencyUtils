using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "ArrayOfReservationPQList")]
public class OfranGetReservationPQListResponse
{
    [XmlElement(ElementName = "reservationPQList")]
    public List<ReservationPQList> MReservationPQList { get; set; }


    [XmlRoot(ElementName = "reservationPQList")]
    public class ReservationPQList
    {
        [XmlElement(ElementName = "Number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "IncriptedNumber")]
        public string IncriptedNumber { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "puDate")]
        public string PuDate { get; set; }
        [XmlElement(ElementName = "puTime")]
        public string PuTime { get; set; }
        [XmlElement(ElementName = "DriverLastname")]
        public string DriverLastname { get; set; }
        [XmlElement(ElementName = "DriverFirstname")]
        public string DriverFirstname { get; set; }
        [XmlElement(ElementName = "DriverTitle")]
        public string DriverTitle { get; set; }
        [XmlElement(ElementName = "PuCountry")]
        public string PuCountry { get; set; }
        [XmlElement(ElementName = "PuStation")]
        public string PuStation { get; set; }
        [XmlElement(ElementName = "SippCode")]
        public string SippCode { get; set; }
        [XmlElement(ElementName = "NoOfDays")]
        public string NoOfDays { get; set; }
        [XmlElement(ElementName = "CancellationAlowed")]
        public string CancellationAlowed { get; set; }
        [XmlElement(ElementName = "IsPQ")]
        public bool IsPQ { get; set; }
        [XmlElement(ElementName = "IsReservation")]
        public bool IsReservation { get; set; }
        [XmlElement(ElementName = "TicketingAllowed")]
        public string TicketingAllowed { get; set; }
    }
}


