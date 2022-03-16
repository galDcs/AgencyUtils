using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

public class SabreLdsConnector
{
    public enum eAlpMethods
    {
        RETRIEVE_RESERVATION
    }

    private string mApiUrl = "https://ldss.sabre.co.il/services/v320/LdsReservation?wsdl";

    ApiHandler mApiHandler = new ApiHandler();
    private Dictionary<eAlpMethods, string> mMethods;

    public SabreLdsConnector()
    {
        mMethods = new Dictionary<eAlpMethods, string>
        {
            { eAlpMethods.RETRIEVE_RESERVATION, "" }
        };
    }

   
    private string fixXml(string iXml)
    {
        iXml = iXml.Replace("utf-16", "utf-8");
        iXml = Regex.Replace(iXml, "<(Envelope)[^>]*>", "<$1 xmlns:env=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
        iXml = Regex.Replace(iXml, "<(/)?(Body|Envelope)([^>]*)>", "<$1soap:$2$3>");
        iXml = Regex.Replace(iXml, "<(/)?(Header)([^>]*)>", "<$1env:$2$3>");
        iXml = Regex.Replace(iXml, "<(retrieveReservation)([^>]*)>", "<ns0:$1 xmlns:ns0=\"http://v320.ws.lds.lognet.com/\">");
        iXml = iXml.Replace("/retrieveReservation", "/ns0:retrieveReservation");
        return iXml;
    }

    private string removePrefixAndXmlns(string iXml)
    {
        iXml = Regex.Replace(iXml, "<(/)?([a-zA-Z0-9]+:)([a-zA-Z]+)( xmlns[^>]*)*(/)?>", "<$1$3$5>");
        return iXml;
    }

    public SabreLdsRetrieveReservationResponse GetRetreiveReservationResponse(SabreLdsRetrieveReservationRequest iSabreRequest)
    {
        SabreLdsRetrieveReservationResponse sabreResponse = null;
        string reqXml = string.Empty;
        string resXml = string.Empty;

        try
        {
            reqXml = fixXml(Utils.Serialize(iSabreRequest));
            resXml = mApiHandler.SendRequest(eRequestType.XML_SABRE, mApiUrl, reqXml);
            using (StreamWriter writer = new StreamWriter(File.Open(HttpContext.Current.Server.MapPath("~\\Response13.xml"), FileMode.OpenOrCreate)))
            {
                writer.Write(resXml);
            }
            // DEBUG
            //resXml = File.ReadAllText(HttpContext.Current.Server.MapPath("~\\Response.xml"));
            sabreResponse = Utils.Deserialize<SabreLdsRetrieveReservationResponse>(removePrefixAndXmlns(resXml));
        }
        catch (Exception ex)
        {
            Logger.Log("Exception caught. Message: " + ex.Message + "\nTrace: " + ex.StackTrace);
            throw ex;
        }

        return sabreResponse;
    }
}