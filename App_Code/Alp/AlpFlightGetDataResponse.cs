using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AlpFlightGetDataResponse
{
    public RootObject result { get; set; }

    public AlpFlightGetDataResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SaveToSession()
    {
        HttpContext.Current.Session["AlpResponse"] = this;
    }

    public static AlpFlightGetDataResponse LoadFromSession()
    {
        if (HttpContext.Current.Session["AlpResponse"] == null)
            throw new Exception("Session Timeout.");
        else if (HttpContext.Current.Session["AlpResponse"] is AlpFlightGetDataResponse)
            return (AlpFlightGetDataResponse)HttpContext.Current.Session["AlpResponse"];
        else
            throw new Exception("Error");
    }


}

//public class Pair
//{
//    public string dealid { get; set; }
//    public int toIndex { get; set; }
//    public int fromIndex { get; set; }
//    public string toId { get; set; }
//    public string fromId { get; set; }
//    public string provider { get; set; }
//    public string toClass { get; set; }
//    public string fromClass { get; set; }
//    public int toSeats { get; set; }
//    public int fromSeats { get; set; }
//}

//public class Flights
//{
//    public List<Dictionary<string, FlightResponse>> FlightIdToFlight { get; set; }
//    public List<FlightResponse> Outbound { get; set; }
//    public List<FlightResponse> Inbound { get; set; }
//    public List<Pair> Pairs { get; set; }
//}


//public class Deal
//{
//    public string dealId { get; set; }
//    public string rowId { get; set; }
//    public string provider { get; set; }
//    public string dealType { get; set; }
//    public string dealFeature { get; set; }
//    public string departureDate { get; set; }
//    public string rowName { get; set; }
//    public string hotelRating { get; set; }
//    public string carGroup { get; set; }
//    public string dealLength { get; set; }
//    public int serviceLength { get; set; }
//    public string fareBasis { get; set; }
//    public string paxComplect { get; set; }
//    public string roomType { get; set; }
//    public string price { get; set; }
//    public string tax { get; set; }
//    public int commission { get; set; }
//    public string commissionType { get; set; }
//    public string childPrice { get; set; }
//    public int singlePrice { get; set; }
//    public int thirdPrice { get; set; }
//    public int additionalPrice { get; set; }
//    public string currency { get; set; }
//    public string chain { get; set; }
//    public int flag { get; set; }
//    public string hotelId { get; set; }
//    public int normalPrice { get; set; }
//    public string dealDestination { get; set; }
//    public string flightDestination { get; set; }
//    public string dealDestinationReturn { get; set; }
//}


public class BaggageAllowance
{
    public int NumberOfPieces { get; set; }
    public int Weight { get; set; }
    public string Unit { get; set; }
}

public class FreeBaggageAllowance
{
    public BaggageAllowance baggageAllowance { get; set; }
}

public class Segment
{
    public int flightId { get; set; }
    public string @class { get; set; }
    public string cabin { get; set; }
    public string productFare { get; set; }
    public string bookingId { get; set; }
    public string status { get; set; }
    public string seats { get; set; }
    public string remark { get; set; }
    public FreeBaggageAllowance freeBaggageAllowance { get; set; }
    public string Meal { get; set; } //FOR CHARTER
    public string MaxWeight { get; set; } //FOR CHARTER
    public string MaxWeightHandbag { get; set; } //FOR CHARTER
    public string DepartureTerminal { get; set; } //FOR CHARTER
    public string Mode { get; set; } //FOR CHARTER
    public string ArrivalTerminal { get; set; } //FOR CHARTER
    public string Aircraft { get; set; } //FOR CHARTER
}

public class Segments
{
    public Dictionary<string, Segment> segmentIdToSegment { get; set; }
}

public class Bound
{
    public string elapsedTime { get; set; }
    public Dictionary<string, Segment> segments { get; set; }
    //public List<Segments> segments { get; set; }
}

public class DealFlightsSegments
{
    public string elapsedTime { get; set; }

    public  Dictionary<string, Segment> segments { get; set; }
}

public class RootObject
{
    public Dictionary<string, FlightResponse> flights { get; set; }
    public List<Deal> Deals { get; set; }
    //TODO:
    //Missing multipli objects in the list
    /// <summary>
    /// Maybe its not relevant! need to ask
    /// </summary>
    public Dictionary<string, List<Dictionary<string, Bound>>> dealFlightsSegments { get; set; }
    //public Dictionary<string, List<DealFlightsSegments>> dealFlightsSegments { get; set; }
}