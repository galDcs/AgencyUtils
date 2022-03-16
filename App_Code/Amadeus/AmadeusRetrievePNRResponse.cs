using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AmadeusRetrievePNRResponse
/// </summary>
public class AmadeusRetrievePNRResponse
{
    public FlightPNR_Result result { get; set; }
    public string id { get; set; }
    public string jsonrpc { get; set; }

    public class FlightPNR_Result
    {
        public string officeId { get; set; }
        public string ticketOfficeId { get; set; }
        public string amadeusFirstNum { get; set; }
        public string retrieveDate { get; set; }
        public string retrieveTime { get; set; }
        public string createDate { get; set; }
        public string createTime { get; set; }
        public string pnrNum { get; set; }
        public List<FlightPNR_Traveller> travellers { get; set; }
        public Products products { get; set; }
        public List<FlightPNR_GeneralOption> generalOptions { get; set; }
        public FlightPNR_TimeLimits timeLimits { get; set; }
        public List<FlightPNR_ReferenceReservationInfo> referenceReservationInfo { get; set; }
        public List<string> remarks { get; set; }
        public List<string> amadeusResponse { get; set; }
    }

    public class FlightPNR_Traveller
    {
        public string travelerId { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string type { get; set; }
        public string dateOfBirth { get; set; }
    }

    public class Products
    {
        public List<FlightPNR_FlightProduct> flightProducts { get; set; }
    }

    public class FlightPNR_FlightProduct
    {
        public string refNum { get; set; }
        public string companyId { get; set; }
        public string companyPnr { get; set; }
        public string legOrigin { get; set; }
        public string legDestination { get; set; }
        public List<FlightPNR_Segment> segment { get; set; }
    }

    public class FlightPNR_GeneralOption
    {
        public string optionType { get; set; }
        public string optionDescription { get; set; }
        public string optionValue { get; set; }
        public string optionRefType { get; set; }
        public string optionRefValue { get; set; }
        public string optiontatus { get; set; }
    }

    public class FlightPNR_Segment
    {
        public string segment { get; set; }
        public string depAirport { get; set; }
        public string arrAirport { get; set; }
        public string depDate { get; set; }
        public string depTime { get; set; }
        public string arrDate { get; set; }
        public string arrTime { get; set; }
        public string alSuppIATA { get; set; }
        public string alFltNum { get; set; }
        public string departTerminal { get; set; }
        public string checkInTime { get; set; }
        public string @class { get; set; }
        public string equipment { get; set; }
        public string status { get; set; }
    }

    public class FlightPNR_TimeLimits
    {
        public string ticketing { get; set; }
    }

    public class FlightPNR_ReferenceReservationInfo
    {
        public string passengerReference { get; set; }
        public List<ReservationProducts> reservationProducts { get; set; }
    }
	
	public class ReservationProducts
	{
		public string productType { get; set; }
		public string automaticTicket { get; set; }
		public List<string> productRef { get; set; }
	}
}
