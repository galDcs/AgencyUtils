using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "CountryList")]
public class OfranGetCountriesListResponse
{
    public CountriesList Countries { get; set; }

    [XmlRoot(ElementName = "Countries")]
    public class CountriesList
    {
        [XmlElement(ElementName = "Country")]
        public List<Country> Countries { get; set; }
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
}