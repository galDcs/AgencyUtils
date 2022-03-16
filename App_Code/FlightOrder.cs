using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FlightOrder
/// </summary>
public class FlightOrder
{
    public List<FlightResponse> OutboundItinerary { get; set; }
    public List<FlightResponse> InboundItinerary { get; set; }
    public List<Segment> OutboundSegments { get; set; }
    public  List<Segment> InboundSegments { get; set; }
    public  Deal Deal { get; set; }
    public int Adults { get; set; }
    public int Children { get; set; }
    public int Students { get; set; }
    public int Infants { get; set; }
    public int Seniors { get; set; }
    public int Youngs { get; set; }
    public string BookingId { get; set; }
    public string DealId { get; set; }
    public bool IsTwoWay { get; set; }
    public FlightOrder()
    {

    }

    public FlightOrder(List<FlightResponse> iOutboundItinerary, List<FlightResponse> iInboundItinerary, Deal iDeal,
                        List<Segment> iOutboundSegments, List<Segment> iInboundSegments, int iAdults,
                        int iChildren, int iStudents, int iInfants,
                        int iSeniors, int iYoungs, string iDealId,
                        string iBookingId, bool iIsTwoWay)
    {
        OutboundItinerary = iOutboundItinerary;
        InboundItinerary = iInboundItinerary;
        Deal = iDeal;
        OutboundSegments = iOutboundSegments;
        InboundSegments = iInboundSegments;
        Adults = iAdults;
        Children = iChildren;
        Students = iStudents;
        Infants = iInfants;
        Seniors = iSeniors;
        Youngs = iYoungs;
        BookingId = iBookingId;
        DealId = iDealId;
        IsTwoWay = iIsTwoWay;
    }

    public void SaveToSession()
    {
        HttpContext.Current.Session["FlightOrder"] = this;
    }

    public static FlightOrder LoadFromSession()
    {
        if (HttpContext.Current.Session["FlightOrder"] == null)
            throw new Exception("Session Timeout.");
        else if (HttpContext.Current.Session["FlightOrder"] is FlightOrder)
            return (FlightOrder)HttpContext.Current.Session["FlightOrder"];
        else
            throw new Exception("Error");
    }
}