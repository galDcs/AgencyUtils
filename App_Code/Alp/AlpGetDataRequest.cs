using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlpGetDataRequest
/// </summary>
public class AlpGetDataRequest
{
    public string method { get; set; }
    public RegFligtParams @params { get; set; }
    public int id { get; set; }
    public string jsonrpc { get; set; }
    public AlpGetDataRequest()
    {
        
    }
   
}

public class RegFligtParams
{
    public string identifier { get; set; }
    public string checkSum { get; set; }
    public string token { get; set; }
    public RegFligtData data { get; set; }
}

public class RegFligtData
{
    public string dealType { get; set; }
    public string searchCurrency { get; set; }
    public string departure { get; set; }
    [JsonProperty(PropertyName = "/debug")]
    public string debug { get; set; }

    public List<string> flightType { get; set; }
    public List<string> supplierList { get; set; }
    public string supplierQualifier { get; set; }
    public List<string> destinationList { get; set; }
    public string date { get; set; }
    public string returnDate { get; set; }
    public int? rangeOfDate { get; set; }
    public string segments { get; set; }
    public int numberOfAdults { get; set; }
    public int numberOfSeniors { get; set; }
    public int numberOfStudents { get; set; }
    public int numberOfYoung { get; set; }
    public int numberOfInfants { get; set; }
    public int numberOfChildren { get; set; }
    public string commission { get; set; }

    public string flightClass { get; set; }
    public List<RegFlightItinerary> flightItinerary { get; set; }
}
public class RegFlightItinerary
{
    public string departureCode { get; set; }
    public string arraivalCode { get; set; }
    public string departureDate { get; set; }
    public string radius { get; set; }
}