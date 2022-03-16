using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "options")]
public class OfranGetPossibleUpgradesResponse
{
    [XmlElement(ElementName = "option")]
    public List<Option> Options { get; set; }

    public class Option
    {
        [XmlElement(ElementName = "cargroup")]
        public Cargroup CarGroup { get; set; }
        [XmlElement(ElementName = "contracts")]
        public Contracts ContractsX { get; set; }
    }

    [XmlRoot(ElementName = "cargroup")]
    public class Cargroup
    {
        [XmlElement(ElementName = "suppliercargroupid")]
        public string Suppliercargroupid { get; set; }
        [XmlElement(ElementName = "carmodel")]
        public string Carmodel { get; set; }
        [XmlElement(ElementName = "PictureFile")]
        public string PictureFile { get; set; }
        [XmlElement(ElementName = "numdoors")]
        public string Numdoors { get; set; }
        [XmlElement(ElementName = "reccnumofadults")]
        public string Reccnumofadults { get; set; }
        [XmlElement(ElementName = "reccnumofkids")]
        public string Reccnumofkids { get; set; }
        [XmlElement(ElementName = "reccnumofsuitcases")]
        public string Reccnumofsuitcases { get; set; }
        [XmlElement(ElementName = "reccnumofhandbags")]
        public string Reccnumofhandbags { get; set; }
        [XmlElement(ElementName = "sippcode")]
        public string Sippcode { get; set; }
        [XmlElement(ElementName = "Ofrancargroupid")]
        public string Ofrancargroupid { get; set; }
        [XmlElement(ElementName = "Ofrancargroup")]
        public string Ofrancargroup { get; set; }
    }

    [XmlRoot(ElementName = "Products")]
    public class Products
    {
        [XmlElement(ElementName = "AdditionalProduct")]
        public OfranAdditionalProduct AdditionalProduct { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalProducts")]
    public class AdditionalProducts
    {
        [XmlElement(ElementName = "Products")]
        public Products Products { get; set; }
    }

    [XmlRoot(ElementName = "contract")]
    public class Contract
    {
        [XmlElement(ElementName = "contractname")]
        public string Contractname { get; set; }
        [XmlElement(ElementName = "subcontractid")]
        public string Subcontractid { get; set; }
        [XmlElement(ElementName = "pricecatalogueid")]
        public string Pricecatalogueid { get; set; }
        [XmlElement(ElementName = "basicprice")]
        public string Basicprice { get; set; }
        [XmlElement(ElementName = "handlingfee")]
        public string Handlingfee { get; set; }
        [XmlElement(ElementName = "premiumfee")]
        public string Premiumfee { get; set; }
        [XmlElement(ElementName = "nettotal")]
        public string Nettotal { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "currencyId")]
        public string CurrencyId { get; set; }
        [XmlElement(ElementName = "SupplierPricecatalogueId")]
        public string SupplierPricecatalogueId { get; set; }
        [XmlElement(ElementName = "IsLiveRate")]
        public string IsLiveRate { get; set; }
        [XmlElement(ElementName = "DisplayBasicPrice")]
        public string DisplayBasicPrice { get; set; }
        [XmlElement(ElementName = "AdditionalProducts")]
        public AdditionalProducts AdditionalProducts { get; set; }

        public string PremiumFee { get; set; }
    }

    [XmlRoot(ElementName = "contracts")]
    public class Contracts
    {
        [XmlElement(ElementName = "contract")]
        public Contract Contract { get; set; }
    }
}