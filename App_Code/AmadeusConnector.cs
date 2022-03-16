using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

public class AmadeusConnector
{
    public enum eAmadeusMethods
    {
        RETRIEVE_PNR = 0,
        GET_DATA = 1,
        CHECK_SEAT_AND_PRICE = 2,
        CREATE_DOCKET = 3,
		QUEUE_LIST = 4,
		QUEUE_REMOVE_ITEM = 5
    }

    ApiHandler mApiHandler = new ApiHandler();
                              
    //private string mApiUrl = "https://test.travelcenter.co.il/en/api/v1/";
    private string mApiUrl = "https://api.travelcenter.co.il/en/api/v1/";
	
    //*********************************//
    //"https://api.travelcenter.co.il/en/api/v1/";
    //*********************************//
    private string mApiActionPathService = "service";
    private Dictionary<eAmadeusMethods, string> mMethods;

	public AmadeusConnector()
	{
        mMethods = new Dictionary<eAmadeusMethods, string>();
        mMethods.Add(eAmadeusMethods.QUEUE_LIST, "queueList");
        mMethods.Add(eAmadeusMethods.QUEUE_REMOVE_ITEM, "queueRemoveItem");
        mMethods.Add(eAmadeusMethods.RETRIEVE_PNR, "retrievePNR");
        mMethods.Add(eAmadeusMethods.GET_DATA, "getData");
        mMethods.Add(eAmadeusMethods.CHECK_SEAT_AND_PRICE, "checkSeatAndPrice");
    }

    public string RetrievePNR(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAmadeusMethods.RETRIEVE_PNR, iRequest);

        return result;
    }
	
	public string QueueList(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAmadeusMethods.QUEUE_LIST, iRequest);

        return result;
    }
	
	public string QueueRemoveItem(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAmadeusMethods.QUEUE_REMOVE_ITEM, iRequest);

        return result;
    }

    public string GetDataRequest(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAmadeusMethods.GET_DATA, iRequest);

        return result;
    }

    public string CheckSeatAndPriceRequest(string iRequest)
    {
        string result = string.Empty;

        result = callWebApi(eAmadeusMethods.CHECK_SEAT_AND_PRICE, iRequest);

        return result;
    }

    private string callWebApi(eAmadeusMethods iMethod, string iContent)
    {
        string result = string.Empty;
        //string url = mApiUrl + mApiActionPathService + "/" + mMethods[iMethod];
        string url = mApiUrl + mApiActionPathService;

        result = mApiHandler.SendJsonRequest(url, iContent);

        return result;
    }
}


