using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AlpCreateDocketRequest
{
    public string method { get; set; }
    public CreateDocketParams @params { get; set; }
    public int id { get; set; }
    public string jsonrpc { get; set; }
}

public class ProductClient
{
    public int clientRef { get; set; }
    //public int? price { get; set; }
    public double? price { get; set; }
}

public class ProductClients
{
    public List<ProductClient> productClient { get; set; }
}

public class ProductAdditionalDetails
{
    public List<object> description { get; set; }
}

public class Product
{
    public string productType { get; set; }
    public string productId { get; set; }
    public ProductClients productClients { get; set; }
    public ProductAdditionalDetails productAdditionalDetails { get; set; }
}

public class ReservationProducts
{
    public List<Product> product { get; set; }
}

public class ReservationAdditionalDetails
{
    public List<object> description { get; set; }
}

public class Reservation
{
    public string reservationIndex { get; set; }
    public string requestPnr { get; set; }
    public string reservationSupplier { get; set; }
    public ReservationProducts reservationProducts { get; set; }
    public ReservationAdditionalDetails reservationAdditionalDetails { get; set; }
}

public class Reservations
{
    public List<Reservation> reservation { get; set; }
}

public class Client
{
    public int clientIndex { get; set; }
    public string idType { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string gender { get; set; }
    public string dateOfBirth { get; set; }
    public string phoneNum { get; set; }
    public string email { get; set; }
}

public class Clients
{
    public List<Client> client { get; set; }
}

public class CreateDocketData
{
    public string debug { get; set; }
    public string referenceId { get; set; }
    public string referenceSource { get; set; }
    public string supplier { get; set; }
    public string currency { get; set; }
    public Reservations reservations { get; set; }
    public Clients clients { get; set; }
}

public class CreateDocketParams
{
    public string identifier { get; set; }
    public string checkSum { get; set; }
    public string token { get; set; }
    public CreateDocketData data { get; set; }
}