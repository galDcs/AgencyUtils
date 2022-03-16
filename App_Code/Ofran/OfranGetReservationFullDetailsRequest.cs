using System.Xml.Serialization;

    [XmlRoot(ElementName = "GetReservationFullDetails")]
    public class OfranGetReservationFullDetailsRequest
    {
        [XmlElement(ElementName = "reservationNumber")]
        public string ReservationNumber { get; set; }
        [XmlElement(ElementName = "languageCode")]
        public string LanguageCode { get; set; }
    }
