using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SabreENS : System.Web.UI.Page
{
	public const string mUrl = "151.193.58.254"; //Sabre ENS ip 1
	public const string mUrl2 = "151.193.119.48"; //Sabre ENS ip 2
	
	const string mAcknowledgmentMessage =
		@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
		<soap-env:Envelope xmlns:soap-
			env=""http://schemas.xmlsoap.org/soap/envelope/""
			xmlns:eb=""http://www.ebxml.org/namespaces/messageHeader""
			xmlns:swse=""http://wse.sabre.com/eventing""
			xmlns:wsa=""http://schemas.xmlsoap.org/ws/2004/08/addressing""
			xmlns:wse=""http://schemas.xmlsoap.org/ws/2004/08/eventing"">
			<soap-env:Header>
				<eb:MessageHeader eb:version=""1.0"" soap-env:mustUnderstand=""0"">
				<wsa:MessageID>56d6b85a-467e-4da2-a6ac-3860f244912a</wsa:MessageID>
				<wse:Identifer>7e183baf-9f61-46c5-b9af-4e3006811550</wse:Identifer>
			</soap-env:Header>
			<soap-env:Body>
				<swse:Response>
					<swse:Status>OK</swse:Status>
					<swse:Received>@@DATARECEIVED@@</swse:Received>
					<swse:Processed></swse:Processed>
				</swse:Response>
			</soap-env:Body>
		</soap-env:Envelope>";

    protected void Page_Load(object sender, EventArgs e)
    {
		//working!
		//Response.StatusCode = 202;
		//return;
		Logger.Log(new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd());

		//sendAcknowledgment();
		
		//ProcessRequest(context);
    }
	
	private static void sendAcknowledgment()
	{
		//Logger.Log("ip = " + Request.ServerVariables["remote_addr"]);
		//string ip = Request.ServerVariables["remote_addr"];
		//Logger.Log("ip = " + ip);
		
		string currentAcknowledgmentMessage = mAcknowledgmentMessage.Replace("@@DATARECEIVED@@", DateTime.Now.Millisecond.ToString());
		HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(mUrl);
		webRequest.Method = "GET";
		webRequest.ContentType = "text/xml; charset=utf-8";
		webRequest.ContentLength = currentAcknowledgmentMessage.Length;
		
		using (StreamWriter stream = new StreamWriter(webRequest.GetRequestStream()))
		{
			stream.Write(currentAcknowledgmentMessage);
		}
		Logger.Log("after send ack");
		
		WebResponse response = webRequest.GetResponse();
		
	}

	private static void ProcessRequest(HttpListenerContext context)
	{
		// Get the data from the HTTP stream
		var notification = new StreamReader(context.Request.InputStream).ReadToEnd();
		proccessResponse(notification);
	}

	private static void proccessResponse(string iXmlResponse)
	{
		iXmlResponse = cleanXml(iXmlResponse);
		SabreNotificationContent sabreNotification = Utils.Deserialize<SabreNotificationContent>(iXmlResponse);
		notifySabrePNR(sabreNotification);
	}

	private static void notifySabrePNR(SabreNotificationContent iSabreNotification)
	{
		string url = "SabrePNR.aspx";
		string log = string.Empty;
		int changeNumber = 0;
		string queryString = iSabreNotification.CCCPNRCHNG.ChangeIndicators.Indicator
			.Aggregate("?PNR=" + iSabreNotification.CCCPNRCHNG.Locator, (acc, curr) => getBool(curr.HasChanged) ? acc + "CN" + changeNumber++ + "=" + curr.Name.Replace(" ", "_") + "&": string.Empty);

		if(changeNumber > 0)
		{
			url += queryString.TrimEnd('&');
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
			webRequest.Method = "GET";
			WebResponse response = webRequest.GetResponse();
		}
	}

	private static bool getBool(string iBoolAsString)
	{
		return iBoolAsString.ToUpper().Equals("Y") || iBoolAsString.ToLower().Equals("true") || iBoolAsString.ToUpper().Equals("T");
	}

	private static string cleanXml(string iXml)
	{
		return Regex.Replace(iXml, "<(/)?[a-zA-Z0-9-_]+:([^>]+)>", "<$1$2>");
	}
	
    private void popUpMessage(string iMessage)
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Popup", "alert('" + iMessage + "');", true);
    }
}