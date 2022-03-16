using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AlpGetDocketResponse
{
    public class DocketRemarks
    {
        public object remark { get; set; }
    }

    public class Docket
    {
        public int docketId { get; set; }
        public string docketCreatedByAgent { get; set; }
        public string docketCreatedByAgency { get; set; }
        public string agentPhoneNum { get; set; }
        public string agentEmail { get; set; }
        public string docketCreatedDateTime { get; set; }
        public string docketStatus { get; set; }
        public string docketOEM { get; set; }
        public DocketRemarks docketRemarks { get; set; }
    }

    public class Remark
    {
        public string category { get; set; }
        public string status { get; set; }
        public string text { get; set; }
        public string time { get; set; }
    }

    public class ReservationRemarks
    {
        public List<Remark> remark { get; set; }
    }

    public class Remark2
    {
        public string category { get; set; }
        public string status { get; set; }
        public string text { get; set; }
        public string time { get; set; }
    }

    public class ProductRemarks
    {
        public List<Remark2> remark { get; set; }
    }

    public class ProductClient
    {
        public string clientRef { get; set; }
        public string priceRef { get; set; }
    }

    public class ProductClients
    {
        public List<ProductClient> productClient { get; set; }
    }

    public class Product
    {
        public string productId { get; set; }
        public string productClassification { get; set; }
        public string productSupplier { get; set; }
        public string productStatus { get; set; }
        public string productName { get; set; }
        public string productCategory { get; set; }
        public string productType { get; set; }
        public string productFare { get; set; }
        public string productLocationStart { get; set; }
        public string productLocationEnd { get; set; }
        public string productDateStart { get; set; }
        public string productDateEnd { get; set; }
        public string productTimeStart { get; set; }
        public string productTimeEnd { get; set; }
        public string productCarrier { get; set; }
        public string productCarrierNum { get; set; }
        public string productCarrierClass { get; set; }
        public ProductRemarks productRemarks { get; set; }
        public ProductClients productClients { get; set; }
        public string flightStatus { get; set; }
    }

    public class ReservationProducts
    {
        public List<Product> product { get; set; }
    }

    public class Reservation
    {
        public string reservationId { get; set; }
        public string pnr { get; set; }
        public string supplier { get; set; }
        public string reservationStatus { get; set; }
        public string reservationCurrency { get; set; }
        public string reservationProviderReferenceId { get; set; }
        public string reservationProviderReferenceSource { get; set; }
        public ReservationRemarks reservationRemarks { get; set; }
        public ReservationProducts reservationProducts { get; set; }
    }

    public class Reservations
    {
        public List<Reservation> reservation { get; set; }
    }

    public class Root
    {
        public Docket docket { get; set; }
        public Reservations reservations { get; set; }
    }

    public class ClientRemarks
    {
        public object remark { get; set; }
    }

    public class Client
    {
        public string clientIndex { get; set; }
        public string idType { get; set; }
        public string idNum { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string gender { get; set; }
        public string dateOfBirth { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public ClientRemarks clientRemarks { get; set; }
    }

    public class Clients
    {
        public List<Client> client { get; set; }
    }

    public class PriceRemark
    {
        public object remark { get; set; }
    }

    public class Price
    {
        public string priceIndex { get; set; }
        public string priceTotal { get; set; }
        public string tax { get; set; }
        public string priceFactor { get; set; }
        public string commission { get; set; }
        public string VAT { get; set; }
        public string markUp { get; set; }
        public PriceRemark priceRemark { get; set; }
    }

    public class Prices
    {
        public List<Price> price { get; set; }
    }

    public class AdditionalData
    {
        public object data { get; set; }
    }

    public class Data
    {
        public Root root { get; set; }
        public Clients clients { get; set; }
        public Prices prices { get; set; }
        public AdditionalData additionalData { get; set; }
    }

    public string status { get; set; }
    public string msg { get; set; }
    public Data data { get; set; }
}


/*
	public AlpGetDocketResponse()
	{
	}

    public string status { get; set; }
    public string msg { get; set; }
    public GetDocketData data { get; set; }

    class GetDocketData
    {
        public GetDocketRoot root { get; set; }
        public GetDocketClient root { get; set; }
        public GetDocketClients clients { get; set; }
        public GetDocketPrices prices { get; set; }
    }

    class GetDocketRoot
    {
        public GetDocketDocket docket { get; set; }
        public GetDocketReservations reservations { get; set; }
    }

    class GetDocketDocket
    {
        public string docketId { get; set; }
        public string docketCreatedByAgent { get; set; }
        public string docketCreatedByAgency { get; set; }
        public string agentPhoneNum { get; set; }
        public string agentEmail { get; set; }
        public string docketCreatedDateTime { get; set; }
        public string docketStatus { get; set; }
        public string docketOEM { get; set; }
        public GetDocketDocketRemarks docketRemarks { get; set; }
    }

    class GetDocketReservations
    {
        List<GetDocketReservation> reservation
    }

    class GetDocketReservation
    {

    }

    class GetDocketDocketRemarks
    {
        public string ramark { get; set; }
    }

    class GetDocketClients
    {
        List<GetDocketClient> client { get; set; }
    }

    class GetDocketClient
    {
    }

    class GetDocketPrices
    {
    }

    class GetDocketAdditionalData
    {
        public string data { get; set; }
    }

*/