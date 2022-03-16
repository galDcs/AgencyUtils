//using System.Xml.Serialization;
//using System.Collections.Generic;

//    [XmlRoot(ElementName = "PriceQuotePreBooks")]
//    public class PriceQuotePreBooks
//    {
//        [XmlElement(ElementName = "Suppliercode")]
//        public string Suppliercode { get; set; }
//        [XmlElement(ElementName = "Conditionid")]
//        public string Conditionid { get; set; }
//        [XmlElement(ElementName = "Condition")]
//        public string Condition { get; set; }
//        [XmlElement(ElementName = "ConditionContent")]
//        public string ConditionContent { get; set; }
//        [XmlElement(ElementName = "NeedsQuantity")]
//        public bool NeedsQuantity { get; set; }
//        [XmlElement(ElementName = "Quantity")]
//        public string Quantity { get; set; }
//        [XmlElement(ElementName = "NeedsComment")]
//        public bool NeedsComment { get; set; }
//        [XmlElement(ElementName = "Comment")]
//        public string Comment { get; set; }
//        [XmlElement(ElementName = "QuestionToAsk")]
//        public string QuestionToAsk { get; set; }
//    }

//    [XmlRoot(ElementName = "Prebookconditions")]
//    public class Prebookconditions
//    {
//        [XmlElement(ElementName = "PriceQuotePreBooks")]
//        public List<PriceQuotePreBooks> PriceQuotePreBooks { get; set; }
//    }

//    [XmlRoot(ElementName = "ChosenPreBooks")]
//    public class ChosenPreBooks
//    {
//        [XmlElement(ElementName = "Prebookconditions")]
//        public Prebookconditions Prebookconditions { get; set; }
//    }

//    [XmlRoot(ElementName = "CarDetails")]
//    public class CarDetails
//    {
//        [XmlElement(ElementName = "Carmodelid")]
//        public string Carmodelid { get; set; }
//        [XmlElement(ElementName = "Carmodel")]
//        public string Carmodel { get; set; }
//        [XmlElement(ElementName = "PictureFile")]
//        public string PictureFile { get; set; }
//        [XmlElement(ElementName = "OfranCargroupid")]
//        public string OfranCargroupid { get; set; }
//        [XmlElement(ElementName = "OfranCargroup")]
//        public string OfranCargroup { get; set; }
//        [XmlElement(ElementName = "Numdoors")]
//        public string Numdoors { get; set; }
//        [XmlElement(ElementName = "Enginesize")]
//        public string Enginesize { get; set; }
//        [XmlElement(ElementName = "Reccnumofadults")]
//        public string Reccnumofadults { get; set; }
//        [XmlElement(ElementName = "Reccnumofkids")]
//        public string Reccnumofkids { get; set; }
//        [XmlElement(ElementName = "Reccnumofsuitcases")]
//        public string Reccnumofsuitcases { get; set; }
//        [XmlElement(ElementName = "Reccnumofhandbags")]
//        public string Reccnumofhandbags { get; set; }
//        [XmlElement(ElementName = "Sippcode")]
//        public string Sippcode { get; set; }
//        [XmlElement(ElementName = "AlternativeModels")]
//        public string AlternativeModels { get; set; }
//        [XmlElement(ElementName = "SupplierCarGroup")]
//        public string SupplierCarGroup { get; set; }
//    }

//    [XmlRoot(ElementName = "AdditionalProduct")]
//    public class AdditionalProduct
//    {
//        [XmlElement(ElementName = "Name")]
//        public string Name { get; set; }
//        [XmlElement(ElementName = "ProductId")]
//        public string ProductId { get; set; }
//        [XmlElement(ElementName = "ProductPriceCatalogueId")]
//        public string ProductPriceCatalogueId { get; set; }
//        [XmlElement(ElementName = "RateInReservationPQCurrency")]
//        public string RateInReservationPQCurrency { get; set; }
//        [XmlElement(ElementName = "RateInBranchCurrency")]
//        public string RateInBranchCurrency { get; set; }
//        [XmlElement(ElementName = "ReservationPQCurrencyCode")]
//        public string ReservationPQCurrencyCode { get; set; }
//        [XmlElement(ElementName = "BranchCurrencyCode")]
//        public string BranchCurrencyCode { get; set; }
//        [XmlElement(ElementName = "Order")]
//        public string Order { get; set; }
//        [XmlElement(ElementName = "DisplayInBranchCurrency")]
//        public string DisplayInBranchCurrency { get; set; }
//        [XmlElement(ElementName = "DisplayType")]
//        public string DisplayType { get; set; }
//    }

//    [XmlRoot(ElementName = "AdditionalProducts")]
//    public class AdditionalProducts
//    {
//        [XmlElement(ElementName = "AdditionalProduct")]
//        public List<AdditionalProduct> AdditionalProduct { get; set; }
//    }

//    [XmlRoot(ElementName = "Country")]
//    public class Country
//    {
//        [XmlElement(ElementName = "ID")]
//        public string ID { get; set; }
//        [XmlElement(ElementName = "Name")]
//        public string Name { get; set; }
//    }

//    [XmlRoot(ElementName = "CrossingCountries")]
//    public class CrossingCountries
//    {
//        [XmlElement(ElementName = "Country")]
//        public Country Country { get; set; }
//    }

//    [XmlRoot(ElementName = "PriceQuoteDetailsResult")]
//    public class OfranGetPriceQuoteFullDetailsResponse
//{
//        [XmlElement(ElementName = "Number")]
//        public string Number { get; set; }
//        [XmlElement(ElementName = "IsValid")]
//        public string IsValid { get; set; }
//        [XmlElement(ElementName = "FailureReason")]
//        public string FailureReason { get; set; }
//        [XmlElement(ElementName = "Clientid")]
//        public string Clientid { get; set; }
//        [XmlElement(ElementName = "ClientUser")]
//        public string ClientUser { get; set; }
//        [XmlElement(ElementName = "ClientFirstname")]
//        public string ClientFirstname { get; set; }
//        [XmlElement(ElementName = "ClientLastname")]
//        public string ClientLastname { get; set; }
//        [XmlElement(ElementName = "titleOrAgency")]
//        public string TitleOrAgency { get; set; }
//        [XmlElement(ElementName = "IsDirect")]
//        public string IsDirect { get; set; }
//        [XmlElement(ElementName = "DriverLastname")]
//        public string DriverLastname { get; set; }
//        [XmlElement(ElementName = "DriverFirstname")]
//        public string DriverFirstname { get; set; }
//        [XmlElement(ElementName = "DriverTitle")]
//        public string DriverTitle { get; set; }
//        [XmlElement(ElementName = "Age")]
//        public string Age { get; set; }
//        [XmlElement(ElementName = "FlightNumber")]
//        public string FlightNumber { get; set; }
//        [XmlElement(ElementName = "puDate")]
//        public string PuDate { get; set; }
//        [XmlElement(ElementName = "PuHour")]
//        public string PuHour { get; set; }
//        [XmlElement(ElementName = "PuCountryid")]
//        public string PuCountryid { get; set; }
//        [XmlElement(ElementName = "PuCountry")]
//        public string PuCountry { get; set; }
//        [XmlElement(ElementName = "Puiataid")]
//        public string Puiataid { get; set; }
//        [XmlElement(ElementName = "PuIata")]
//        public string PuIata { get; set; }
//        [XmlElement(ElementName = "PuStationid")]
//        public string PuStationid { get; set; }
//        [XmlElement(ElementName = "PuStation")]
//        public string PuStation { get; set; }
//        [XmlElement(ElementName = "doDate")]
//        public string DoDate { get; set; }
//        [XmlElement(ElementName = "DoHour")]
//        public string DoHour { get; set; }
//        [XmlElement(ElementName = "DoCountryid")]
//        public string DoCountryid { get; set; }
//        [XmlElement(ElementName = "DoCountry")]
//        public string DoCountry { get; set; }
//        [XmlElement(ElementName = "Doiataid")]
//        public string Doiataid { get; set; }
//        [XmlElement(ElementName = "DoIata")]
//        public string DoIata { get; set; }
//        [XmlElement(ElementName = "DoStationid")]
//        public string DoStationid { get; set; }
//        [XmlElement(ElementName = "DoStation")]
//        public string DoStation { get; set; }
//        [XmlElement(ElementName = "NoOfDays")]
//        public string NoOfDays { get; set; }
//        [XmlElement(ElementName = "FriendlyContract")]
//        public string FriendlyContract { get; set; }
//        [XmlElement(ElementName = "Basic")]
//        public string Basic { get; set; }
//        [XmlElement(ElementName = "DisplayBasic")]
//        public string DisplayBasic { get; set; }
//        [XmlElement(ElementName = "Premium")]
//        public string Premium { get; set; }
//        [XmlElement(ElementName = "Handlingfee")]
//        public string Handlingfee { get; set; }
//        [XmlElement(ElementName = "PromotionAmount")]
//        public string PromotionAmount { get; set; }
//        [XmlElement(ElementName = "Others")]
//        public string Others { get; set; }
//        [XmlElement(ElementName = "Grosstotal")]
//        public string Grosstotal { get; set; }
//        [XmlElement(ElementName = "Grosstotalbranchcurrency")]
//        public string Grosstotalbranchcurrency { get; set; }
//        [XmlElement(ElementName = "DiscountPercent")]
//        public string DiscountPercent { get; set; }
//        [XmlElement(ElementName = "Discount")]
//        public string Discount { get; set; }
//        [XmlElement(ElementName = "Commissionpercent")]
//        public string Commissionpercent { get; set; }
//        [XmlElement(ElementName = "Commission")]
//        public string Commission { get; set; }
//        [XmlElement(ElementName = "Vatpercent")]
//        public string Vatpercent { get; set; }
//        [XmlElement(ElementName = "DomesticVat")]
//        public string DomesticVat { get; set; }
//        [XmlElement(ElementName = "Vat")]
//        public string Vat { get; set; }
//        [XmlElement(ElementName = "Nettotal")]
//        public string Nettotal { get; set; }
//        [XmlElement(ElementName = "Nettotalbranchcurrency")]
//        public string Nettotalbranchcurrency { get; set; }
//        [XmlElement(ElementName = "ReservationCurrencyid")]
//        public string ReservationCurrencyid { get; set; }
//        [XmlElement(ElementName = "ReservationCurrencyCode")]
//        public string ReservationCurrencyCode { get; set; }
//        [XmlElement(ElementName = "Branchcurrid")]
//        public string Branchcurrid { get; set; }
//        [XmlElement(ElementName = "BranchcurrencyCode")]
//        public string BranchcurrencyCode { get; set; }
//        [XmlElement(ElementName = "SupplierCargroupid")]
//        public string SupplierCargroupid { get; set; }
//        [XmlElement(ElementName = "ChosenPreBooks")]
//        public ChosenPreBooks ChosenPreBooks { get; set; }
//        [XmlElement(ElementName = "CarDetails")]
//        public CarDetails CarDetails { get; set; }
//        [XmlElement(ElementName = "SubContracteid")]
//        public string SubContracteid { get; set; }
//        [XmlElement(ElementName = "Pricecatalogueid")]
//        public string Pricecatalogueid { get; set; }
//        [XmlElement(ElementName = "SupplierPricecatalogueid")]
//        public string SupplierPricecatalogueid { get; set; }
//        [XmlElement(ElementName = "AgencyPaymentType")]
//        public string AgencyPaymentType { get; set; }
//        [XmlElement(ElementName = "AdditionalProducts")]
//        public AdditionalProducts AdditionalProducts { get; set; }
//        [XmlElement(ElementName = "CrossingCountries")]
//        public CrossingCountries CrossingCountries { get; set; }
//}




   /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "PriceQuoteDetailsResult")]
public class OfranGetPriceQuoteFullDetailsResponse
{
    [XmlElement(ElementName = "Number")]
    public string Number { get; set; }
    [XmlElement(ElementName = "IsValid")]
    public string IsValid { get; set; }
    [XmlElement(ElementName = "FailureReason")]
    public string FailureReason { get; set; }
    [XmlElement(ElementName = "Clientid")]
    public string Clientid { get; set; }
    [XmlElement(ElementName = "ClientUser")]
    public string ClientUser { get; set; }
    [XmlElement(ElementName = "ClientFirstname")]
    public string ClientFirstname { get; set; }
    [XmlElement(ElementName = "ClientLastname")]
    public string ClientLastname { get; set; }
    [XmlElement(ElementName = "titleOrAgency")]
    public string TitleOrAgency { get; set; }
    [XmlElement(ElementName = "IsDirect")]
    public string IsDirect { get; set; }
    [XmlElement(ElementName = "DriverLastname")]
    public string DriverLastname { get; set; }
    [XmlElement(ElementName = "DriverFirstname")]
    public string DriverFirstname { get; set; }
    [XmlElement(ElementName = "DriverTitle")]
    public string DriverTitle { get; set; }
    [XmlElement(ElementName = "Age")]
    public string Age { get; set; }
    [XmlElement(ElementName = "FlightNumber")]
    public string FlightNumber { get; set; }
    [XmlElement(ElementName = "puDate")]
    public string PuDate { get; set; }
    [XmlElement(ElementName = "PuHour")]
    public string PuHour { get; set; }
    [XmlElement(ElementName = "PuCountryid")]
    public string PuCountryid { get; set; }
    [XmlElement(ElementName = "PuCountry")]
    public string PuCountry { get; set; }
    [XmlElement(ElementName = "Puiataid")]
    public string Puiataid { get; set; }
    [XmlElement(ElementName = "PuIata")]
    public string PuIata { get; set; }
    [XmlElement(ElementName = "PuStationid")]
    public string PuStationid { get; set; }
    [XmlElement(ElementName = "PuStation")]
    public string PuStation { get; set; }
    [XmlElement(ElementName = "doDate")]
    public string DoDate { get; set; }
    [XmlElement(ElementName = "DoHour")]
    public string DoHour { get; set; }
    [XmlElement(ElementName = "DoCountryid")]
    public string DoCountryid { get; set; }
    [XmlElement(ElementName = "DoCountry")]
    public string DoCountry { get; set; }
    [XmlElement(ElementName = "Doiataid")]
    public string Doiataid { get; set; }
    [XmlElement(ElementName = "DoIata")]
    public string DoIata { get; set; }
    [XmlElement(ElementName = "DoStationid")]
    public string DoStationid { get; set; }
    [XmlElement(ElementName = "DoStation")]
    public string DoStation { get; set; }
    [XmlElement(ElementName = "NoOfDays")]
    public string NoOfDays { get; set; }
    [XmlElement(ElementName = "FriendlyContract")]
    public string FriendlyContract { get; set; }
    [XmlElement(ElementName = "Basic")]
    public string Basic { get; set; }
    [XmlElement(ElementName = "DisplayBasic")]
    public string DisplayBasic { get; set; }
    [XmlElement(ElementName = "Premium")]
    public string Premium { get; set; }
    [XmlElement(ElementName = "Handlingfee")]
    public string Handlingfee { get; set; }
    [XmlElement(ElementName = "PromotionAmount")]
    public string PromotionAmount { get; set; }
    [XmlElement(ElementName = "Others")]
    public string Others { get; set; }
    [XmlElement(ElementName = "Grosstotal")]
    public string Grosstotal { get; set; }
    [XmlElement(ElementName = "Grosstotalbranchcurrency")]
    public string Grosstotalbranchcurrency { get; set; }
    [XmlElement(ElementName = "DiscountPercent")]
    public string DiscountPercent { get; set; }
    [XmlElement(ElementName = "Discount")]
    public string Discount { get; set; }
    [XmlElement(ElementName = "Commissionpercent")]
    public string Commissionpercent { get; set; }
    [XmlElement(ElementName = "Commission")]
    public string Commission { get; set; }
    [XmlElement(ElementName = "Vatpercent")]
    public string Vatpercent { get; set; }
    [XmlElement(ElementName = "DomesticVat")]
    public string DomesticVat { get; set; }
    [XmlElement(ElementName = "Vat")]
    public string Vat { get; set; }
    [XmlElement(ElementName = "Nettotal")]
    public string Nettotal { get; set; }
    [XmlElement(ElementName = "Nettotalbranchcurrency")]
    public string Nettotalbranchcurrency { get; set; }
    [XmlElement(ElementName = "ReservationCurrencyid")]
    public string ReservationCurrencyid { get; set; }
    [XmlElement(ElementName = "ReservationCurrencyCode")]
    public string ReservationCurrencyCode { get; set; }
    [XmlElement(ElementName = "Branchcurrid")]
    public string Branchcurrid { get; set; }
    [XmlElement(ElementName = "BranchcurrencyCode")]
    public string BranchcurrencyCode { get; set; }
    [XmlElement(ElementName = "SupplierCargroupid")]
    public string SupplierCargroupid { get; set; }
    [XmlElement(ElementName = "ChosenPreBooks")]
    public ChosenPreBooks ChosenPreBooksX { get; set; }
    [XmlElement(ElementName = "CarDetails")]
    public CarDetails CarDetailsX { get; set; }
    [XmlElement(ElementName = "SubContracteid")]
    public string SubContracteid { get; set; }
    [XmlElement(ElementName = "Pricecatalogueid")]
    public string Pricecatalogueid { get; set; }
    [XmlElement(ElementName = "SupplierPricecatalogueid")]
    public string SupplierPricecatalogueid { get; set; }
    [XmlElement(ElementName = "AgencyPaymentType")]
    public string AgencyPaymentType { get; set; }
    [XmlElement(ElementName = "AdditionalProducts")]
    public AdditionalProducts AdditionalProductsX { get; set; }
    [XmlElement(ElementName = "CrossingCountries")]
    public CrossingCountries CrossingCountriesX { get; set; }

    [XmlRoot(ElementName = "PriceQuotePreBooks")]
    public class PriceQuotePreBooks
    {
        [XmlElement(ElementName = "Suppliercode")]
        public string Suppliercode { get; set; }
        [XmlElement(ElementName = "Conditionid")]
        public string Conditionid { get; set; }
        [XmlElement(ElementName = "Condition")]
        public string Condition { get; set; }
        [XmlElement(ElementName = "ConditionContent")]
        public string ConditionContent { get; set; }
        [XmlElement(ElementName = "NeedsQuantity")]
        public bool NeedsQuantity { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "NeedsComment")]
        public bool NeedsComment { get; set; }
        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }
        [XmlElement(ElementName = "QuestionToAsk")]
        public string QuestionToAsk { get; set; }
    }

    [XmlRoot(ElementName = "Prebookconditions")]
    public class Prebookconditions
    {
        [XmlElement(ElementName = "PriceQuotePreBooks")]
        public List<PriceQuotePreBooks> PriceQuotePreBooks { get; set; }
    }

    [XmlRoot(ElementName = "ChosenPreBooks")]
    public class ChosenPreBooks
    {
        [XmlElement(ElementName = "Prebookconditions")]
        public Prebookconditions Prebookconditions { get; set; }
    }

    [XmlRoot(ElementName = "AlternativeModel")]
    public class AlternativeModel
    {
        [XmlElement(ElementName = "Carmodelid")]
        public string Carmodelid { get; set; }
        [XmlElement(ElementName = "CarModel")]
        public string CarModel { get; set; }
    }

    [XmlRoot(ElementName = "AlternativeModels")]
    public class AlternativeModels
    {
        [XmlElement(ElementName = "AlternativeModel")]
        public AlternativeModel AlternativeModel { get; set; }
    }

    [XmlRoot(ElementName = "CarDetails")]
    public class CarDetails
    {
        [XmlElement(ElementName = "Carmodelid")]
        public string Carmodelid { get; set; }
        [XmlElement(ElementName = "Carmodel")]
        public string Carmodel { get; set; }
        [XmlElement(ElementName = "PictureFile")]
        public string PictureFile { get; set; }
        [XmlElement(ElementName = "OfranCargroupid")]
        public string OfranCargroupid { get; set; }
        [XmlElement(ElementName = "OfranCargroup")]
        public string OfranCargroup { get; set; }
        [XmlElement(ElementName = "Numdoors")]
        public string Numdoors { get; set; }
        [XmlElement(ElementName = "Enginesize")]
        public string Enginesize { get; set; }
        [XmlElement(ElementName = "Reccnumofadults")]
        public string Reccnumofadults { get; set; }
        [XmlElement(ElementName = "Reccnumofkids")]
        public string Reccnumofkids { get; set; }
        [XmlElement(ElementName = "Reccnumofsuitcases")]
        public string Reccnumofsuitcases { get; set; }
        [XmlElement(ElementName = "Reccnumofhandbags")]
        public string Reccnumofhandbags { get; set; }
        [XmlElement(ElementName = "Sippcode")]
        public string Sippcode { get; set; }
        [XmlElement(ElementName = "AlternativeModels")]
        public AlternativeModels AlternativeModels { get; set; }
        [XmlElement(ElementName = "SupplierCarGroup")]
        public string SupplierCarGroup { get; set; }
    }

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

    [XmlRoot(ElementName = "AdditionalProducts")]
    public class AdditionalProducts
    {
        [XmlElement(ElementName = "AdditionalProduct")]
        public List<AdditionalProduct> AdditionalProduct { get; set; }
    }

    [XmlRoot(ElementName = "Country")]
    public class Country
    {
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "CrossingCountries")]
    public class CrossingCountries
    {
        [XmlElement(ElementName = "Country")]
        public Country Country { get; set; }
    }

}


