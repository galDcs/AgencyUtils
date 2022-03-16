using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Deal
{
    public string dealType { get; set; }
    public string dealId { get; set; }
    public string rowId { get; set; }
    public string flightDestination { get; set; }
    public string provider { get; set; }
    public string serviceLength { get; set; }
    public int dealLength { get; set; }
    public string dealServices { get; set; }
    public string dealStatus { get; set; }
    public IList<object> dealFeature { get; set; }
    public string departureDate { get; set; }
    public string dealName { get; set; }
    public string dealDestination { get; set; }
    public string dealDestinationReturn { get; set; }
    public string dealDeparture { get; set; }
    public string productName { get; set; }
    public string productCategory { get; set; }
    public string productRating { get; set; }
    public string productId { get; set; }
    public string productType { get; set; }
    public string basicPaxComplect { get; set; }
    public string commissionType { get; set; }
    public string currency { get; set; }
    public string chain { get; set; }
    public decimal totalPrice { get; set; }
    public decimal normalPrice { get; set; } //FOR CHARTER
    public decimal onePaxPrice { get; set; }
    public string infantPrice { get; set; } //FOR CHARTER
    public decimal taxValue { get; set; }
    public int commissionValue { get; set; }
    public string remark { get; set; }
    public string image { get; set; }
    public DealData data { get; set; }
    public Deal()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}

public class DealData
{
    public PriceRestriction priceRestriction { get; set; }
    public PriceDescription priceDescription { get; set; }
    public PriceTaxDescription priceTaxDescription { get; set; }
    public object fareFamilyInfo { get; set; } //TODO - 
    //public List<FareFamilyInfo> fareFamilyInfo { get; set; }
}

public class FareFamilyInfo
{
    public string fareFamilyName { get; set; }
    public string carrier { get; set; }
}

public class PriceDescription
{
    public decimal A { get; set; } //adult
    public decimal C { get; set; } //child
    public decimal Y { get; set; } //senior
    public decimal I { get; set; } //infant
    public decimal H { get; set; } // young
    public decimal S { get; set; } //student
}

public class PriceTaxDescription
{
    public decimal A { get; set; }
    public decimal C { get; set; } //child
    public decimal Y { get; set; } //senior
    public decimal I { get; set; } //infant
    public decimal H { get; set; } // young
    public decimal S { get; set; } //student
}

public class PriceRestriction
{
    public string PEN { get; set; }
    public string LTD { get; set; }
}