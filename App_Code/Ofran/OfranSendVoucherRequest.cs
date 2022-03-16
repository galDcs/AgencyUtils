using System.Xml.Serialization;

[XmlRoot(ElementName = "SendVoucher")]
public class OfranSendVoucherRequest
{
    [XmlElement(ElementName = "reservationNumber")]
    public string ReservationNumber { get; set; }
    [XmlElement(ElementName = "exchangeVoucherNumber")]
    public string ExchangeVoucherNumber { get; set; }
    [XmlElement(ElementName = "driverEmail")]
    public string DriverEmail { get; set; }
    [XmlElement(ElementName = "webConsumerId")]
    public string WebConsumerId { get; set; }


}
