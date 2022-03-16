using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "Body")]
public class SabreNotificationContent
{
	[XmlElement(ElementName = "CCC.PNRCHNG")]
	public CCCPNRCHNGClass CCCPNRCHNG { get; set; }


	[XmlRoot(ElementName = "EventTimeStamp")]
	public class EventTimeStamp
	{
		[XmlAttribute(AttributeName = "format")]
		public string Format { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Indicator")]
	public class Indicator
	{
		[XmlElement(ElementName = "hasChanged")]
		public string HasChanged { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "ChangeIndicators")]
	public class ChangeIndicators
	{
		[XmlElement(ElementName = "Indicator")]
		public List<Indicator> Indicator { get; set; }
	}

	[XmlRoot(ElementName = "CCC.PNRCHNG")]
	public class CCCPNRCHNGClass
	{
		[XmlElement(ElementName = "OWNPCC")]
		public string OWNPCC { get; set; }
		[XmlElement(ElementName = "HOMEPCC")]
		public string HOMEPCC { get; set; }
		[XmlElement(ElementName = "Locator")]
		public string Locator { get; set; }
		[XmlElement(ElementName = "EventTimeStamp")]
		public EventTimeStamp EventTimeStamp { get; set; }
		[XmlElement(ElementName = "ChangeIndicators")]
		public ChangeIndicators ChangeIndicators { get; set; }
	}
}

