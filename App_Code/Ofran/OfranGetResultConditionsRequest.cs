using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName="GetResultConditions")]
public class OfranGetResultConditionsRequest
{
    [XmlElement(ElementName = "priceCatalogID")]
    public string PriceCatalogID { get; set; }
    [XmlElement(ElementName = "supplierCarGroupID")]
    public string SupplierCarGroupID { get; set; }
    [XmlElement(ElementName = "AdditionalProducts")]
    public AdditionalProducts AdditionalProductsX { get; set; }
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }
    [XmlElement(ElementName = "languageCode")]
    public string LanguageCode { get; set; }

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
}