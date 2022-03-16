using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EventDetails
/// </summary>
public class EventDetails
{
    public const string kEventim4uLink = "https://www.eventim4u.co.il/";
    public string Id { get; set; }
    public string Name { get; set; }
    public string AppThemeId { get; set; }
    public string FormUrl { get; set; }
    public string DocketId { get; set; }
    public string Vendor { get; set; }
    public string EndEvent { get; set; }
    public string Title { get; set; }

    public EventDetails()
    {
        
    }

	public string GetUrlLogon()
    {
		return kEventim4uLink + Name + "/logon.aspx";
	}
	
	public string GetUrlOrderEvent()
    {
		string orderEventUrl = kEventim4uLink + '/' + Name +'/';
		
		orderEventUrl += AppThemeId.ToLower() == "master_en"  ? "OrderEventEn.aspx" : "OrderEvent.aspx";

        return orderEventUrl;
	}
	
    public string GetPageHeaderLogo()
    {
        return kEventim4uLink + Name + "/client/" + Name + "/img/page_header.jpg";
    }

    public string GetLanguage(string iLanguage)
    {
        string eventLanguage = string.Empty;

        switch (AppThemeId.ToLower())
        {
            case "master_en":
                eventLanguage = iLanguage == "1252" ? "English" : "אנגלית";
                break;
            case "master":
            default:
                eventLanguage = iLanguage == "1252" ? "Hebrew" : "עברית";
                break;
        }

        return eventLanguage;
    }
}