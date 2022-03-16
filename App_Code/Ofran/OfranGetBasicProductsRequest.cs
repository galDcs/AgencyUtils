using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetBasicProducts")]
public class OfranGetBasicProductsRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "isDirect")]
    public string IsDirect { get; set; }
    [XmlElement(ElementName = "uniqueUserID")]
    public string UniqueUserID { get; set; }
    [XmlElement(ElementName = "driverAge")]
    public string DriverAge { get; set; }
    [XmlElement(ElementName = "pickupDate")]
    public string PickupDate { get; set; }
    [XmlElement(ElementName = "pickupHour")]
    public string PickupHour { get; set; }
    [XmlElement(ElementName = "dropoffDate")]
    public string DropoffDate { get; set; }
    [XmlElement(ElementName = "dropoffHour")]
    public string DropoffHour { get; set; }
    [XmlElement(ElementName = "currencyID")]
    public string CurrencyID { get; set; }
    [XmlElement(ElementName = "supplierCarGroupID")]
    public string SupplierCarGroupID { get; set; }
    [XmlElement(ElementName = "subContractID")]
    public string SubContractID { get; set; }
    [XmlElement(ElementName = "pickupCountryID")]
    public string PickupCountryID { get; set; }
    [XmlElement(ElementName = "webConsumerId")]
    public string WebConsumerId { get; set; }
}