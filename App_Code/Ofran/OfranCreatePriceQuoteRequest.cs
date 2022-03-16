using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "CreatePriceQuote")]
public class OfranCreatePriceQuoteRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "isDirect")]
    public string IsDirect { get; set; }
    [XmlElement(ElementName = "uniqueUserID")]
    public string UniqueUserID { get; set; }
    [XmlElement(ElementName = "firstName")]
    public string FirstName { get; set; }
    [XmlElement(ElementName = "lastName")]
    public string LastName { get; set; }
    [XmlElement(ElementName = "title")]
    public string Title { get; set; }
    [XmlElement(ElementName = "countryID")]
    public string CountryID { get; set; }
    [XmlElement(ElementName = "pickupStationID")]
    public string PickupStationID { get; set; }
    [XmlElement(ElementName = "pickupDate")]
    public string PickupDate { get; set; }
    [XmlElement(ElementName = "pickupHour")]
    public string PickupHour { get; set; }
    [XmlElement(ElementName = "dropoffStationID")]
    public string DropoffStationID { get; set; }
    [XmlElement(ElementName = "dropoffDate")]
    public string DropoffDate { get; set; }
    [XmlElement(ElementName = "dropoffHour")]
    public string DropoffHour { get; set; }
    [XmlElement(ElementName = "driverAge")]
    public string DriverAge { get; set; }
    [XmlElement(ElementName = "supplierCarGroupID")]
    public string SupplierCarGroupID { get; set; }
    [XmlElement(ElementName = "subContractId")]
    public string SubContractId { get; set; }
    [XmlElement(ElementName = "priceCatalogueID")]
    public string PriceCatalogueID { get; set; }
    [XmlElement(ElementName = "currencyID")]
    public string CurrencyID { get; set; }
    [XmlElement(ElementName = "supplierPriceCatalogueID")]
    public string SupplierPriceCatalogueID { get; set; }
    [XmlElement(ElementName = "basicPrice")]
    public string BasicPrice { get; set; }
    [XmlElement(ElementName = "netAmount")]
    public string NetAmount { get; set; }
    [XmlElement(ElementName = "AdditionalProducts")]
    public AdditionalProducts AdditionalProductsX { get; set; }
    [XmlElement(ElementName = "handlingFee")]
    public string HandlingFee { get; set; }
    [XmlElement(ElementName = "commission")]
    public string Commission { get; set; }
    [XmlElement(ElementName = "comissionPercent")]
    public string ComissionPercent { get; set; }
    [XmlElement(ElementName = "vat")]
    public string Vat { get; set; }
    [XmlElement(ElementName = "domesticVat")]
    public string DomesticVat { get; set; }
    [XmlElement(ElementName = "vatPercent")]
    public string VatPercent { get; set; }
    [XmlElement(ElementName = "countryList")]
    public CountryList CountriesList { get; set; }
    [XmlElement(ElementName = "prebookList")]
    public PrebookList PrebooksList { get; set; }
    [XmlElement(ElementName = "flightNum")]
    public string FlightNum { get; set; }
    [XmlElement(ElementName = "premiumStationCharge")]
    public string PremiumStationCharge { get; set; }
    [XmlElement(ElementName = "discountPer")]
    public string DiscountPer { get; set; }
    [XmlElement(ElementName = "discount")]
    public string Discount { get; set; }
    [XmlElement(ElementName = "sendAdvertisement")]
    public string SendAdvertisement { get; set; }
    [XmlElement(ElementName = "lang")]
    public string Lang { get; set; }
    [XmlElement(ElementName = "isConfirmed")]
    public string IsConfirmed { get; set; }
    [XmlElement(ElementName = "webConsumerId")]
    public string WebConsumerId { get; set; }
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

    [XmlRoot(ElementName = "countryList")]
    public class CountryList
    {
        [XmlElement(ElementName = "country")]
        public List<string> Countries { get; set; }
    }

    [XmlRoot(ElementName = "prebook")]
    public class Prebook
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }
    }

    [XmlRoot(ElementName = "prebookList")]
    public class PrebookList
    {
        [XmlElement(ElementName = "prebook")]
        public List<Prebook> Prebook { get; set; }
    }
}