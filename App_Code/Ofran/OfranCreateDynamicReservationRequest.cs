using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "CreateDynamicReservation")]
public class OfranCreateDynamicReservationRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "isDirect")]
    public string IsDirect { get; set; }
    [XmlElement(ElementName = "priceQuoteNum")]
    public string PriceQuoteNum { get; set; }
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
    [XmlElement(ElementName = "isConfirmed")]
    public string IsConfirmed { get; set; }
    [XmlElement(ElementName = "language")]
    public string Language { get; set; }
    [XmlElement(ElementName = "webConsumerId")]
    public string WebConsumerId { get; set; }
    [XmlElement(ElementName = "IsLiveRate")]
    public string IsLiveRate { get; set; }


    [XmlRoot(ElementName = "AdditionalProduct")]
    public class AdditionalProduct
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "ProductId")]
        public string ProductId { get; set; }
        [XmlElement(ElementName = "ProductPriceCatalogueId")]
        public string ProductPriceCatalogueId { get; set; }
        [XmlElement(ElementName = "RateInReservationPQCurrency")]
        public string RateInReservationPQCurrency { get; set; }
        [XmlElement(ElementName = "RateInBranchCurrency")]
        public string RateInBranchCurrency { get; set; }
        [XmlElement(ElementName = "ReservationPQCurrencyCode")]
        public string ReservationPQCurrencyCode { get; set; }
        [XmlElement(ElementName = "BranchCurrencyCode")]
        public string BranchCurrencyCode { get; set; }
        [XmlElement(ElementName = "Order")]
        public string Order { get; set; }
        [XmlElement(ElementName = "DisplayInBranchCurrency")]
        public string DisplayInBranchCurrency { get; set; }
        [XmlElement(ElementName = "DisplayType")]
        public string DisplayType { get; set; }
    }

    [XmlRoot(ElementName = "Products")]
    public class Products
    {
        [XmlElement(ElementName = "AdditionalProduct")]
        public List<AdditionalProduct> AdditionalProduct { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalProducts")]
    public class AdditionalProducts
    {
        [XmlElement(ElementName = "Products")]
        public Products Products { get; set; }

        public static implicit operator List<object>(AdditionalProducts v)
        {
            throw new NotImplementedException();
        }
    }

    [XmlRoot(ElementName = "countryList")]
    public class CountryList
    {
        [XmlElement(ElementName = "country")]
        public List<string> Country { get; set; }
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



