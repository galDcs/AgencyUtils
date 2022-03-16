using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AlpConnector
{
    public enum eAlpMethods
    {
        GET_DOCKET = 0,
        GET_DATA = 1
    }

    ApiHandler mApiHandler = new ApiHandler();
    private string mApiUrl = "https://www.alp.co.il/alp2/Booking/json/";
    private Dictionary<eAlpMethods, string> mMethods;

    public AlpConnector()
	{
        mMethods = new Dictionary<eAlpMethods, string>();
        mMethods.Add(eAlpMethods.GET_DOCKET, "getDocketData.php");
        mMethods.Add(eAlpMethods.GET_DATA, "getData.php");
	}

    public string GetDocket(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAlpMethods.GET_DOCKET, iRequest);

        return result;
    }

    public string GetData(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAlpMethods.GET_DATA, iRequest);

        return result;
    }

    private string callWebApi(eAlpMethods iMethod, string iContent)
    {
        string result = string.Empty;
        string url = mApiUrl + mMethods[iMethod];

        result = mApiHandler.SendJsonRequest(url, iContent);

        return result;
    }
}