using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft;

public enum eRequestType 
{
	JSON,
	XML,
	DIRECT,
	XML_SABRE,
	POST_DATA
}
	
public class ApiHandler
{    
    private string mUrl { get; set; }
    
	public ApiHandler()
	{
	}

    public ApiHandler(string iUrl)
    {
        mUrl = iUrl;
    }

    public string SendRequest(string iUrl, string iContent)
    {
        string result = string.Empty;
        bool isJson = true;

        mUrl = iUrl;
        result = SendRequest(iContent, false);

        return result;
    }

    public string SendJsonRequest(string iUrl, string iContent)
    {
        string result = string.Empty;
        bool isJson = true;

        mUrl = iUrl;
        result = SendRequest(iContent, isJson);

        return result;
    }

    public string SendXmlRequest(string iUrl, string iContent)
    {
        string result = string.Empty;
        bool isJson = false;

        mUrl = iUrl;
        result = SendRequest(iContent, isJson);

        return result;
    }

    public string SendRequest(string iContent, bool iIsJsonContent)
    {
    	eRequestType reqType;
    	if(iIsJsonContent)
    	{
    		reqType = eRequestType.JSON;
    	}
    	else
    	{
    		reqType = eRequestType.XML;
    	}
    	
    	string retVal = SendRequest(reqType, mUrl, iContent);
    	
    	return retVal;
    }
    
    public string SendRequest(eRequestType iRequestType, string iUrl, string iContent)
    {
        string result = string.Empty;
        HttpWebRequest request = null;

        //In case need to connect to a Tls 1.2 remove comment
        ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        ServicePointManager.SecurityProtocol &= SecurityProtocolType.Tls;
        ServicePointManager.SecurityProtocol &= SecurityProtocolType.Ssl3;
        ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072;
		bool isTryAgain = true;
		int tries = 0;
		string url = iUrl;
        string method = string.Empty;
        string contentType = string.Empty;
        string accept = string.Empty;
        string mediaType = string.Empty;
	
		switch(iRequestType)
        {
            case eRequestType.DIRECT:
                url += iContent;
                method = "GET";
                break;
            case eRequestType.JSON:
                contentType = "application/json; charset=utf-8;";
				if (!url.ToLower().Contains("api.travelcenter.co.il"))
				{
					contentType = "application/x-www-form-urlencoded;" + contentType;
				}
				accept = "application/json";
				mediaType = "application/json";
                method = "POST";
                break;
			case eRequestType.POST_DATA:
                contentType = "application/x-www-form-urlencoded; charset=utf-8;";
                method = "POST";
                break;
            case eRequestType.XML:
                contentType = "application/x-www-form-urlencoded; text/xml; charset=utf-8";
                method = "POST";
                break;
			case eRequestType.XML_SABRE:
                contentType = "text/xml";
                method = "POST";
                break;
        }
		
    	request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = contentType;
		request.Method = method;
		//Logger.Log(method);
		if (accept != string.Empty)
		{
			request.Accept = accept;
			request.MediaType= mediaType;
		}
		request.KeepAlive = false;
		request.ContinueTimeout = 100;
		Logger.Log("Request = " + iContent);

		if (iRequestType != eRequestType.DIRECT)
		{
			byte[] postBytes = Encoding.UTF8.GetBytes(iContent);
			request.ContentLength = postBytes.Length;
			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(postBytes, 0, postBytes.Length);
			}
		}
		
		//while (isTryAgain)
		//{
			//Logger.Log("In while");
			
			try
			{
				//httpWebRequestDump(request);
				//Logger.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
				//logHttpRequest(request);
				
				WebResponse response = (HttpWebResponse)request.GetResponse();
				Stream postResponseStream = response.GetResponseStream();
				StreamReader sr = new StreamReader(postResponseStream);
				result = sr.ReadToEnd();
				//Logger.Log("response = " + result);
				//break;
				//isTryAgain = false;
				//Logger.Log("1isTryAgain = " + isTryAgain);
				response.Close();
                postResponseStream.Close();
                sr.Close();
			}
			catch (WebException webEx)
			{
				try
				{
					string text = webEx.Message;
					var pageContent = new StreamReader(webEx.Response.GetResponseStream()).ReadToEnd();
					WebResponse errResp = webEx.Response;
					using (Stream respStream = errResp.GetResponseStream())
					{
						StreamReader reader = new StreamReader(respStream);
						text += ", " + reader.ReadToEnd();
					}
					text = text + "<br/>" + pageContent;
					Logger.Log("Web Exception. Message = " + text + ", Trace = " + webEx.StackTrace);				
				}
				catch(Exception exInWeb)
				{
					Logger.Log("** in Web Exception. Message = " + exInWeb.Message + ", Trace = " + exInWeb.StackTrace);	
				}
			}
			catch (Exception ex)
			{
				Logger.Log("exception Message = " + ex.Message + ", Trace = " + ex.StackTrace);
			}
			//Logger.Log("In while last row");
			//if (tries >= 3)
			//{
			//	break;
			//	isTryAgain = false;
			//}
			//tries++;
		//}
		
		//Logger.Log("tries = " + tries);
		Logger.Log("Response = " + result);
        return result;
    }

    //In case need to connect to a Tls 1.2
    public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
	
	private string httpWebRequestDump(HttpWebRequest hwr)
	{
		foreach (string key in hwr.Headers.Keys)
        {
            Logger.Log(key + ": " + hwr.Headers[key]);
        } 
		return "";
	}
	
	private void logHttpRequest(HttpWebRequest request)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("[Accept] = {0}", request.Accept);
        sb.AppendFormat("{0}[Address] = {1}", Environment.NewLine, request.Address);
        sb.AppendFormat("{0}[AllowAutoRedirect] = {1}", Environment.NewLine, request.AllowAutoRedirect);
        //sb.AppendFormat("{0}[AllowReadStreamBuffering] = {1}", Environment.NewLine, request.AllowReadStreamBuffering);
        sb.AppendFormat("{0}[AllowWriteStreamBuffering] = {1}", Environment.NewLine, request.AllowWriteStreamBuffering);
        sb.AppendFormat("{0}[AuthenticationLevel] = {1}", Environment.NewLine, request.AuthenticationLevel);
        sb.AppendFormat("{0}[AutomaticDecompression] = {1}", Environment.NewLine, request.AutomaticDecompression);
        sb.AppendFormat("{0}[CachePolicy] = {1}", Environment.NewLine, request.CachePolicy);
        sb.AppendFormat("{0}[ClientCertificates] = {1}", Environment.NewLine, request.ClientCertificates);
        sb.AppendFormat("{0}[Connection] = {1}", Environment.NewLine, request.Connection);
        sb.AppendFormat("{0}[ConnectionGroupName] = {1}", Environment.NewLine, request.ConnectionGroupName);
        sb.AppendFormat("{0}[ContentLength] = {1}", Environment.NewLine, request.ContentLength);
        sb.AppendFormat("{0}[ContentType] = {1}", Environment.NewLine, request.ContentType);
        sb.AppendFormat("{0}[ContinueDelegate] = {1}", Environment.NewLine, request.ContinueDelegate);
        //sb.AppendFormat("{0}[ContinueTimeout] = {1}", Environment.NewLine, request.ContinueTimeout);
        sb.AppendFormat("{0}[CookieContainer] = {1}", Environment.NewLine, request.CookieContainer);
        //sb.AppendFormat("{0}[CreatorInstance] = {1}", Environment.NewLine, request.CreatorInstance);
        sb.AppendFormat("{0}[Credentials] = {1}", Environment.NewLine, request.Credentials);
        //sb.AppendFormat("{0}[Date] = {1}", Environment.NewLine, request.Date);
        //sb.AppendFormat("{0}[DefaultCachePolicy] = {1}", Environment.NewLine, request.DefaultCachePolicy);
        //sb.AppendFormat("{0}[DefaultMaximumErrorResponseLength] = {1}", Environment.NewLine, request.DefaultMaximumErrorResponseLength);
        //sb.AppendFormat("{0}[DefaultMaximumResponseHeadersLength] = {1}", Environment.NewLine, request.DefaultMaximumResponseHeadersLength);
        sb.AppendFormat("{0}[Expect] = {1}", Environment.NewLine, request.Expect);
        sb.AppendFormat("{0}[HaveResponse] = {1}", Environment.NewLine, request.HaveResponse);
        sb.AppendFormat("{0}[Headers] = {1}", Environment.NewLine, request.Headers);
        //sb.AppendFormat("{0}[Host] = {1}", Environment.NewLine, request.Host);
        sb.AppendFormat("{0}[IfModifiedSince] = {1}", Environment.NewLine, request.IfModifiedSince);
        sb.AppendFormat("{0}[ImpersonationLevel] = {1}", Environment.NewLine, request.ImpersonationLevel);
        sb.AppendFormat("{0}[KeepAlive] = {1}", Environment.NewLine, request.KeepAlive);
        sb.AppendFormat("{0}[MaximumAutomaticRedirections] = {1}", Environment.NewLine, request.MaximumAutomaticRedirections);
        sb.AppendFormat("{0}[MaximumResponseHeadersLength] = {1}", Environment.NewLine, request.MaximumResponseHeadersLength);
        sb.AppendFormat("{0}[MediaType] = {1}", Environment.NewLine, request.MediaType);
        sb.AppendFormat("{0}[Method] = {1}", Environment.NewLine, request.Method);
        sb.AppendFormat("{0}[Pipelined] = {1}", Environment.NewLine, request.Pipelined);
        sb.AppendFormat("{0}[PreAuthenticate] = {1}", Environment.NewLine, request.PreAuthenticate);
        sb.AppendFormat("{0}[ProtocolVersion] = {1}", Environment.NewLine, request.ProtocolVersion);
        sb.AppendFormat("{0}[Proxy] = {1}", Environment.NewLine, request.Proxy);
        sb.AppendFormat("{0}[ReadWriteTimeout] = {1}", Environment.NewLine, request.ReadWriteTimeout);
        sb.AppendFormat("{0}[Referer] = {1}", Environment.NewLine, request.Referer);
        sb.AppendFormat("{0}[RequestUri] = {1}", Environment.NewLine, request.RequestUri);
        sb.AppendFormat("{0}[SendChunked] = {1}", Environment.NewLine, request.SendChunked);
        //sb.AppendFormat("{0}[ServerCertificateValidationCallback] = {1}", Environment.NewLine, request.ServerCertificateValidationCallback);
        sb.AppendFormat("{0}[ServicePoint] = {1}", Environment.NewLine, request.ServicePoint);
        //sb.AppendFormat("{0}[SupportsCookieContainer] = {1}", Environment.NewLine, request.SupportsCookieContainer);
        sb.AppendFormat("{0}[Timeout] = {1}", Environment.NewLine, request.Timeout);
        sb.AppendFormat("{0}[TransferEncoding] = {1}", Environment.NewLine, request.TransferEncoding);
        sb.AppendFormat("{0}[UnsafeAuthenticatedConnectionSharing] = {1}", Environment.NewLine, request.UnsafeAuthenticatedConnectionSharing);
        sb.AppendFormat("{0}[UseDefaultCredentials] = {1}", Environment.NewLine, request.UseDefaultCredentials);
        sb.AppendFormat("{0}[UserAgent] = {1}", Environment.NewLine, request.UserAgent);
        
		Logger.Log(sb.ToString());
    }
		
}