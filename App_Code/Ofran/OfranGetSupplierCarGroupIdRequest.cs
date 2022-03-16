using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName = "GetSupplierCarGroupById")]
public class OfranGetSupplierCarGroupIdRequest
{
    [XmlElement(ElementName = "supplierCarGroupID")]
    public string SupplierCarGroupId { get; set; }
}