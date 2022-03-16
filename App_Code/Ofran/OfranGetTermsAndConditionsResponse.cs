using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "TermsCondotions")]
public class OfranGetTermsAndConditionsResponse
{
    [XmlElement(ElementName = "Title")]
    public string Title { get; set; }
    [XmlElement(ElementName = "SubTitle1")]
    public string SubTitle1 { get; set; }
    [XmlElement(ElementName = "Content1")]
    public string Content1 { get; set; }
    [XmlElement(ElementName = "SubTitle2")]
    public string SubTitle2 { get; set; }
    [XmlElement(ElementName = "Content2")]
    public string Content2 { get; set; }
    [XmlElement(ElementName = "DestionationTermsTitle")]
    public string DestionationTermsTitle { get; set; }
    [XmlElement(ElementName = "DestionationTermsText")]
    public string DestionationTermsText { get; set; }
}