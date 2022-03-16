using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class OphirBitInsuranceConnector
{
    public enum eAlpMethods
    {
        //GET_DOCKET = 0,
        //GET_DATA = 1,
        //GET_PRICE = 2
        GET_API,
        GET_DATA
    }

    ApiHandler mApiHandler = new ApiHandler();
    private string mApiUrl = "http://www.ophirbit.co.il/api/";
    private Dictionary<eAlpMethods, string> mMethods;
    private Dictionary<eAlpMethods, eRequestType> mMethodsToRequests;

    public OphirBitInsuranceConnector()
	{
        mMethods = new Dictionary<eAlpMethods, string>
        {
            { eAlpMethods.GET_API, "" },
            { eAlpMethods.GET_DATA, "data.aspx?" }
        };

        mMethodsToRequests = new Dictionary<eAlpMethods, eRequestType>
        {
            {eAlpMethods.GET_API, eRequestType.POST_DATA },
            {eAlpMethods.GET_DATA, eRequestType.DIRECT }
        };
    }

    public string SendRequestAndGetResult(eAlpMethods method, string iRequest)
    {
        string result = string.Empty;
        
        result = callWebApi(method, iRequest);

        return result;
    }
    private string callWebApi(eAlpMethods iMethod, string iContent)
    {
        string result = string.Empty;
        string url = mApiUrl + mMethods[iMethod];
		Logger.Log("url = " + url);
        result = mApiHandler.SendRequest(mMethodsToRequests[iMethod], url, iContent);

        return result;
    }
}