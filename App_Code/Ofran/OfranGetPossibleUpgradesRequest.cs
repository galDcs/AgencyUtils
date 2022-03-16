using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetPossibleUpgrades")]
public class OfranGetPossibleUpgradesRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "isDirect")]
    public string IsDirect { get; set; }
    [XmlElement(ElementName = "uniqueUserID")]
    public string UniqueUserID { get; set; }
    [XmlElement(ElementName = "supplierCarGroupID")]
    public string SupplierCarGroupID { get; set; }
    [XmlElement(ElementName = "pickupStationID")]
    public string PickupStationID { get; set; }
    [XmlElement(ElementName = "dropoffStationID")]
    public string DropoffStationID { get; set; }
    [XmlElement(ElementName = "pickupDate")]
    public string PickupDate { get; set; }
    [XmlElement(ElementName = "pickupHour")]
    public string PickupHour { get; set; }
    [XmlElement(ElementName = "dropoffDate")]
    public string DropoffDate { get; set; }
    [XmlElement(ElementName = "dropoffHour")]
    public string DropoffHour { get; set; }
    [XmlElement(ElementName = "driverAge")]
    public string DriverAge { get; set; }
    [XmlElement(ElementName = "priceCatalogueID")]
    public string PriceCatalogueID { get; set; }
    [XmlElement(ElementName = "handlingFee")]
    public string HandlingFee { get; set; }
    [XmlElement(ElementName = "supplierPriceCatalogueID")]
    public string SupplierPriceCatalogueID { get; set; }
    [XmlElement(ElementName = "lang")]
    public string Lang { get; set; }
    [XmlElement(ElementName = "webConsumerId")]
    public string WebConsumerId { get; set; }

}