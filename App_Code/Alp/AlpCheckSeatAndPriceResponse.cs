using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlpCheckSeatAndPriceResponse
/// </summary>
public class AlpCheckSeatAndPriceResponse
{
    public Result result { get; set; }

    public AlpCheckSeatAndPriceResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}

public class FareAmount
{
    public string fareAmount { get; set; }
    public string fareCurrency { get; set; }
}

public class Result
{
    public string isBookable { get; set; }
    public FareAmount fareAmount { get; set; }
}

//public class RootObject
//{
//}