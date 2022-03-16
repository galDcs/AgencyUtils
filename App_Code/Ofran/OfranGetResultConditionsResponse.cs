using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "ProductDetails")]
public class OfranGetResultConditionsResponse
{
    [XmlElement(ElementName = "IncludedinRate")]
    public IncludedinRate IncludedinRates { get; set; }
    [XmlElement(ElementName = "Extras")]
    public Extras ExtraConditions { get; set; }
    [XmlElement(ElementName = "Informative")]
    public Informative InformativeConditions { get; set; }
    [XmlElement(ElementName = "Importantinformation")]
    public Importantinformation ImportantinformationConditions { get; set; }

	[XmlRoot(ElementName="Condition")]
	public class Condition {
		[XmlElement(ElementName="Description")]
		public string Description { get; set; }
		[XmlElement(ElementName="Content")]
		public string Content { get; set; }
		[XmlElement(ElementName="Reminder")]
		public string Reminder { get; set; }
	}

	[XmlRoot(ElementName="IncludedinRate")]
	public class IncludedinRate {
		[XmlElement(ElementName="Condition")]
		public List<Condition> Condition { get; set; }
	}

	[XmlRoot(ElementName="Extras")]
	public class Extras {
		[XmlElement(ElementName="Condition")]
		public List<Condition> Condition { get; set; }
	}

	[XmlRoot(ElementName="Informative")]
	public class Informative {
		[XmlElement(ElementName="Condition")]
		public List<Condition> Condition { get; set; }
	}

	[XmlRoot(ElementName="Importantinformation")]
	public class Importantinformation {
		[XmlElement(ElementName="Condition")]
		public List<Condition> Condition { get; set; }
	}
}