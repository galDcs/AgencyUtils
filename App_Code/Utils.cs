using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Agency2000WS;

public class Utils
{
	public Utils()
	{
		
	}

    public static void setUser()
    {
		AgencyUser user = new AgencyUser();
		
		//When working localy.
		//if (string.IsNullOrEmpty(user.AgencyId))
		//{
		//	user.AgencyId = "85";
		//	user.AgencySystemType = "3";
		//	user.AgencyUserId = "1";
		//	user.AgencyUserName = "Agency2000";
		//	user.AgencyUserPassword = "11071964";
		//}
		//*****************************************//
		
        DAL_SQL.ConnStr = ConfigurationManager.AppSettings["CurrentAgencyDBConnStr"];
        DAL_SQL.ConnStr = DAL_SQL.ConnStr.Replace("^agencyId^", user.AgencyId.PadLeft(4, '0'));
        DAL_SQL.ConnStr = DAL_SQL.ConnStr.Replace("^systemType^", ((user.AgencySystemType == "3") ? "INN" : "OUT"));
    }
	
	public static bool checkSecurity(int iResourceId, int iClerkId)
    {
        bool hasPermission = false;
        int groupId;

        try
        {
            groupId = DAL_SQL_Helper.GetGroupId(iClerkId);
            DataSet ds = DAL_SQL_Helper.GetGroupSecurityPage(groupId, iResourceId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hasPermission = true;
            }
        }
        catch (Exception ex)
        {
            Logger.EmptyLog("Failed to check security. (" + ex.Message + ")",eLogger.DEBUG);
        }

        return hasPermission;
    }

    public static bool IsDataSetRowsNotEmpty(DataSet iDataSet)
    {//Check if the DataSet has rows in first table.
        bool isNotEmpty = false;

        if (iDataSet != null && iDataSet.Tables != null && iDataSet.Tables.Count > 0
                && iDataSet.Tables[0].Rows != null && iDataSet.Tables[0].Rows.Count > 0)
        {
            isNotEmpty = true;
        }

        return isNotEmpty;
    }

    public static string GetTextFromFile(string iNameInFile, eLanguage iLanguage)
	{
		return GetTextFromFile(iNameInFile, ((int)iLanguage).ToString());
	}
	
	public static string GetTextFromFile(string iNameInFile, string iLanguage)
    {
		return GetTextFromFile(iNameInFile, iLanguage, false);
	}
	
	public static string GetTextFromFile(string iNameInFile, string iLanguage, HttpRequest iRequest)
    {
		return GetTextFromFile(iNameInFile, iLanguage, false, iRequest);
	}
	
    public static string GetTextFromFile(string iNameInFile, string iLanguage, bool iIsSpecificSite, HttpRequest iRequest = null)
    {
        string filePrefix = "App_Data/"; 
        string textValue = string.Empty;
        string fileSuffix = ".txt";
		HttpRequest currentRequest = iRequest;
		if (iRequest == null)
		{
			currentRequest = HttpContext.Current.Request;
		}
		
		if (iIsSpecificSite)
		{
			filePrefix = "sites\\" + currentRequest.ApplicationPath + "\\";
			if (string.IsNullOrEmpty(currentRequest.ApplicationPath.Replace("\\","").Replace("/","")))
			{
				if (iRequest == null)
				{
					filePrefix = "sites\\" + HttpContext.Current.Request.Url.Host + "\\";
				}
				else
				{
					filePrefix = "sites\\" + iRequest.Url.Host + "\\";
				}
			}
		}
		
		if (string.IsNullOrEmpty(iLanguage))
		{
			iLanguage = GetLangFromCookies().ToString();
			if (string.IsNullOrEmpty(iLanguage))
			{
				iLanguage = "1252";
			}
		}
		
        string fileName = currentRequest.MapPath(filePrefix + iLanguage + fileSuffix);
        string line = string.Empty;
        string txtFromLine = string.Empty;

		try
		{
			using (StreamReader reader = new StreamReader(fileName))
			{
				line = reader.ReadLine();

				while (line != null)
				{
					if (iNameInFile.Length < line.Length)
					{
						txtFromLine = line.Substring(0, iNameInFile.Length + 1);
						if (txtFromLine.ToUpper().Trim() == iNameInFile.ToUpper().Trim() + "=")
						{
							textValue = line.Remove(0, iNameInFile.Length + 1).Trim();
						}
					}

					line = reader.ReadLine();
				}
			}
		}
		catch { }

		if (iIsSpecificSite && string.IsNullOrEmpty(textValue))
		{
			//If did not find any text in file when asked for specific site. then search in shared txt file.
			textValue = GetTextFromFile(iNameInFile,iLanguage, false, iRequest);
		}
		
        return textValue;
    }

	public static string GetGenderByTitle(string iTitle)
    {
        string gender = string.Empty;
		iTitle = !string.IsNullOrEmpty(iTitle) ? iTitle : "";
        switch(iTitle.ToLower())
        {
            case "mrs":
                gender = "1";//mrs
                break;
            case "MS":
                gender = "3"; //Undefined
                break;
            case "mr":
            case "chd":
            case "inf":
            case "sen":
            default:
                gender = "2"; //mr
                break;
        }

        return gender;
    }
	
	public static string GetTitleByResponseTitle(string iTitle)
    {
        string title = string.Empty;
		iTitle = !string.IsNullOrEmpty(iTitle) ? iTitle : "";
        try
        {
            title = DAL_SQL_Helper.GetTitleIdByName(iTitle);
        }
        catch (Exception)
        {
            Logger.Log("Missing title - iTitle = " + iTitle);
        }

		//Logger.Log("titleiTitle = " + title);
        return title;
    }
	
    public static string GetTitleIdOrDefault1(string iTitle)
    {
        string title = string.Empty;
        iTitle = !string.IsNullOrEmpty(iTitle) ? iTitle : "";
        try
        {
            title = DAL_SQL_Helper.GetTitleIdByName(iTitle);
            title = !string.IsNullOrEmpty(title) ? title : "1";
        }
        catch (Exception)
        {
            Logger.Log("Missing title - iTitle = " + iTitle);
        }

        //Logger.Log("titleiTitle = " + title);
        return title;
    }
	
	public static DateTime GetDateByFormat(string iDateStr)
    {
        DateTime date;
		
		if (!string.IsNullOrEmpty(iDateStr))
		{
			iDateStr = iDateStr.Replace("-", "").Replace("/", "");
			
			try 
			{
				string day = iDateStr.Substring(0, 2);
				string month = iDateStr.Substring(2, 2);
				string year = iDateStr.Substring(4);

				date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
			}
			catch
			{
				string year = iDateStr.Substring(0, 4);
				string month = iDateStr.Substring(4, 2);
				string day = iDateStr.Substring(6, 2);

				date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
			}
		}
		else
		{
			date = DateTime.MinValue;
		}

        return date;
    }
	
	public static string GetAgeGroupId(string iAgeGroupType)
    {
        string ageGroupId = string.Empty;
		
		iAgeGroupType = !string.IsNullOrEmpty(iAgeGroupType) ? iAgeGroupType : "";
        switch (iAgeGroupType.ToLower())
        {
            case "adt":
                ageGroupId = "3";
                break;
            case "chd":
                ageGroupId = "2";
                break;
            case "inf":
                ageGroupId = "1";
                break;
			default:
				ageGroupId = "3";
				break;
        }

        return ageGroupId;
    }
	
	public static string GetSupplierIdByFlightCompanyId(string iCompanyId)
    {
        string supplierId = string.Empty;
        
        try
        {
            supplierId = DAL_SQL_Helper.GetSupplierIdByFlightCompanyId(iCompanyId);
        }
        catch (Exception ex)
        {
            supplierId = iCompanyId;
            throw ex;
        }

        return supplierId;
    }
	
	public static string GetPortIdByName(string iAirPortName)
    {
        string portId = string.Empty;

        try
        {
            portId = DAL_SQL_Helper.GetPortIdByName(iAirPortName);
			if (string.IsNullOrEmpty(portId))
			{
				portId = DAL_SQL_Helper.GetPortIdBySymbol(iAirPortName);
			}
			
			if (string.IsNullOrEmpty(portId))
            {
                portId = DAL_SQL_Helper.AddPortToLocations(iAirPortName);
            }
        }
        catch (Exception ex)
        {
            portId = iAirPortName;
            throw ex;
        }

        return portId;
    }
	
	public static string GetFlightTypeByDealType(eDealType iDealType)
    {
        string flightTypeId = string.Empty;

        switch(iDealType)
        {
            case eDealType.FLIGHT:
                flightTypeId = "1";
                break;
            case eDealType.CHARTER:
            case eDealType.NOFSHON: //In ALP the flights of the nofshon are charter
                flightTypeId = "2";
                break;
        }

        return flightTypeId;
    }
		
	public static string getDateByFormat(string date)
    {
		string newDate = string.Empty;
        date = date.Replace(" ", "");
		if (date.Contains("/") || date.Contains("-"))
		{
			string[] dateSplitted = (date.Contains("/")) ? date.Split('/') : (date.Contains("-")) ? date.Split('-') : null;
			string monthStr = string.Empty;

			//Check the month.
			switch (dateSplitted[1])
			{
                case "1":
                case "01":
                    monthStr = "JAN";
					break;
                case "2":
                case "02":
					monthStr = "FEB";
					break;
				case "03":
				case "3":
					monthStr = "MAR";
					break;
				case "04":
				case "4":
					monthStr = "APR";
					break;
				case "05":
				case "5":
					monthStr = "MAY";
					break;
				case "06":
				case "6":
					monthStr = "JUN";
					break;
				case "07":
				case "7":
					monthStr = "JUL";
					break;
				case "08":
				case "8":
					monthStr = "AUG";
					break;
				case "09":
				case "9":
					monthStr = "SEP";
					break;
				case "10":
					monthStr = "OCT";
					break;
				case "11":
					monthStr = "NOV";
					break;
				case "12":
					monthStr = "DEC";
					break;
			}

			newDate = dateSplitted[0] + "-" + monthStr + "-" + dateSplitted[2];
		}
		else
		{
			newDate = date;
		}
		
        return newDate;
    }

    public static string getDateByGuiFormat(DateTime date)
    {
        string newDate = string.Empty;

        newDate = date.Day + "/" + date.Month + "/" + date.Year;

        return newDate;
    }
	
	public static string FormatDateForDB(string iDate)
    {
        string formattedDate = string.Empty;

        if (!string.IsNullOrEmpty(iDate))
        {
            try
            {
                formattedDate = DateTime.Parse(iDate).ToString("dd-MMM-yy");
            }
            catch { }
        }

        return formattedDate;
    }
	
	public static void AddCellToRowByText(TableRow iRow, string iText)
    {
        TableCell cell = new TableCell();

        cell.Text = iText;
        iRow.Cells.Add(cell);
    }

    public static bool IsFlightAvailable(FlightOrder iOrder, decimal iTotalPrice, out bool ioIsPriceChanged)
    {
        bool isAvailable = false;
        decimal newPrice = 0;
        FlightsOutgoingWS flightsWS = new FlightsOutgoingWS();
        isAvailable = flightsWS.IsFlightAvailable(iOrder.BookingId, out newPrice);
        ioIsPriceChanged = false;

        if (isAvailable)
        {
            newPrice = decimal.Parse(Math.Floor(newPrice).ToString());
            decimal totalPrice = int.Parse(Math.Floor(iTotalPrice).ToString());
            if (newPrice != totalPrice)
            {
                isAvailable = false;
                ioIsPriceChanged = true;
            }
        }

        return isAvailable;
    }

    public static void AddControlToRow(TableRow iRow, object iControl)
    {
        TableCell cell = new TableCell();

        if (iControl is TextBox)
        {
            cell.Controls.Add(iControl as TextBox);
        }
        else if (iControl is Button)
        {
            cell.Controls.Add(iControl as Button);
        }
        else if (iControl is CheckBox)
        {
            cell.Controls.Add(iControl as CheckBox);
        }
        else if (iControl is DropDownList)
        {
            cell.Controls.Add(iControl as DropDownList);
        }

        iRow.Cells.Add(cell);
    }

    //Default or any exception return hebrew.
    public static eLanguage GetLangFromCookies()
    {
        eLanguage lang = eLanguage.Hebrew;
        string langFromSession;
        int outInt;

        try
        {
            if (HttpContext.Current.Request.Cookies["Agency2000"] != null)
            {
                if (HttpContext.Current.Request.Cookies["Agency2000"]["Language"] != null)
                {
                    langFromSession = HttpContext.Current.Request.Cookies["Agency2000"]["Language"].ToString();
                    //if session not empty and
                    if (!string.IsNullOrEmpty(langFromSession) && int.TryParse(langFromSession, out outInt))
                    {
                        lang = (eLanguage)int.Parse(langFromSession); //Langeuage session is 1255,1252...
                    }
                }
            }
        }
        catch
        {
            lang = eLanguage.Hebrew;
        }

        return lang;
    }

    public static string GetCurrencyIdByName(string iCurrencyName)
	{
		string currencyId = DAL_SQL.RunSql("SELECT id FROM Agency_Admin.dbo.CURRENCIES WHERE name = N'" + iCurrencyName + "'");
		
		return currencyId;
	}
	
    public static string GetCurrencyIdBySymbol(string iAgencyId, string iSystemType, string iCurrencyName)
    {
        string currencyId = string.Empty;
		
		Agency2000WS.Agency2000WS ws = new Agency2000WS.Agency2000WS();
		
		currencyId = ws.GetCurrencyBySymbol(iAgencyId, iSystemType, iCurrencyName);

        return currencyId;
    }
	
	public static string GetCurrencyName(string iCurrencyId)
    {
        string currencyName = string.Empty;

        currencyName = DAL_SQL.RunSql("SELECT name FROM Agency_Admin.dbo.CURRENCIES WHERE id = " + iCurrencyId);

        return currencyName;
    }

    public static string GetServiceTypeIdByName(string iServiceTypeName)
    {
        string serviceTypeId = string.Empty;

        serviceTypeId = DAL_SQL.RunSql("SELECT id FROM Agency_Admin.dbo.SERVICE_STATUSES WHERE name = N'" + iServiceTypeName + "'");

        return serviceTypeId;
    }

    public static string GetFlightDay(string iDate)
    {
        string day = string.Empty;
        DateTime date = DateTime.Parse(iDate);

        switch (date.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                day = "יום א'";
                break;
            case DayOfWeek.Monday:
                day = "יום ב'";
                break;
            case DayOfWeek.Tuesday:
                day = "יום ג'";
                break;
            case DayOfWeek.Wednesday:
                day = "יום ד'";
                break;
            case DayOfWeek.Thursday:
                day = "יום ה'";
                break;
            case DayOfWeek.Friday:
                day = "יום ו'";
                break;
            case DayOfWeek.Saturday:
                day = "יום שבת";
                break;
        }

        return day;
    }

    public static string GetExtraDayStr(string iDepDate, string iArrivalDate)
    {
        string extraDayStr = string.Empty;
        DateTime departure = DateTime.Parse(iDepDate);
        DateTime arrival = DateTime.Parse(iArrivalDate);
        if (arrival.Date > departure.Date)
        {
            extraDayStr = "+1 יום";
        }

        return extraDayStr;
    }

    public static string GetTotalDirectionDurtaion(List<FlightResponse> iItinerary)
    {
        DateTime departure = DateTime.Parse(iItinerary[0].departureDate + " " + iItinerary[0].departureTime);
        DateTime arrival = DateTime.Parse(iItinerary[iItinerary.Count - 1].arrivalDate + " " + iItinerary[iItinerary.Count - 1].arrivalTime);

        TimeSpan ts = (arrival - departure);

        return string.Format("{0}:{1}", ts.Hours.ToString().PadLeft(2, '0'), ts.Minutes.ToString().PadLeft(2, '0'));
    }

    public static string GetPassengerPrice(string iPassengerType, Deal iDeal)
    {
        string price = iDeal.data.priceDescription.A.ToString();

        switch (iPassengerType)
        {
            case "C":
                if (!string.IsNullOrEmpty(iDeal.data.priceDescription.C.ToString()))
                {
                    price = iDeal.data.priceDescription.C.ToString();
                }
                break;
            case "Y":
                if (!string.IsNullOrEmpty(iDeal.data.priceDescription.Y.ToString()))
                {
                    price = iDeal.data.priceDescription.Y.ToString();
                }
                break;
            case "I":
                if (!string.IsNullOrEmpty(iDeal.data.priceDescription.I.ToString()))
                {
                    price = iDeal.data.priceDescription.I.ToString();
                }
                break;
            case "H":
                if (!string.IsNullOrEmpty(iDeal.data.priceDescription.H.ToString()))
                {
                    price = iDeal.data.priceDescription.H.ToString();
                }
                break;
            case "S":
                if (!string.IsNullOrEmpty(iDeal.data.priceDescription.S.ToString()))
                {
                    price = iDeal.data.priceDescription.S.ToString();
                }
                break;
        }

        return price;
    }

    public static string GetDealTypeHeader(eDealType iDealType)
    {
        string header = string.Empty;

        switch (iDealType)
        {
            case eDealType.CHARTER:
                header = "צ'רטר";
                break;
            case eDealType.FLIGHT:
                header = "טיסה סדירה";
                break;
        }

        return header;
    }
	
	public static string GetTimeByFormat(string iTimeFormat)
    {
        string time = string.Empty;

        time += iTimeFormat.Substring(0, 2);
        time += ":";
        time += iTimeFormat.Substring(2, 2);

        return time;
    }
	
	public static string GetSupplierIdByNameFromAlp(string iCompanyName, string iAgencyId, string iSystemType, 
													string iCommissionValue, string iServiceType, string iCarrierName)
    {
        return GetSupplierIdByName(iCompanyName, iAgencyId, iSystemType,
								   iCommissionValue, iServiceType, iCarrierName, 
								   Agency2000WS.eSourceTypes.Alp, string.Empty, string.Empty);
    }
	
	public static string GetSupplierIdByNameFromAmadeus(string iCompanyName, string iAgencyId, string iSystemType, 
													string iCommissionValue, string iServiceType, string iCarrierName)
    {
        return GetSupplierIdByName(iCompanyName, iAgencyId, iSystemType,
								   iCommissionValue, iServiceType, iCarrierName, 
								   Agency2000WS.eSourceTypes.Amadeus, string.Empty, string.Empty);
    }
	/*
	Utils.GetSupplierIdByName(iResponse.HotelName, ((MasterPage)Master).AgencyId, iResponse.Commission.pct,
                                                hotelServiceType, iResponse.HotelName, eSourceTypes.GoGlobal,
                                                iResponse.HotelId, iCityId);
	*/
    public static string GetSupplierIdByName(string iCompanyName, string iAgencyId, string iSystemType, 
											 string iCommissionValue,string iServiceType, string iCarrierName, 
											 Agency2000WS.eSourceTypes iSourceType, string iSupplierCodeFromOutService, string iGoGlobalCityId)
    {
        string supplierId = string.Empty;
        string accountCode = string.Empty;
        bool isErrorOccured = false;
        string name = iCompanyName;
		bool isGoGlobal = false;

        if(!string.IsNullOrEmpty(iGoGlobalCityId))
        {
            isGoGlobal = true;
        }

        try
        {
			//
			Agency2000WS.Agency2000WS ws = new Agency2000WS.Agency2000WS();
			supplierId = ws.GetSupplierIdByName(iCompanyName, iAgencyId, iSystemType,
												iCommissionValue, iServiceType, iCarrierName, 
												iSourceType, iSupplierCodeFromOutService, iGoGlobalCityId);
            // name = name.Replace("'", "''");
            // supplierId = DAL_SQL_Helper.GetSupplierIdByFlightCompanyId(name);

            // if (string.IsNullOrEmpty(supplierId))
            // {
                // supplierId = DAL_SQL_Helper.AddSupplier(name, iServiceType, iCarrierName);
                
                // if (!string.IsNullOrEmpty(supplierId))
                // {
                    // accountCode = DAL_SQL_Helper.AddAccountCode(supplierId, iAgencyId, name,
																// isGoGlobal);
                    // if (!string.IsNullOrEmpty(accountCode))
                    // {
                        // DAL_SQL_Helper.AddSupplierDetails(supplierId, accountCode, iCommissionValue);
                        // DAL_SQL_Helper.AddSuppliersToProductTypes(supplierId, iServiceType);
                    // }
                    // else
                    // {
                        // isErrorOccured = true;
                    // }

                    // if(iSourceType == eSourceTypes.GoGlobal)
                    // {
                        // DAL_SQL_Helper.AddGoGlobalHotelMap(supplierId, name, iSupplierCodeFromOutService,
                                                            // iGoGlobalCityId);
                    // }
                // }
                // else
                // {
                    // isErrorOccured = true;
                // }
            // }
        }
        catch (Exception ex)
        {
            supplierId = iCompanyName;
			Logger.Log("excep message = " + ex.Message + ", trace = " + ex.StackTrace);
            throw ex;
        }

        if (isErrorOccured)
        {
            //TODO
        }
	
        return supplierId;
    }
	
	public static string GetAirlineName(string iAirlineIATA)
    {
        string airlineName = DAL_SQL_Helper.GetAirlineNameByIATACode(iAirlineIATA);

        if (airlineName == string.Empty)
        {
			airlineName = DAL_SQL_Helper.GetAirlineNameByCarrier(iAirlineIATA);
			if (airlineName == string.Empty)
			{
				airlineName = iAirlineIATA;
			}
        }

        return airlineName;
    }
	
	public static string GetCompositionIdByTravellelrsAmount(int iNumOfAdults, int iNumOfChildren, int iNumOfInfants)
    {
        string compositionId = string.Empty;

        try
        {
           compositionId = DAL_SQL_Helper.GetCompositionIdByTravellers(iNumOfAdults, iNumOfChildren, iNumOfInfants);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return compositionId;
    }
	
	public static string GetHotelBaseIdByAlpCode(string iBaseCode)
    {
        return GetHotelBaseIdByCode(iBaseCode);
    }

    public static string GetHotelBaseIdByCode(string iBaseCode)
    {
        string baseId = string.Empty;

        if (iBaseCode.ToLower() == "ai")
        {
            iBaseCode = "AL";
        }

        try
        {
            baseId = DAL_SQL_Helper.GetHotelBaseIdByCode(iBaseCode);
            if (string.IsNullOrEmpty(baseId))
            {
                baseId = DAL_SQL_Helper.AddHotelBaseIdByAlpCode(iBaseCode);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return baseId;
    }
	
	public static string GetHotelRoomTypeIdByAlpRoomCode(string iAlpRoomTypeCode, string iSupplierName, string iSupplierId)
    {
        string roomTypeId = string.Empty;
        string roomTypeName = string.Empty;
        bool isNeedToAddRoomTypeId = false;

        try
        {
            roomTypeName = getHotelRoomTypeNameByAlpCode(iAlpRoomTypeCode, iSupplierName);
            if (string.IsNullOrEmpty(roomTypeName))
            {
                //couldn't find the room code in the alp table
                isNeedToAddRoomTypeId = true;
            }
            else
            {
                //found the room name of the code in the alp table
                roomTypeId = DAL_SQL_Helper.GetRoomTypeIdByAlpName(roomTypeName);
                if (string.IsNullOrEmpty(roomTypeId))
                {
                    isNeedToAddRoomTypeId = true;
                }
            }

            if (isNeedToAddRoomTypeId)
            {
                if (string.IsNullOrEmpty(roomTypeName))
                {
                    roomTypeId = DAL_SQL_Helper.AddRoomTypeByAlpCode(roomTypeName);
                }
                else
                {
                    roomTypeId = DAL_SQL_Helper.AddRoomTypeByAlpCode(iAlpRoomTypeCode);
                }

            }

            DAL_SQL_Helper.AddSuppliersToHotelAdds(roomTypeId, iSupplierId);

        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return roomTypeId;
    }
	
	private static string getHotelRoomTypeNameByAlpCode(string iAlpRoomTypeCode, string iSupplierName)
    {
        string roomTypeName = string.Empty;

        try
        {
            roomTypeName = DAL_SQL_Helper.GetRoomTypeNameByAlpCode(iAlpRoomTypeCode, iSupplierName);
            if (string.IsNullOrEmpty(roomTypeName))
            {
                roomTypeName = DAL_SQL_Helper.GetRoomTypeNameByAlpCode(iAlpRoomTypeCode, string.Empty);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return roomTypeName;
    }
	
	public static bool IsSupplierBelongToBsp(string iSupplierId)
	{
		bool isSupplierBelongToBsp;
		string isBelongForBspDB = DAL_SQL.RunSql("SELECT BelongToBsp FROM SUPPLIER_DETAILS WHERE supplier_id = " + iSupplierId);
		
		isSupplierBelongToBsp = (isBelongForBspDB.ToLower() == "1" || isBelongForBspDB.ToLower() == "true");
		
		return isSupplierBelongToBsp;
	}
	
	public static string Serialize<T>(T iObjToSerialize)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        var xml = "";

        using (var sww = new StringWriter())
        {
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                serializer.Serialize(writer, iObjToSerialize);
                xml = sww.ToString();
            }
        }

        return xml;
    }

    public static T Deserialize<T>(string iXml)
    {
        T obj;
        XmlSerializer deserializer = new XmlSerializer(typeof(T));

        using (var sww = new StringWriter())
        {
            using (StringReader oReader = new StringReader(iXml))
            {
                obj = (T)deserializer.Deserialize(oReader);
            }
        }

        return obj;
    }
	
	public static string SerializeJson<T>(T iObject)
    {
        string serializedProduct = JsonConvert.SerializeObject(iObject);

        return serializedProduct;
    }

    public static T DeserializeJson<T>(string iJson)
    {
        T deserializedProduct = JsonConvert.DeserializeObject<T>(iJson);

        return deserializedProduct;
    }
	
	public static DateTime? getDateTimeFromFormat(string iDate)
    {
        DateTime? parsedDateTime = null;
        try
        {
            parsedDateTime = DateTime.Parse(getDateByFormat(iDate));
        }
        catch { }
        return parsedDateTime;
    }
	  
	public static bool isEnumerableNullOrEmpty<T>(IEnumerable<T> list)
    {
        return list == null || !list.GetEnumerator().MoveNext();
    }

        public static bool IsStringsOverlapping(string iFirstString, string iSecondString)
    {
       return iFirstString.Contains(iSecondString) || iSecondString.Contains(iFirstString);
    }
	
	public static string GetCurrencySymbolByName(string iCurrencyName)
    {
        string symbol = string.Empty;
        string query = "SELECT ASCII_symbol as symbol FROM Agency_Admin.dbo.CURRENCIES WHERE name = '" + iCurrencyName + "'";

        try
        {
            symbol = DAL_SQL.RunSql(query);
            if (string.IsNullOrEmpty(symbol))
            {
                symbol = GetCurrencySignManualy(iCurrencyName);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return symbol;
    }
	
	public static string GetCurrencySignManualy(string iCurrencyId)
    {
        string currencySign = string.Empty;

        switch (iCurrencyId.Trim().ToUpper())
        {
            case "NIS":
            case "1":
                currencySign = "₪";
                break;
            case "USD":
            case "2":
                currencySign = "$";
                break;
            case "EUR":
            case "3":
                currencySign = "€";
                break;

            default:
                currencySign = "^^";
                break;
        }

        return currencySign;
    }
	
	public static void FillDdl(DropDownList iDdlRef, object iData, string iText,
                         string iValue, bool iIsAddSelectAllOption)
    {
        if (!iText.Equals(string.Empty) && !iValue.Equals(string.Empty))
        {
            iDdlRef.DataTextField = iText;
            iDdlRef.DataValueField = iValue;
        }
        iDdlRef.DataSource = iData;
        iDdlRef.DataBind();

        if (iIsAddSelectAllOption)
        {
            iDdlRef.Items.Insert(0, new ListItem("All", "0"));
        }
    }
	
	public static DateTime GetDateTimeFromString(string iDate)
    {
        DateTime dateTime = default(DateTime);
        string newDate = string.Empty;
        string[] dateAndTime = iDate.Split(' ');
        string date = dateAndTime[0];
        string time = dateAndTime.Length > 1 ? dateAndTime[1] : string.Empty;

        if (date.Contains("/"))
        {
            string[] dateSplitted = date.Split('/');
            string monthStr = string.Empty;

            //Check the month.
            switch (dateSplitted[1])
            {
                case "1":
                case "01":
                    monthStr = "JAN";
                    break;
                case "2":
                case "02":
                    monthStr = "FEB";
                    break;
                case "03":
                case "3":
                    monthStr = "MAR";
                    break;
                case "04":
                case "4":
                    monthStr = "APR";
                    break;
                case "05":
                case "5":
                    monthStr = "MAY";
                    break;
                case "06":
                case "6":
                    monthStr = "JUN";
                    break;
                case "07":
                case "7":
                    monthStr = "JUL";
                    break;
                case "08":
                case "8":
                    monthStr = "AUG";
                    break;
                case "09":
                case "9":
                    monthStr = "SEP";
                    break;
                case "10":
                    monthStr = "OCT";
                    break;
                case "11":
                    monthStr = "NOV";
                    break;
                case "12":
                    monthStr = "DEC";
                    break;
            }

            newDate = dateSplitted[0] + "-" + monthStr + "-" + dateSplitted[2];
        }

        if(!string.IsNullOrEmpty(newDate))
        {
            try
            {
                dateTime = DateTime.Parse(newDate + (string.IsNullOrEmpty(time) ? "" : " " + time));
            } 
            catch (Exception e)
            {
                Logger.Log(e);
            }
        }

        return dateTime;
    }
	
	public static string GetLangCodeAsStringFromCookies()
    {
        string lang = string.Empty;
        eLanguage eLang = GetLangFromCookies();
        lang = ((int)eLang).ToString();

        return lang;
    }

	public static string GetTextFromFile(string iNameInFile)
    {
        return GetTextFromFile(iNameInFile, GetLangCodeAsStringFromCookies());
    }

	public static bool IsAlreadyInActionLog(string iVoucherId, string iDoc)
    {
        string query = "SELECT id FROM VOUCHERS WHERE id in ( " +
                            " SELECT ref1 FROM ACCOUNT_ACTIONS_LOG WHERE ref1 = '" + iVoucherId + "' and doc = '" + iDoc + "' and deposit_id < 99999" +
                        ")";
        Logger.Log("query = " + query);
        string voucherIdFromDB = DAL_SQL.RunSql(query);
        Logger.Log("voucherIdFromDB = " + voucherIdFromDB);
        Logger.Log("voucherIdFromDB == iVoucherId = " + voucherIdFromDB == iVoucherId);

        return voucherIdFromDB == iVoucherId;
    }

    private static void insertToAccountActionLog(string iDb, string iCr, string iRefDate,
                                          string iValueDate, string iDoc, string iRef1,
                                          string iAmountUsd, string iAmountNis, string iAmount,
                                          string iCurrencyId, string iRef2, string iIncomeTypeId,
                                          string iClerkId, string iRef3, string iDoc1,
                                          string iOriginDocId, string iExchangeRate, string iActionType,
                                          string iDepartmentId, string iRef4, string iRefAmount)
    {
        string query = string.Format(@" 
INSERT INTO ACCOUNT_ACTIONS_LOG 
		(id,				db,						cr,				
		ref_date,			value_date,				doc,			
		ref1,				amount_usd,				amount_nis,		
		amount,				currency_id,			ref2,			
		income_type_id,		cclerk_id,				ref3,			
		doc1,				origin_doc_id,			exchange_rate,	
		action_type,		department_id,			ref4,			
		ref_amount)
 VALUES 
	({0}, '{1}', '{2}',
	'{3}', '{4}', N'{5}',
	'{6}', {7}, {8}, 
	{9}, {10}, '{11}',
	{12}, {13},'{14}',
	N'{15}', '{16}', '{17}', 
	'{18}', '{19}',	'{20}',
	{21})",
            /* 0 - 2 */ "ISNULL((SELECT max(id) +1 FROM ACCOUNT_ACTIONS_LOG), 1)", iDb, iCr,
            /* 3 - 5 */ iRefDate, iValueDate, iDoc,
            /* 6 - 8 */ iRef1, iAmountUsd, iAmountNis,
            /* 9 - 11*/ iAmount, iCurrencyId, iRef2,
            /*12 - 14*/ iIncomeTypeId, iClerkId, iRef3,
            /*15 - 17*/ iDoc, iOriginDocId, iExchangeRate,
            /*18 - 20*/ iActionType, iDepartmentId, iRef4,
            /*21 - 23*/ iRefAmount);

        try
        {
            Logger.Log(query);
            DAL_SQL.RunSql(query);
        }
        catch (Exception e)
        {
            Logger.Log("Failed To insertToAccountActionLog. Message= " + e.Message);
        }
    }


    public static void CreateVCHInActiongLogByVouchers(List<string> iVouchers, string iClerkId)
    {
        List<LineActionLogVCH> mLines = new List<LineActionLogVCH>();
        string vouchersFoQuery = string.Join(",", iVouchers);

        string query = " SELECT B.docket_id, V.id as voucher_id, V.bundle_id, " +
                       " 		 B.carrier, SD.commission_percentage, B.amount as total_amount, BTT.f_ticket, " +
                       " 		 Btt.amount as ticket_amount, Btt.tax, BTT.mark_up as ticket_mark_up, Btt.price, B.to_supplier, B.total_supplier, " +
                       "        B.to_clerk, B.to_clerk_vat, B.payment_type_id, (B.mark_up + B.mark_up_vat) as total_mark_up, " +
                       "		 CASE WHEN B.payment_type_id = 3 then " +
                       "			ISNULL(commision_value, B.to_clerk) * (-1) " +
                       "		 ELSE " +
                       "			B.to_supplier " +
                       "		 END as netto, " +
                       "        B.xchange_rate_usd, B.xchange_rate_nis, B.income_type, B.pay_to_supplier_id, " +
                       "        V.prq_id , B.commision_value, V.status, B.currency_id, B.service_type, B.cdate " +
                       " FROM BUNDLES_to_TRAVELLERS BTT RIGHT JOIN BUNDLES B ON B.id = BTT.bundle_id " +
                       "      INNER JOIN VOUCHERS V ON V.bundle_id = B.id " +
                       "      INNER JOIN SUPPLIER_DETAILS SD ON SD.supplier_id = B.carrier " +
                       " WHERE V.id IN (" + vouchersFoQuery + ")";
        //" 	   AND (B.service_type = 1 or B.service_type = 12)";
        //" WHERE V.id IN (148)" + 

        Logger.Log("query = " + query);
        DataSet details = DAL_SQL.RunSqlDataSet(query);

        Logger.Log("before Utils.IsDataSetRowsNotEmpty(details)");
        if (Utils.IsDataSetRowsNotEmpty(details))
        {
            Logger.Log("passed Utils.IsDataSetRowsNotEmpty(details)");
            foreach (DataRow row in details.Tables[0].Rows)
            {
                LineActionLogVCH line = new LineActionLogVCH();
                if (row["status"].ToString() == "1")
                {
                    line.DocketId = row["docket_id"].ToString();
                    line.VoucherId = row["voucher_id"].ToString();
                    line.BundleId = row["bundle_id"].ToString();
                    line.TicketNumberFromDB = row["f_ticket"].ToString();
                    line.AllTickets = string.Empty;
                    line.IsMoreThanOneTicketsInTraveller = false;
                    line.Carrier = row["carrier"].ToString();
                    line.CurrencyIdFromDB = row["currency_id"].ToString();
                    line.PayToSupplierFromDB = row["pay_to_supplier_id"].ToString();
                    line.TotalAmount = decimal.Parse(row["total_amount"].ToString());
                    line.TotalMarkUp = decimal.Parse(row["total_mark_up"].ToString());
                    //If service is flight then BTT.amount (ticket_amount), if DocketCreateFee then B.amount 
                    line.TicketsAmount = (row["service_type"].ToString() == "1") ?
                                            decimal.Parse(row["ticket_amount"].ToString()) :
                                            (row["service_type"].ToString() == "12") ? decimal.Parse(row["total_amount"].ToString()) : 0M;
                    line.TicketsTax = (row["service_type"].ToString() == "1") ? decimal.Parse(row["tax"].ToString()) : 0M;
                    line.TicketsMarkUp = (row["service_type"].ToString() == "1") ? decimal.Parse(row["ticket_mark_up"].ToString()) : 0M;
                    line.TicketsPrice = (row["service_type"].ToString() == "1") ? decimal.Parse(row["price"].ToString()) : 0M;
                    line.BruttoFromDb = decimal.Parse(row["total_supplier"].ToString());
                    line.CommissionFromDb = decimal.Parse(row["commision_value"].ToString());
                    line.ToClerk = row["to_clerk"].ToString();
                    line.ToClerkVat = "0";// details.Tables[0].Rows[0]["to_clerk_vat"].ToString(); //TODO: ask yossi Maybe always 0...?
                    line.CommissionPercent = decimal.Parse(row["commission_percentage"].ToString());
                    line.ExchangeRateUsd = decimal.Parse(row["xchange_rate_usd"].ToString());
                    line.ExchangeRateNis = decimal.Parse(row["xchange_rate_nis"].ToString());
                    line.IncomeTypeId = row["income_type"].ToString();
                    line.PaymentTypeId = row["payment_type_id"].ToString();
                    line.TotalNetto = decimal.Parse(row["netto"].ToString());
                    line.ValueDate = DateTime.Parse(row["cdate"].ToString()).ToString("dd-MMM-yy");
                    line.RefDate = DateTime.Parse(row["cdate"].ToString()).ToString("dd-MMM-yy");
                    Logger.Log("before mLines.Add(line);");
                    mLines.Add(line);
                }
            }
        }

        string prqId = string.Empty;

        Logger.Log("before mLines.Count > 0");
        if (mLines.Count > 0)
        {
            Logger.Log("mLines.Count > 0");
            string refundId = "";
            string isAdvance = "0";
            string refDate = "";
            string lineCurrencyId;
            string ref2 = "0", ref4 = "";
            string refAmount = "0";
            string actionType = "3"; //in Agency send 0, and there is a check if its 0 change to 3.
            string amountUsd, amountNis, amount;
            string cr;
            string clerkId = iClerkId;
            if (clerkId == "")
            {
                clerkId = "1";
            }
            string departmentId = DAL_SQL.RunSql("SELECT department_id FROM CLERKS WHERE id = " + clerkId);

            Logger.Log("before foreach mLines");
            foreach (LineActionLogVCH line in mLines)
            {
                Logger.Log("line Start - " + line.VoucherId);
                if (!IsAlreadyInActionLog(line.VoucherId, "VCH"))
                {
                    Logger.Log("line BruttoFromDb - " + line.BruttoFromDb);
                    if (line.BruttoFromDb != 0)
                    {
                        Logger.Log("isVouchersAlreadyInActionLog passed");

                        amountUsd = (line.BruttoFromDb * line.ExchangeRateUsd).ToString(); //Price in NIS
                        amountNis = (line.BruttoFromDb * line.ExchangeRateNis).ToString(); //Price in USD
                        amount = line.BruttoFromDb.ToString(); //Origin amount						

                        lineCurrencyId = line.CurrencyIdFromDB;
                        cr = DAL_SQL.RunSql("SELECT account_code FROM ACCOUNT_CODES WHERE type_id = 6 AND table_id = " + line.PayToSupplierFromDB);

                        Logger.Log("before insertToAccountActionLog");
                        refDate = line.RefDate;//DateTime.Now.ToString("dd-MMM-yy");
                        //line.ValueDate = DateTime.Parse(cdate);//DateTime.Now.ToString("dd-MMM-yy");
                        insertToAccountActionLog(line.DocketId, cr, refDate,
                                                 line.ValueDate, "VCH", line.VoucherId,
                                                 amountUsd, amountNis, amount,
                                                 lineCurrencyId, ref2, line.IncomeTypeId,
                                                 clerkId, line.BundleId, "VCH",
                                                 line.DocketId, line.ExchangeRateUsd.ToString(), actionType,
                                                 departmentId, ref4, refAmount);
                        Logger.Log("after insertToAccountActionLog");
                    }
                }
            }
        }
    }
	
	public static string GetSupplierAccountCodeNew(string iSupplierId, string iIncomeTypeId)
    {
        string accountCode, useSupplierIncomeAccCode;

        if (!string.IsNullOrEmpty(iSupplierId))
        {
            useSupplierIncomeAccCode = DAL_SQL.RunSql("SELECT use_supplier_income_acc_code FROM AGENCIES WHERE id = id");// + mAgencyId);
            if (useSupplierIncomeAccCode == "1" && iIncomeTypeId != "0") // use supplier income acc. code
            {
                // need to get the supplier income type account code account code
                accountCode = DAL_SQL.RunSql("SELECT account_code FROM SUPPLIERS_TO_INCOME_TYPE_ACCOUNTS WHERE supplier_id = '" + iSupplierId + "' AND income_type_id = " + iIncomeTypeId);
            }
            else //' regullar supplier account code from account codes table
            {
                accountCode = DAL_SQL.RunSql("SELECT account_code FROM ACCOUNT_CODES WHERE type_id = 6 AND table_id = " + iSupplierId);
            }

            if (string.IsNullOrEmpty(accountCode) ||
            !string.IsNullOrEmpty(accountCode) && accountCode == "0")
            {
                accountCode = "99999999";
            }
        }
        else
        {
            accountCode = "Error in SupplierID!";
        }

        return accountCode;
    }
}