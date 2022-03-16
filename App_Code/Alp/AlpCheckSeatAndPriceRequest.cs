using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AlpCheckSeatAndPriceRequest
{
    public string method { get; set; }
    public CheckSeatAndPriceParams @params { get; set; }
    public int id { get; set; }
    public string jsonrpc { get; set; }

    public AlpCheckSeatAndPriceRequest()
    {

    }
}

public class CheckSeatAndPriceParams
{
    public string identifier { get; set; }
    public string checkSum { get; set; }
    public string token { get; set; }
    public CheckSeatAndPriceData data { get; set; }
}

public class CheckSeatAndPriceData
{
    [JsonProperty(PropertyName = "debug")]
    public string debug { get; set; }
    public string productId { get; set; }
}