using System.Xml.Serialization;

[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class SabreLdsRetrieveReservationRequest
{
    [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public string Header { get; set; }
    [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public BodyClass Body { get; set; }
    [XmlAttribute(AttributeName = "env", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string Env { get; set; }
    [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string Soap { get; set; }


    [XmlRoot(ElementName = "identificationData")]
    public class IdentificationData
    {
        [XmlElement(ElementName = "userName")]
        public string UserName { get; set; }
        [XmlElement(ElementName = "password")]
        public string Password { get; set; }
    }

    [XmlRoot(ElementName = "reservationForm")]
    public class ReservationForm
    {
        [XmlElement(ElementName = "identificationData")]
        public IdentificationData IdentificationData { get; set; }
        [XmlElement(ElementName = "clientVersion")]
        public string ClientVersion { get; set; }
        [XmlElement(ElementName = "pnr")]
        public string Pnr { get; set; }
    }

    [XmlRoot(ElementName = "retrieveReservation", Namespace = "http://v320.ws.lds.lognet.com/")]
    public class RetrieveReservation
    {
        [XmlElement(ElementName = "reservationForm")]
        public ReservationForm ReservationForm { get; set; }
        [XmlAttribute(AttributeName = "ns0", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns0 { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class BodyClass
    {
        [XmlElement(ElementName = "retrieveReservation", Namespace = "http://v320.ws.lds.lognet.com/")]
        public RetrieveReservation RetrieveReservation { get; set; }
    }

}


