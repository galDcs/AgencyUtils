using System.Xml.Serialization;

[XmlRoot(ElementName = "Voucher")]
public class OfranSendVoucherResponse
{
    [XmlElement(ElementName = "Success")]
    public bool Success { get; set; }
}