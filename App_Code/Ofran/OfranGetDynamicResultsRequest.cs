using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetDynamicResults")]
public class OfranGetDynamicResultsRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "isDirect")]
    public string IsDirect { get; set; }
    [XmlElement(ElementName = "uniqueUserID")]
    public string UniqueUserID { get; set; }
    [XmlElement(ElementName = "countryID")]
    public string CountryID { get; set; }
    [XmlElement(ElementName = "pickupIataID")]
    public string PickupIataID { get; set; }
    [XmlElement(ElementName = "pickupDate")]
    public string PickupDate { get; set; }
    [XmlElement(ElementName = "pickupHour")]
    public string PickupHour { get; set; }
    [XmlElement(ElementName = "dropIataID")]
    public string DropIataID { get; set; }
    [XmlElement(ElementName = "dropDate")]
    public string DropDate { get; set; }
    [XmlElement(ElementName = "dropHour")]
    public string DropHour { get; set; }
    [XmlElement(ElementName = "driverAge")]
    public string DriverAge { get; set; }
    [XmlElement(ElementName = "webConsumerId")]
    public string WebConsumerId { get; set; }
    [XmlElement(ElementName = "languageCode")]
    public string LanguageCode { get; set; }
    [XmlElement(ElementName = "OfranCargroupid")]
    public string OfranCarGroupid { get; set; }
}