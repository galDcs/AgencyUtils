using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class FlightRow
{
    public string BundleId { get; set; }
    public string PNR { get; set; }
    public string DeparturePortName{ get; set; }
    public DateTime DepartureDate { get; set; }
    public string DepartureTime { get; set; }
    public string DepartureTerminal { get; set; }
    public string FlightRouteType { get; set; }
    public string ArrivalPortName { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string ArrivalTime { get; set; }
    public string SupplierId { get; set; }
    public string PaidToSupplierId { get; set; }
    public string FlightNumber { get; set; }
    public string Class { get; set; }
    public string LegOrder { get; set; }
    public string ServiceStatusId { get; set; }
    public string IncomeTypeId { get; set; }
    public string PaymentTypeId { get; set; }
    public string IntermediateLandings { get; set; }
    public string Miles { get; set; }
    public string Availability { get; set; }
    public string DataResourceId { get; set; }
    public DateTime DataRecievedDate { get; set; }
    public string DataThruClerkId { get; set; }
    public string DeparturePortId { get; set; }
    public string ArrivalPortId { get; set; }
    public string CurrencyId { get; set; }
    public string AdultPrice { get; set; }
    public string PortTax { get; set; }
    public string ChildPrice { get; set; }
    public string InfantPrice { get; set; }
    public string SeniorPrice { get; set; }
    public string AdditionalTax { get; set; }
    public string Remark { get; set; }
    public string CommissionPercentageOverride { get; set; }
    public string Nights { get; set; }
    public string FlightPriceId { get; set; }
    public string ExternalFlightId { get; set; }

    //Set all To Empty.
	public FlightRow()
	{
        BundleId = PNR = DeparturePortName = DepartureTime = DepartureTerminal = FlightRouteType = ArrivalPortName =  ArrivalTime = SupplierId = PaidToSupplierId =
        FlightNumber = Class = LegOrder = ServiceStatusId = IncomeTypeId = PaymentTypeId = IntermediateLandings = Miles = Availability = DataResourceId = DataThruClerkId =
        DeparturePortId = ArrivalPortId = CurrencyId = AdultPrice = PortTax = ChildPrice = InfantPrice = SeniorPrice = AdditionalTax = Remark = CommissionPercentageOverride = Nights =
        FlightPriceId = ExternalFlightId = string.Empty;

        FlightRouteType = DataResourceId = "1";
        Availability = IntermediateLandings = Nights = "0";
        AdultPrice = PortTax = ChildPrice = InfantPrice = SeniorPrice = AdditionalTax = CommissionPercentageOverride = "0";
        Miles = string.Empty;
        FlightPriceId = "-1";
        //DepartureDate
        //ArrivalDate
        //DataRecievedDate
	}

    public FlightRow(string x)
    {

    }
}