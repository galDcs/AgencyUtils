using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "ArrayOfPrebookconditions")]
public class OfranGetPrebooksResponse
{
    [XmlElement(ElementName = "Prebookconditions")]
    public List<Prebookcondition> PrebookconditionsList { get; set; }

    [XmlRoot(ElementName = "Prebookconditions")]
    public class Prebookcondition
    {
        [XmlElement(ElementName = "Suppliercode")]
        public string Suppliercode { get; set; }
        [XmlElement(ElementName = "ConditionId")]
        public string ConditionId { get; set; }
        [XmlElement(ElementName = "Condition")]
        public string Condition { get; set; }
        [XmlElement(ElementName = "Conditioncontent")]
        public string Conditioncontent { get; set; }
        [XmlElement(ElementName = "Needsquantity")]
        public bool Needsquantity { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "NeedsComment")]
        public bool NeedsComment { get; set; }
        [XmlElement(ElementName = "Questiontext")]
        public string Questiontext { get; set; }
        [XmlElement(ElementName = "Reminder")]
        public string Reminder { get; set; }
    }
}