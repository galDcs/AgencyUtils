using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "ReservationDetailsDetailedResult")]
public class OfranGetReservationFullDetailsResponse
{
    [XmlElement(ElementName = "Number")]
    public string Number { get; set; }
    [XmlElement(ElementName = "Status")]
    public string Status { get; set; }
    [XmlElement(ElementName = "ReservationStatus")]
    public string ReservationStatus { get; set; }
    [XmlElement(ElementName = "DriverLastname")]
    public string DriverLastname { get; set; }
    [XmlElement(ElementName = "DriverFirstname")]
    public string DriverFirstname { get; set; }
    [XmlElement(ElementName = "DriverTitle")]
    public string DriverTitle { get; set; }
    [XmlElement(ElementName = "Age")]
    public string Age { get; set; }
    [XmlElement(ElementName = "puDate")]
    public string PuDate { get; set; }
    [XmlElement(ElementName = "PuHour")]
    public string PuHour { get; set; }
    [XmlElement(ElementName = "PuCountry")]
    public string PuCountry { get; set; }
    [XmlElement(ElementName = "PuIata")]
    public string PuIata { get; set; }
    [XmlElement(ElementName = "PuStation")]
    public string PuStation { get; set; }
    [XmlElement(ElementName = "PuStationId")]
    public string PuStationId { get; set; }
    [XmlElement(ElementName = "doDate")]
    public string DoDate { get; set; }
    [XmlElement(ElementName = "DoHour")]
    public string DoHour { get; set; }
    [XmlElement(ElementName = "DoCountry")]
    public string DoCountry { get; set; }
    [XmlElement(ElementName = "DoIata")]
    public string DoIata { get; set; }
    [XmlElement(ElementName = "DoStation")]
    public string DoStation { get; set; }
    [XmlElement(ElementName = "DoStationId")]
    public string DoStationId { get; set; }
    [XmlElement(ElementName = "NoOfDays")]
    public string NoOfDays { get; set; }
    [XmlElement(ElementName = "CancellationAlowed")]
    public string CancellationAlowed { get; set; }
    [XmlElement(ElementName = "FriendlyContract")]
    public string FriendlyContract { get; set; }
    [XmlElement(ElementName = "FlightNo")]
    public string FlightNo { get; set; }
    [XmlElement(ElementName = "Basic")]
    public string Basic { get; set; }
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
    [XmlElement(ElementName = "Vat")]
    public string Vat { get; set; }
    [XmlElement(ElementName = "DomesticVat")]
    public string DomesticVat { get; set; }
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
    [XmlElement(ElementName = "Prebookconditions")]
    public Prebookconditions PrebookconditionsX { get; set; }
    [XmlElement(ElementName = "CarDetails")]
    public CarDetails CarDetailsX { get; set; }
    [XmlElement(ElementName = "Gotos")]
    public Gotos GotosX { get; set; }
    [XmlElement(ElementName = "Pricecatalogueid")]
    public string Pricecatalogueid { get; set; }
    [XmlElement(ElementName = "ExternalRemarks")]
    public string ExternalRemarks { get; set; }
    [XmlElement(ElementName = "SupplierName")]
    public string SupplierName { get; set; }
    [XmlElement(ElementName = "SupplierLogo")]
    public string SupplierLogo { get; set; }
    [XmlElement(ElementName = "AdditionalProducts")]
    public AdditionalProducts AdditionalProductsX { get; set; }


    [XmlRoot(ElementName = "ReservationPreBook")]
    public class ReservationPreBook
    {
        [XmlElement(ElementName = "Content")]
        public string Content { get; set; }
        [XmlElement(ElementName = "Suppliercode")]
        public string Suppliercode { get; set; }
        [XmlElement(ElementName = "Condition")]
        public string Condition { get; set; }
        [XmlElement(ElementName = "Extra")]
        public string Extra { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "Comment")]
        public string Comment { get; set; }
        [XmlElement(ElementName = "Confirmationstatus")]
        public string Confirmationstatus { get; set; }
    }

    [XmlRoot(ElementName = "Prebookconditions")]
    public class Prebookconditions
    {
        [XmlElement(ElementName = "ReservationPreBook")]
        public List<ReservationPreBook> ReservationPreBook { get; set; }
    }

    [XmlRoot(ElementName = "AlternativeModels")]
    public class AlternativeModels
    {
        [XmlElement(ElementName = "Carmodelid")]
        public string Carmodelid { get; set; }
        [XmlElement(ElementName = "CarModel")]
        public string CarModel { get; set; }
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

    [XmlRoot(ElementName = "Country")]
    public class Country
    {
        [XmlElement(ElementName = "CountryId")]
        public string CountryId { get; set; }
        [XmlElement(ElementName = "CountrySymbol")]
        public string CountrySymbol { get; set; }
        [XmlElement(ElementName = "CountryName")]
        public string CountryName { get; set; }
    }

    [XmlRoot(ElementName = "Gotos")]
    public class Gotos
    {
        [XmlElement(ElementName = "Country")]
        public Country Country { get; set; }
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

}

