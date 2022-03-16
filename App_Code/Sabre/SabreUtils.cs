using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SabreUtils
/// </summary>
public class SabreUtils
{
    //MessageHeader
	//Agency credentials: 516420
	//Agency credentials: cert - a3d5g7j9  ============== old - (T0H85T2)
	//Agency credentials: T4QK
    private static string mPcc = "T4QK"; // lachish: "W5TK";//K9HK
    private static string mPcc2 = "T4QK"; // lachish: "W5TK";//K9HK
    private static string mFromPartyId = "Agency"; //this name has no connection to Agency2000...
    private static string mToPartyId = "Sabre_API";

    //Security > UsernameToken
    private static string mUsername = "516420"; // lachish: "934612";//516420
    private static string mPassword = "a3d5g7j9"; // lachish: "ERETZ48";//T0H85T2
    private static string mOrganization = "T4QK"; // lachish: "W5TK";//K9HK
    private static string mDomain = "AA";
    private static SabreConnector mSabreConnector = new SabreConnector();


    public static string GetSession()
    {
        string sabreSession = string.Empty;

        SabreRequest<SabreSessionCreateRequest> sessionCreateReq = new SabreRequest<SabreSessionCreateRequest>();

        sessionCreateReq = SetSabreHeader<SabreSessionCreateRequest>("SessionCreateRQ", "SessionCreateRQ");
        sessionCreateReq.Body = new SabreSessionCreateRequest();

        try
        {
            //SabreRequest<SabreSessionCreateRequest> sessionRes = sabreConnector.GetSessionToken(sessionCreateReq);
            sabreSession = mSabreConnector.GetSessionToken(sessionCreateReq);
        }
        catch (Exception e)
        {
            Logger.Log("GetSession Exception. Message: " + e.Message + "\nTrace: " + e.StackTrace);
        }

        return sabreSession;
    }


    public static SabreRequest<T> SetSabreHeader<T>(string iAction, string iService, string iSabreSession = null)
    {
        SabreRequest<T> sabreRequest = new SabreRequest<T>();

        sabreRequest.Header = new SabreHeader();
        sabreRequest.Header.Security = new SabreHeader.SecurityClass();
        if (string.IsNullOrEmpty(iSabreSession))
        {
            sabreRequest.Header.Security.UsernameToken = new SabreHeader.UsernameToken();
            sabreRequest.Header.Security.UsernameToken.Domain = mDomain;
            sabreRequest.Header.Security.UsernameToken.Organization = mOrganization;
            sabreRequest.Header.Security.UsernameToken.Password = mPassword;
            sabreRequest.Header.Security.UsernameToken.Username = mUsername;
        }
        else
        {
            sabreRequest.Header.Security.BinarySecurityToken = new SabreHeader.BinarySecurityToken();
            sabreRequest.Header.Security.BinarySecurityToken.ValueType = "String";
            sabreRequest.Header.Security.BinarySecurityToken.EncodingType = "Base64Binary";
            sabreRequest.Header.Security.BinarySecurityToken.Text = iSabreSession;
        }

        sabreRequest.Header.MessageHeader = new SabreHeader.MessageHeaderClass();
        sabreRequest.Header.MessageHeader.Action = iAction;
        sabreRequest.Header.MessageHeader.Service = iService;
        sabreRequest.Header.MessageHeader.ConversationId = "SessionCreateRQ_ConvId";
        sabreRequest.Header.MessageHeader.CPAId = mPcc;
        sabreRequest.Header.MessageHeader.From = new SabreHeader.From();
        sabreRequest.Header.MessageHeader.From.PartyId = mFromPartyId;
        sabreRequest.Header.MessageHeader.To = new SabreHeader.To();
        sabreRequest.Header.MessageHeader.To.PartyId = mToPartyId;

        return sabreRequest;
    }

}