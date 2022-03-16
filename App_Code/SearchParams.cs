using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SearchParams
{
    public string DepartureLocation { get; set; }
    public string DestinationLocation { get; set; }
    public string DealType { get; set; }
    public DateTime? DepartureDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Adults { get; set; }
    public string Childern { get; set; }
    public string Students { get; set; }
    public string Infants { get; set; }
    public string Seniors { get; set; }
    public string Youngs { get; set; }
    public bool IsRoundTrip { get; set; }
    public string ClassType { get; set; }
    public SearchParams()
    {
        
    }

    //public SearchParams(string iDepLocation, string iDestLocation, string iDealType,
    //                    DateTime iDepDate, DateTime iRetDate, string iAdults,
    //                    string iChildren, string iStudents, string iInfants,
    //                    string iSeniors, string iYoungs, bool iIsRoundTrip,
    //                    string iClassType)
    //{
    //    DepartureLocation = iDepLocation;
    //    DestinationLocation = iDestLocation;
    //    DealType = iDealType;
    //    DepartureDate = iDepDate;
    //    ReturnDate = iRetDate;
    //    Adults = iAdults;
    //    Childern = iChildren;
    //    Students = iStudents;
    //    Infants = iInfants;
    //    Seniors = iSeniors;
    //    Youngs = iYoungs;
    //    IsRoundTrip = iIsRoundTrip;
    //    ClassType = iClassType;
    //}

    public void SaveToSession()
    {
        HttpContext.Current.Session["SearchParams"] = this;
    }

    public static SearchParams LoadFromSession()
    {
        if (HttpContext.Current.Session["SearchParams"] == null)
            throw new Exception("Session Timeout.");
        else if (HttpContext.Current.Session["SearchParams"] is SearchParams)
            return (SearchParams)HttpContext.Current.Session["SearchParams"];
        else
            throw new Exception("Error");
    }
}