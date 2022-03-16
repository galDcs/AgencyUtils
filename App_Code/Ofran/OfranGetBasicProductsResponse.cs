using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "AdditionalProducts")]
public class OfranGetBasicProductsResponse
{
    [XmlElement(ElementName = "Products")]
    public Products ProductsX { get; set; }
    [XmlElement(ElementName = "Success")]
    public string Success { get; set; }
    [XmlElement(ElementName = "ErrorMessage")]
    public string ErrorMessage { get; set; }
    
    [XmlRoot(ElementName = "Products")]
    public class Products
    {
        [XmlElement(ElementName = "AdditionalProduct")]
        public List<OfranAdditionalProduct> AdditionalProducts { get; set; }
    }
}