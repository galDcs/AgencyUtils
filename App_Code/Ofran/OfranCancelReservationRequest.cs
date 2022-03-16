using System;
using System.Xml.Serialization;
using System.Collections.Generic;

    [XmlRoot(ElementName = "CancelReservation")]
    public class OfranCancelReservationRequest
{
        [XmlElement(ElementName = "reservationNumber")]
        public string ReservationNumber { get; set; }
        [XmlElement(ElementName = "webConsumerId")]
        public string WebConsumerId { get; set; }
    }


