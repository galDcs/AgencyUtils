using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Flight
/// </summary>
public class FlightResponse
{
    public string departureIATA { get; set; }
    public string arrivalIATA { get; set; }
    public string airline { get; set; }
    public string aircraftType { get; set; }
    public int flightNumber { get; set; }
    public string departureDate { get; set; }
    public string departureTime { get; set; }
    public string arrivalDate { get; set; }
    public string arrivalTime { get; set; }
    public string flightDuration { get; set; }
    public string remark { get; set; }
    public string image { get; set; }
    public Data data { get; set; }


    //DELETE
    //public int index { get; set; }
    ////public string departureIATA { get; set; }
    ////public string arrivalIATA { get; set; }
    ////public string airline { get; set; }
    ////public string flightNumber { get; set; }
    //public string date { get; set; }
    //public string depTime { get; set; }
    //public string arrTime { get; set; }
    //public string connection { get; set; }
    //public string departureIATA1 { get; set; }
    //public string arrivalIATA1 { get; set; }
    //public string airline1 { get; set; }
    //public object flightNumber1 { get; set; }
    //public string date1 { get; set; }
    //public string depTime1 { get; set; }
    //public string arrTime1 { get; set; }
    //public string departureIATA2 { get; set; }
    //public string arrivalIATA2 { get; set; }
    //public string airline2 { get; set; }
    //public object flightNumber2 { get; set; }
    //public string date2 { get; set; }
    //public string depTime2 { get; set; }
    //public string arrTime2 { get; set; }

    //END DELETE

}

public class Data
{
    public string operationCarrier { get; set; }
    public string stops { get; set; }
    public string terminal { get; set; }
}