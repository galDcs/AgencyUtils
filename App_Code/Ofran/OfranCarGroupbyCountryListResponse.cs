using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "CountryCarLists")]
public class OfranCarGroupbyCountryListResponse
{
    [XmlElement(ElementName = "CountryCarList")]
    public CountryCarList CountryCarsList { get; set; }    

    [XmlRoot(ElementName = "CountryCars")]
    public class CountryCars
    {
        [XmlElement(ElementName = "CountryId")]
        public string CountryId { get; set; }
        [XmlElement(ElementName = "CountryCode")]
        public string CountryCode { get; set; }
        [XmlElement(ElementName = "OfranCarGroupList")]
        public OfranCarGroupList OfranCarGroupList { get; set; }
    }

    [XmlRoot(ElementName = "OfranCarGroup")]
    public class OfranCarGroup
    {
        [XmlElement(ElementName = "OfranCarGroupId")]
        public string OfranCarGroupId { get; set; }
        [XmlElement(ElementName = "OfranCarGroupName")]
        public string OfranCarGroupName { get; set; }
        [XmlElement(ElementName = "DisplayOrder")]
        public string DisplayOrder { get; set; }
    }

    [XmlRoot(ElementName = "OfranCarGroupList")]
    public class OfranCarGroupList
    {
        [XmlElement(ElementName = "OfranCarGroup")]
        public List<OfranCarGroup> OfranCarGroup { get; set; }
    }

    [XmlRoot(ElementName = "CountryCarList")]
    public class CountryCarList
    {
        [XmlElement(ElementName = "CountryCars")]
        public List<CountryCars> CountryCars { get; set; }
    }
}