using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot(ElementName="Envelope")]
public class SabreRequest<T>
{
    [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public SabreHeader Header { get; set; }
    [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public T Body { get; set; }
    [XmlAttribute(AttributeName = "SOAP-ENV", Namespace = "http://www.w3.org/2000/xmlns/")]
    public string SOAPENV { get; set; }
    
}

[XmlRoot(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class SabreHeader
{
    [XmlElement(ElementName = "MessageHeader", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
    public MessageHeaderClass MessageHeader { get; set; }
    [XmlElement(ElementName = "Security", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
    public SecurityClass Security { get; set; }

    [XmlRoot(ElementName = "Security", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
    public class SecurityClass
    {
        [XmlElement(ElementName = "UsernameToken", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
        public UsernameToken UsernameToken { get; set; }
        [XmlElement(ElementName = "BinarySecurityToken", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
        public BinarySecurityToken BinarySecurityToken { get; set; }
        [XmlAttribute(AttributeName = "wsse", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wsse { get; set; }
    }

    [XmlRoot(ElementName = "From", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
    public class From
    {
        [XmlElement(ElementName = "PartyId", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public string PartyId { get; set; }
    }

    [XmlRoot(ElementName = "To", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
    public class To
    {
        [XmlElement(ElementName = "PartyId", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public string PartyId { get; set; }
    }

    [XmlRoot(ElementName = "MessageHeader", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
    public class MessageHeaderClass
    {
        [XmlElement(ElementName = "From", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public From From { get; set; }
        [XmlElement(ElementName = "To", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public To To { get; set; }
        [XmlElement(ElementName = "CPAId", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public string CPAId { get; set; }
        [XmlElement(ElementName = "ConversationId", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public string ConversationId { get; set; }
        [XmlElement(ElementName = "Service", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public string Service { get; set; }
        [XmlElement(ElementName = "Action", Namespace = "http://www.ebxml.org/namespaces/messageHeader")]
        public string Action { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "BinarySecurityToken", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
    public class BinarySecurityToken
    {
        [XmlAttribute(AttributeName = "valueType")]
        public string ValueType { get; set; }
        [XmlAttribute(AttributeName = "EncodingType")]
        public string EncodingType { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "UsernameToken", Namespace = "http://schemas.xmlsoap.org/ws/2002/12/secext")]
    public class UsernameToken
    {
        //[XmlAttribute(AttributeName = "Username", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Username { get; set; }
        //[XmlAttribute(AttributeName = "Password", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Password { get; set; }
        //[XmlAttribute(AttributeName = "Organization", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Organization { get; set; }
        //[XmlAttribute(AttributeName = "Domain", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Domain { get; set; }
    }
}

