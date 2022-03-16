using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetCountriesList")]
public class OfranGetCountriesListRequest
{
    [XmlElement(ElementName = "webCustomerID")]
    public string WebCustomerID { get; set; }

	public OfranGetCountriesListRequest()
	{		
	}
}