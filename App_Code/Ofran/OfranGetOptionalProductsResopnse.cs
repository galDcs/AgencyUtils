using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "Root")]
public class OfranGetOptionalProductsResopnse
{
    [XmlElement(ElementName = "AdditionalProducts")]
    public AdditionalProducts AdditionalProductsX { get; set; }

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
        [XmlElement(ElementName = "Success")]
        public string Success { get; set; }
        [XmlElement(ElementName = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
