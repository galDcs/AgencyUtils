using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "FinalPriceNew")]
public class OfranGetPriceDetailsDataResponse
{
    [XmlElement(ElementName = "BasicPrice")]
    public string BasicPrice { get; set; }
    [XmlElement(ElementName = "DisplayBasicPrice")]
    public string DisplayBasicPrice { get; set; }
    [XmlElement(ElementName = "PremiumStationCharge")]
    public string PremiumStationCharge { get; set; }
    [XmlElement(ElementName = "AdditionalProducts")]
    public AdditionalProducts AdditionalProductsX { get; set; }
    [XmlElement(ElementName = "GrossTotal")]
    public string GrossTotal { get; set; }
    [XmlElement(ElementName = "GrossTotalBranchCurrency")]
    public string GrossTotalBranchCurrency { get; set; }
    [XmlElement(ElementName = "DiscountPer")]
    public string DiscountPer { get; set; }
    [XmlElement(ElementName = "Discount")]
    public string Discount { get; set; }
    [XmlElement(ElementName = "HandlingFee")]
    public string HandlingFee { get; set; }
    [XmlElement(ElementName = "CommissionPer")]
    public string CommissionPer { get; set; }
    [XmlElement(ElementName = "VatPer")]
    public string VatPer { get; set; }
    [XmlElement(ElementName = "Commission")]
    public string Commission { get; set; }
    [XmlElement(ElementName = "Vat")]
    public string Vat { get; set; }
    [XmlElement(ElementName = "DomesticVat")]
    public string DomesticVat { get; set; }
    [XmlElement(ElementName = "NetTotal")]
    public string NetTotal { get; set; }
    [XmlElement(ElementName = "NetTotalBranchCurrency")]
    public string NetTotalBranchCurrency { get; set; }
    [XmlElement(ElementName = "BranchCurrencyId")]
    public string BranchCurrencyId { get; set; }
    [XmlElement(ElementName = "BranchCurrency")]
    public string BranchCurrency { get; set; }

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
        public List<OfranAdditionalProduct> AdditionalProduct { get; set; }
    }
}