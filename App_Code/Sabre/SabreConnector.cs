using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;

public class SabreConnector
{
    public enum eAlpMethods
    {
        SESSION_CREATE,
        GET_QUEUE
    }

    //private string mApiUrl = "https://webservices.havail.sabre.com"; //Prod
    private string mApiUrl = "https://sws-crt.cert.havail.sabre.com"; //Test

    ApiHandler mApiHandler = new ApiHandler();
    private Dictionary<eAlpMethods, string> mMethods;

    public SabreConnector()
	{
        mMethods = new Dictionary<eAlpMethods, string>();
        mMethods.Add(eAlpMethods.SESSION_CREATE, "");
        mMethods.Add(eAlpMethods.GET_QUEUE,"");
	}

    private string callWebApi(eAlpMethods iMethod, string iContent)
    {
        string result = string.Empty;
        string url = mApiUrl + mMethods[iMethod];

        iContent = @"
<SOAP-ENV:Envelope xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>" +
    iContent +
"</SOAP-ENV:Envelope>";

        result = mApiHandler.SendXmlRequest(url, iContent);

        return result;
    }

    public string GetSessionToken(SabreRequest<SabreSessionCreateRequest> iSessionCreateReq)
    {
        //SabreRequest<SabreSessionCreateRequest> res = null;
        string retVal = string.Empty;
        string reqXml;
        string resXml; 

        try
        {
			Logger.Log("herexx - 1");
            reqXml = getXml(iSessionCreateReq.Header, iSessionCreateReq.Body);
			Logger.Log("herexx - 2");
            //reqXml = Utils.Serialize(iSessionCreateReq);
			resXml = mApiHandler.SendRequest(eRequestType.XML_SABRE, mApiUrl, reqXml);
            //resXml = callWebApi(eAlpMethods.SESSION_CREATE, reqXml);
            resXml = fixResponse(resXml);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(resXml);
            XmlNode node = xmlDoc.GetElementsByTagName("BinarySecurityToken")[0];

            retVal = node.InnerText;
        }
        catch (Exception ex)
        {
            Logger.Log("GetSessionToken Exception. Message = " + ex.Message);
            throw ex;
        }

        return retVal;
    }
	
	public static string removeAttributesFromXml(string iResXml)
    {
        // Removing soap-env to match the pattern of the classes
        iResXml = iResXml.Replace("soap-env:", "");
        // Removing xmlns
        iResXml = Regex.Replace(iResXml, @"<(\/?)([a-zA-Z0-9:]+)( *xmlns[:a-zA-Z0-9]*=""[ =\*:a-zA-Z0-9._\-\/]+"")*", "<$1$2");
        // Change names of Roots from being "or114:XmlData" to "XmlData_or114" to avoid repeatations
        iResXml = Regex.Replace(iResXml, @"(<\/?| )([a-zA-Z0-9-_]+):([a-zA-Z]+)", "$1$3_$2");
        
        return iResXml;
    }

    private string fixResponse(string iResXml)
    {
        iResXml = iResXml.Replace("eb:", "");
        iResXml = iResXml.Replace("wsse:", "");
        iResXml = iResXml.Replace("stl:", "");
        iResXml = iResXml.Replace("soap-env:", "");
        iResXml = iResXml.Replace(" xmlns:soap-env=\"http://schemas.xmlsoap.org/soap/envelope/\"", "");
        iResXml = iResXml.Replace(" xmlns:wsse=\"http://schemas.xmlsoap.org/ws/2002/12/secext\"", "");
        iResXml = iResXml.Replace(" xmlns=\"http://www.opentravel.org/OTA/2002/11\"", "");
        iResXml = iResXml.Replace(" xmlns:eb=\"http://www.ebxml.org/namespaces/messageHeader\"", "");
        iResXml = iResXml.Replace(" xmlns=\"http://webservices.sabre.com/sabreXML/2011/10\"", ""); 
        iResXml = iResXml.Replace(" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"", "");
        iResXml = iResXml.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
        iResXml = iResXml.Replace(" xmlns:stl=\"http://services.sabre.com/STL/v01\"", "");
      
        return iResXml;
    }

    private string getXml<T>(SabreHeader iHeader, T iBody)
    {
        string xml = Utils.Serialize(iHeader);
        xml += "<SOAP-ENV:Body>" + Utils.Serialize(iBody) + "</SOAP-ENV:Body>";
        xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
        xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
		xml = @"<SOAP-ENV:Envelope xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>" +
					xml +
				"</SOAP-ENV:Envelope>";
        return xml;
    }

    public SabreResponse<SabreQueueAccessResponse> GetQueue(SabreRequest<SabreQueueAccessRequest> iQueueAccessReq)
    {
        SabreResponse<SabreQueueAccessResponse> sabreResponse = null;
        string reqXml;
        string resXml; 

        try
        {
            reqXml = getXml(iQueueAccessReq.Header, iQueueAccessReq.Body);
			resXml = mApiHandler.SendRequest(eRequestType.XML_SABRE, mApiUrl, reqXml);
            //resXml = callWebApi(eAlpMethods.GET_QUEUE, reqXml);

            resXml = fixResponse(resXml);
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(resXml);
            //XmlNode node = xmlDoc.GetElementsByTagName("Body")[0];

            sabreResponse = Utils.Deserialize<SabreResponse<SabreQueueAccessResponse>>(resXml);
        }
        catch (Exception ex)
        {
            Logger.Log("GetQueue Exception. Message = " + ex.Message);
            throw ex;
        }

        return sabreResponse;
    }


    public SabreResponse<T2> GetSabreResponse<T1, T2>(SabreRequest<T1> iSabreRequest)
    {
        SabreResponse<T2> sabreResponse = null;
        string reqXml;
        string resXml;

        try
        {
            reqXml = getXml(iSabreRequest.Header, iSabreRequest.Body);
            resXml = mApiHandler.SendRequest(eRequestType.XML_SABRE, mApiUrl, reqXml);
            resXml = fixResponse(resXml);

            sabreResponse = Utils.Deserialize<SabreResponse<T2>>(resXml);
        }
        catch (Exception ex)
        {
            Logger.Log("Exception caught. Message: " + ex.Message + "\nTrace: " + ex.StackTrace);
            throw ex;
        }

        return sabreResponse;
    }
    

    public SabreResponse<SabreGetReservationResponse> GetReservationRS(SabreRequest<SabreGetReservationRQ> iGetReservationReq)
    {
        SabreResponse<SabreGetReservationResponse> sabreResponse = null;
        string reqXml;
        string resXml;

        try
        {
            reqXml = getXml(iGetReservationReq.Header, iGetReservationReq.Body);
            resXml = mApiHandler.SendRequest(eRequestType.XML_SABRE, mApiUrl, reqXml);
            resXml = removeAttributesFromXml(resXml);
            //Logger.Log("resXml = " + resXml);
            sabreResponse = Utils.Deserialize<SabreResponse<SabreGetReservationResponse>>(resXml);
        }
        catch (Exception ex)
        {
            Logger.Log("GetReservationRS Exception. Message = " + ex.Message);
            throw ex;
        }

        return sabreResponse;
    }
}