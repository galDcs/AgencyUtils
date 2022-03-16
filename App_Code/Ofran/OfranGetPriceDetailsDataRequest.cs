using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
    
[XmlRoot(ElementName = "GetPriceDetailsData")]
public class OfranGetPriceDetailsDataRequest
{
    [XmlElement(ElementName = "webCustomerID")]
        public string WebCustomerID { get; set; }
        [XmlElement(ElementName = "isDirect")]
        public string IsDirect { get; set; }
        [XmlElement(ElementName = "uniqueUserID")]
        public string UniqueUserID { get; set; }
        [XmlElement(ElementName = "basicPrice")]
        public string BasicPrice { get; set; }
        [XmlElement(ElementName = "netAmount")]
        public string NetAmount { get; set; }
        [XmlElement(ElementName = "AdditionalProducts")]
        public AdditionalProducts AdditionalProductsX { get; set; }
        [XmlElement(ElementName = "handlingFee")]
        public string HandlingFee { get; set; }
        [XmlElement(ElementName = "premiumFee")]
        public string PremiumFee { get; set; }
        [XmlElement(ElementName = "currencyID")]
        public string CurrencyID { get; set; }
        [XmlElement(ElementName = "countryID")]
        public string CountryID { get; set; }
        [XmlElement(ElementName = "supplierCarGroupID")]
        public string SupplierCarGroupID { get; set; }
        [XmlElement(ElementName = "pickupDate")]
        public string PickupDate { get; set; }
        [XmlElement(ElementName = "pickupHour")]
        public string PickupHour { get; set; }
        [XmlElement(ElementName = "dropoffDate")]
        public string DropoffDate { get; set; }
        [XmlElement(ElementName = "dropoffHour")]
        public string DropoffHour { get; set; }
        [XmlElement(ElementName = "webConsumerId")]
        public string WebConsumerId { get; set; }
        [XmlElement(ElementName = "puIataId")]
        public string PuIataId { get; set; }
    
    

    [XmlRoot(ElementName = "Products")]
    public class Products
    {
        [XmlElement(ElementName = "AdditionalProduct")]
        public List<OfranAdditionalProduct> AdditionalProduct { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalProducts")]
    public class AdditionalProducts
    {
        [XmlElement(ElementName = "Products")]
        public Products Products { get; set; }
    }
}