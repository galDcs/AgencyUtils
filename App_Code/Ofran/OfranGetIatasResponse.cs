using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "IataCodesList")]
public class OfranGetIatasResponse
{
    [XmlElement(ElementName = "Iatacodes")]
    public Iatacodes IatacodesElem { get; set; }

    [XmlRoot(ElementName = "Iatacode")]
    public class Iatacode
    {
        [XmlElement(ElementName = "IataCodeId")]
        public string IataCodeId { get; set; }
        [XmlElement(ElementName = "IataName")]
        public string IataName { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "CountryId")]
        public string CountryId { get; set; }
        [XmlElement(ElementName = "Preferred")]
        public string Preferred { get; set; }
    }

    [XmlRoot(ElementName = "Iatacodes")]
    public class Iatacodes
    {
        [XmlElement(ElementName = "Iatacode")]
        public List<Iatacode> Iatacode { get; set; }
    }

	public OfranGetIatasResponse()
	{
	}
}