using System;
using System.Xml.Serialization;
using System.Collections.Generic;

    [XmlRoot(ElementName = "Cancellation")]
    public class OfranCancelReservationResponse
    {
        [XmlElement(ElementName = "Successful")]
        public bool Successful { get; set; }
    }

