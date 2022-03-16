using System;
using System.Xml.Serialization;
using System.Collections.Generic;

    [XmlRoot(ElementName = "GetReservationPQList")]
    public class OfranGetReservationPQListRequest
    {
        [XmlElement(ElementName = "userID")]
        public string UserID { get; set; }
        [XmlElement(ElementName = "isDirect")]
        public string IsDirect { get; set; }
    }

