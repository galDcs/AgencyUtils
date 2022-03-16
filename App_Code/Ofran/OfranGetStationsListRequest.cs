using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for OfranGetStationListRequest
/// </summary>
/// 

[XmlRoot(ElementName = "GetStationsList")]
public class OfranGetStationsListRequest
{
    
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "pickupIataID")]
    public string PickupIataID { get; set; }
    [XmlElement(ElementName = "dropIataID")]
    public string DropIataID { get; set; }
    [XmlElement(ElementName = "pickupDate")]
    public string PickupDate { get; set; }
    [XmlElement(ElementName = "pickupHour")]
    public string PickupHour { get; set; }
    [XmlElement(ElementName = "dropDate")]
    public string DropDate { get; set; }
    [XmlElement(ElementName = "dropHour")]
    public string DropHour { get; set; }
    [XmlElement(ElementName = "supplierCarGroupID")]
    public string SupplierCarGroupID { get; set; }
    [XmlElement(ElementName = "supplierPriceCatalogueID")]
    public string SupplierPriceCatalogueID { get; set; }
}