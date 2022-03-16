using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "CarGroup")]
public class OfranGetSupplierCarGroupIdResponse
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
    public AlternativeModels AlternativeModelsList { get; set; }
    [XmlElement(ElementName = "SupplierCarGroup")]
    public string SupplierCarGroup { get; set; }

    [XmlRoot(ElementName = "AlternativeModel")]
    public class AlternativeModel
    {
        [XmlElement(ElementName = "Carmodelid")]
        public string Carmodelid { get; set; }
        [XmlElement(ElementName = "CarModel")]
        public string CarModel { get; set; }
    }

    [XmlRoot(ElementName = "AlternativeModels")]
    public class AlternativeModels
    {
        [XmlElement(ElementName = "AlternativeModel")]
        public List<AlternativeModel> AlternativeModelsList { get; set; }
    }
}