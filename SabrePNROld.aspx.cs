using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SabrePNROld : System.Web.UI.Page
{
    //MessageHeader
    private string mPcc = "K9HK";
    private string mPcc2 = "K9HK";
    private string mFromPartyId = "Agency"; //this name has no connection to Agency2000...
    private string mToPartyId = "Sabre_API";

    //Security > UsernameToken
    private string mUsername = "516420";
    private string mPassword = "T0H85T2";
    private string mOrganization = "T4QK";
    private string mDomain = "AA";
    private SabreConnector mSabreConnector = new SabreConnector();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string sabreSession = getSession();
        
        if (!string.IsNullOrEmpty(sabreSession))
        {
            queueAccess(sabreSession);
        }
    }

    private string getSession()
    {
        string sabreSession = string.Empty;

        SabreRequest<SabreSessionCreateRequest> sessionCreateReq = new SabreRequest<SabreSessionCreateRequest>();

        sessionCreateReq = setSabreHeader<SabreSessionCreateRequest>("SessionCreateRQ", "SessionCreateRQ");
        sessionCreateReq.Body = new SabreSessionCreateRequest();

        try
        {
            //SabreRequest<SabreSessionCreateRequest> sessionRes = sabreConnector.GetSessionToken(sessionCreateReq);
            sabreSession = mSabreConnector.GetSessionToken(sessionCreateReq);
        }
        catch (Exception ex)
        {
            Response.Write("<br/>getSession Exception. Message = " + ex.Message);
            Response.Write("<br/>Trace = " + ex.StackTrace);
        }

        return sabreSession;
    }

    private void queueAccess(string iSabreSession)
    {
        chkListPNRS.Items.Clear();

        SabreRequest<SabreQueueAccessRequest> queueAccess = new SabreRequest<SabreQueueAccessRequest>();
        queueAccess = setSabreHeader<SabreQueueAccessRequest>("QueueAccessLLSRQ", "QueueAccessLLSRQ", iSabreSession);
        queueAccess.Body = new SabreQueueAccessRequest();
        queueAccess.Body.ReturnHostCommand = "true";
        queueAccess.Body.Version = "2.1.0";
        queueAccess.Body.QueueIdentifierX = new SabreQueueAccessRequest.QueueIdentifier();
        queueAccess.Body.QueueIdentifierX.Number = "501"; //TODO: from db maybe?
        queueAccess.Body.QueueIdentifierX.PseudoCityCode = mPcc;
        queueAccess.Body.QueueIdentifierX.List = new SabreQueueAccessRequest.List();
        queueAccess.Body.QueueIdentifierX.List.Ind = "true";
        queueAccess.Body.QueueIdentifierX.List.PrimaryPassenger = "true";

        try
        {
            SabreResponse<SabreQueueAccessResponse> res = mSabreConnector.GetQueue(queueAccess);

            if (res != null)
            {
                string text;
                DateTime departureDate;
                string departureDateStr;

                foreach (SabreQueueAccessResponse.LineClass line in res.Body.QueueAccess.Line)
                {
                    DateTime.TryParse(line.DateTime, out departureDate);
                    departureDateStr = departureDate.ToString("dd/MM/yy");
                    text = "<span class='clickkk' style='width:85px;float:left;'>" + line.Number + ". " + line.UniqueID.ID + ":</span><span style='width:300px;float:left;'>" + line.POS.Source.PseudoCityCode + " --- " + line.POS.Source.AgentSine + " --- " + departureDateStr + " --- " + line.PassengerName + "</span> ";

                    chkListPNRS.Items.Add(new ListItem(text, line.UniqueID.ID));
                }
            }
        }
        catch (Exception hh)
        {
            Response.Write("<h2>queueAccess: <br/>" + hh.Message + "</h2>");
        }
    }

    private SabreRequest<T> setSabreHeader<T>(string iAction, string iService, string iSabreSession = null)
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