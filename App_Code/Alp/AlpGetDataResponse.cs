using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AlpGetDataResponse
{
    public RootObject result { get; set; }

    public AlpGetDataResponse()
    {

    }

    public class Deal
    {
        public string dealId { get; set; }
        public object rowId { get; set; }
        public string provider { get; set; }
        public string dealType { get; set; }
        public object dealFeature { get; set; }
        public string departureDate { get; set; }
        public string rowName { get; set; }
        public string hotelRating { get; set; }
        public string carGroup { get; set; }
        public int dealLength { get; set; }
        public int serviceLength { get; set; }
        public string fareBasis { get; set; }
        public string paxComplect { get; set; }
        public string roomType { get; set; }
        public string price { get; set; }
        public string tax { get; set; }
        public string commission { get; set; }
        public string commissionType { get; set; }
        public string childPrice { get; set; }
        public string singlePrice { get; set; }
        public string thirdPrice { get; set; }
        public string additionalPrice { get; set; }
        public string currency { get; set; }
        public string chain { get; set; }
        public int flag { get; set; }
        public string hotelId { get; set; }
        public int normalPrice { get; set; }
        public string dealDestination { get; set; }
        public string flightDestination { get; set; }
        public string dealDestinationReturn { get; set; }
        public string infantPrice { get; set; }
        public string title { get; set; }
    }

    //public class Outbound
    //{
    //    public string index { get; set; }
    //    public string departureIATA { get; set; }
    //    public string arrivalIATA { get; set; }
    //    public string airline { get; set; }
    //    public string flightNumber { get; set; }
    //    public string date { get; set; }
    //    public string depTime { get; set; }
    //    public string arrTime { get; set; }
    //    public string connection { get; set; }
    //    public string flightDuration { get; set; }
    //}

    public class Pair
    {
        public string dealid { get; set; }
        public string toIndex { get; set; }
        public string fromIndex { get; set; }
        public string toId { get; set; }
        public string fromId { get; set; }
        public string provider { get; set; }
        public string toClass { get; set; }
        public string fromClass { get; set; }
        public object toSeats { get; set; }
        public object fromSeats { get; set; }
        public string toStatus { get; set; }
        public string toRemark { get; set; }
        public string fromStatus { get; set; }
        public string fromRemark { get; set; }
        public string Meal { get; set; }
        public string MaxWeight { get; set; }
        public string MaxWeightHandbag { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTerminal { get; set; }
        public string ViaArrivalTerminal { get; set; }
        public string ViaArrivalTime { get; set; }
        public string ViaDestination { get; set; }
        public string ViaDepartureTime { get; set; }
        public string ViaAirline { get; set; }
        public string Mode { get; set; }
        public string fill { get; set; }
        public string fromMeal { get; set; }
        public string fromMaxWeight { get; set; }
        public string fromMaxWeightHandbag { get; set; }
        public string fromDepartureTerminal { get; set; }
        public string fromArrivalTerminal { get; set; }
        public string fromViaArrivalTerminal { get; set; }
        public string fromViaArrivalTime { get; set; }
        public string fromViaDestination { get; set; }
        public string fromViaDepartureTime { get; set; }
        public string fromViaAirline { get; set; }
        public string fromViaFlightNum { get; set; }
        public string fromMode { get; set; }
        public string fromfill { get; set; }
        public string fromAircraft { get; set; }
    }

    //public class Inbound
    //{
    //    public string index { get; set; }
    //    public string departureIATA { get; set; }
    //    public string arrivalIATA { get; set; }
    //    public string airline { get; set; }
    //    public string flightNumber { get; set; }
    //    public string date { get; set; }
    //    public string depTime { get; set; }
    //    public string arrTime { get; set; }
    //    public string connection { get; set; }
    //    public string flightDuration { get; set; }
    //}

    public class Flights
    {
        public List<FlightResponse> Outbound { get; set; }
        public List<Pair> Pairs { get; set; }
        public List<FlightResponse> Inbound { get; set; }
    }

    public class RootObject
    {
        public Flights Flights { get; set; }
        public List<Deal> Deals { get; set; }

    }
}