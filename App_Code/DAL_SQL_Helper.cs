using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for DAL_SQL_HELPER
/// </summary>
public class DAL_SQL_Helper
{
	public DAL_SQL_Helper()
	{
		
	}
	
	public static DataSet GetAllHotels(string lang)
    {
        DataSet ds = new DataSet();
        string serviceType = "2";//Hotels

        try
        {
            ds = DAL_SQL.RunSqlDataSet(string.Format(@" SELECT	S.id, S.name_1255, S.name_1252, S.name_1251
														FROM  AGENCY_ADMIN.dbo.SUPPLIERS S INNER JOIN
														      dbo.SUPPLIERS_to_PRODUCT_TYPES S_T_P ON S.id = S_T_P.supplier_id 
														WHERE
														(S_T_P.product_type = {0})
														order by S.name_{1}", serviceType, lang));
        }
        catch (Exception ex)
        {
            Logger.Log(string.Format("Failed to get hotels. ({0})", ex.Message));
            throw ex;
        }

        return ds;
    }

    public static DataTable GetAgencyDetails(int agencyid)
    {
        DataSet ds = new DataSet();
        string query = "SELECT * FROM AGENCIES WHERE id = @agencyid";

        ds = DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.Text, query,
          SqlDalParam.formatParam("@agencyid", SqlDbType.Int, agencyid));
        DataTable dt = ds.Tables[0];

        return dt;
    }
	
	public static int GetGroupId(int iClerkId)
    {
        DataSet ds = new DataSet();
        int groupId = -1;

        try
        {
            ds = DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.StoredProcedure, "GetGroupId",
                SqlDalParam.formatParam("@clerkId", SqlDbType.Int, iClerkId)
            );

			Logger.Log("2");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
				Logger.Log("3");
                groupId = int.Parse(ds.Tables[0].Rows[0]["security_group_id"].ToString());
            }
        }
        catch (Exception ex)
        {
            Logger.Log(string.Format("Failed to get group id. ({0})", ex.Message));
            throw ex;
        }

        return groupId;
    }

    public static DataSet GetGroupSecurityPage(int iGroupId, int iResourceId)
    {
        DataSet ds = new DataSet();

        try
        {
            ds = DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.StoredProcedure, "GetGroupSecurityPage",
                SqlDalParam.formatParam("@groupId", SqlDbType.Int, iGroupId),
                SqlDalParam.formatParam("@resourceId", SqlDbType.Int, iResourceId)
            );
        }
        catch (Exception ex)
        {
            Logger.Log(string.Format("Failed to get group. ({0})", ex.Message));
            throw ex;
        }

        return ds;
    }
	
	public static DataSet GetAllCompositions()
    {
        DataSet ds = DAL_SQL.RunSqlDataSet("SELECT * FROM Agency_Admin.dbo.HOTEL_ROOM_TYPE");

        return ds;
    }

    public static void UpdateCompositionStatus(string iCompositionId, bool iStatus)
    {
        //if true then disable 
        //if false then active
        DAL_SQL.RunSql(" UPDATE Agency_Admin.dbo.HOTEL_ROOM_TYPE " +
                       " SET isDisabled = '" + ((iStatus) ? "1" : "0") + "' " +
                                   " WHERE id = " + iCompositionId);
    }

    public static void AddCompoisition(string id, bool status, string name,
                                       string adults, string children, string babies,
                                       string foreignName, string name1255, string name1252,
                                       string name1251, string p2d, ref string message)
    {
        string description = name;

        DAL_SQL.RunSql(string.Format(@" INSERT INTO Agency_Admin.dbo.HOTEL_ROOM_TYPE 
                          (id, name, adt_amount, chd_amount, description, isDisabled, foreignName, name_1255, name_1252, name_1251, babies, PNR_TO_DOCKET_ODDISSEY_CODE)
                    VALUES((SELECT MAX(id) FROM Agency_Admin.dbo.HOTEL_ROOM_TYPE) + 1, N'{0}', N'{1}', N'{2}', N'{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}')",
                           name, adults, children, description, (status) ? "0" : "1", foreignName, name1255, name1252, name1251, babies, p2d));
    }
	
	public static DataSet GetHotelToCompositions(string iSupplierId)
    {
        DataSet ds = DAL_SQL.RunSqlDataSet("SELECT * FROM Agency_Admin.dbo.Rooms_In_Hotels WHERE HotelId = " + iSupplierId);

        return ds;
    }

    public static void ConnectCompositionToHotel(string iCompositionId, string iSupplierId)
    {
        DataSet ds = DAL_SQL.RunSqlDataSet("INSERT INTO Agency_Admin.dbo.Rooms_In_Hotels (HotelId, RoomTypeId) VALUES(" + iSupplierId + " ," + iCompositionId + ")");
    }

    public static string GetSupplierIdByFlightCompanyId(string iResponseCompanyId)
    {
        string supplierId = DAL_SQL.RunSql("SELECT id FROM Agency_Admin.dbo.SUPPLIERS WHERE name = '" + iResponseCompanyId + "'");

        //TODO: If not exists consider add new supplier.

        return supplierId;
    }

    public static string GetPortIdByName(string iAirPortName)
    {
        //string pordId = DAL_SQL.RunSql("SELECT id FROM Agency_Admin.dbo.LOCATIONS WHERE symbol = '" + iAirPortName + "'");
        string pordId = DAL_SQL.RunSql("SELECT id FROM dbo.LOCATIONS WHERE symbol = '" + iAirPortName + "'");

        //TODO: If not exists consider add new location.

        return pordId;
    }

    public static void InsertNewTraveller(Traveller iTraveller, int iAgencyId, int iClerkId, 
                                          out string oTravellerDbId)
    {
        DataSet ds = new DataSet();
        string todayDate = DateTime.Now.ToString("dd-MMM-yy");

        try
        {
            ds = DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.StoredProcedure, "PKG_InsertTraveller",
                                        SqlDalParam.formatParam("@FirstName", SqlDbType.NVarChar, iTraveller.FirstName),
                                        SqlDalParam.formatParam("@LastName", SqlDbType.NVarChar, iTraveller.LastName),
                                        SqlDalParam.formatParam("@TitleId", SqlDbType.Int, iTraveller.Title),
                                        SqlDalParam.formatParam("@IdNum", SqlDbType.NVarChar, iTraveller.Id),
                                        SqlDalParam.formatParam("@PassNum", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@GenderId", SqlDbType.TinyInt, iTraveller.GenderId),
                                        SqlDalParam.formatParam("@BirthDate", SqlDbType.NVarChar, (iTraveller.DateOfBirth != null) ? iTraveller.DateOfBirth.Value.ToString("dd-MMM-yy") : string.Empty),
                                        SqlDalParam.formatParam("@HomeStreet", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@HomeDistrict", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@HomeCity", SqlDbType.NVarChar, iTraveller.Address),
                                        SqlDalParam.formatParam("@HomeZip", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@HomePob", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@HomeRemark", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@WorkStreet", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@WorkDistrict", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@WorkCity", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@WorkZip", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@WorkPob", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@WorkRemark", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@CcNumber", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@CcType", SqlDbType.SmallInt, 0),
                                        SqlDalParam.formatParam("@CcValidThru", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@CcCvv", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@CcMethod", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@CcPayments", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@Email", SqlDbType.NVarChar, iTraveller.Mail),
                                        SqlDalParam.formatParam("@Remark", SqlDbType.NText, iTraveller.Remarks),
                                        SqlDalParam.formatParam("@CDate", SqlDbType.NVarChar, todayDate),
                                        SqlDalParam.formatParam("@AuthorId", SqlDbType.Int, iClerkId),
                                        SqlDalParam.formatParam("@UDate", SqlDbType.NVarChar, todayDate),
                                        SqlDalParam.formatParam("@LastUpdateClerkId", SqlDbType.Int, iClerkId),
                                        SqlDalParam.formatParam("@AgeGroupId", SqlDbType.TinyInt, 1),
                                        SqlDalParam.formatParam("@AgencyId", SqlDbType.Int, iAgencyId),
                                        SqlDalParam.formatParam("@TravellerTypeId", SqlDbType.Int, iTraveller.Type),
                                        SqlDalParam.formatParam("@FoodRemark", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@IsKasher", SqlDbType.NVarChar, "on"),
                                        SqlDalParam.formatParam("@IsVegetarian", SqlDbType.NVarChar, "off"),
                                        SqlDalParam.formatParam("@RoomTypeId", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@RoomIndex", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@RoomsAmount", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@PnrNumber", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@OfficeRemark", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@TransportOfficeId", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@IsChecked", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@ClientNumber", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@FoodTypeId", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@BirthCountryId", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@SpeakLanguageId", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@Status", SqlDbType.Int, 1),
                                        SqlDalParam.formatParam("@CcReference", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@CcNumberNew", SqlDbType.VarBinary, DBNull.Value),
                                        SqlDalParam.formatParam("@CcLast4Digits", SqlDbType.NVarChar, "-1"),
                                        SqlDalParam.formatParam("@GovMakatNumber", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@GovDocketId", SqlDbType.NVarChar, string.Empty),
                                        SqlDalParam.formatParam("@GovStartMakatDate", SqlDbType.DateTime, DBNull.Value),
                                        SqlDalParam.formatParam("@GovBalanceUssage", SqlDbType.Bit, SqlBoolean.False),
                                        SqlDalParam.formatParam("@GovLevel", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@Gov5thNightPay", SqlDbType.Bit, SqlBoolean.False),
                                        SqlDalParam.formatParam("@MelaveNumber", SqlDbType.Int, 0),
                                        SqlDalParam.formatParam("@LastNameEn", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@FirstNameEn", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@FirstName2", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@LastName2", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@Status1", SqlDbType.Int, 1),
                                        SqlDalParam.formatParam("@CcTz", SqlDbType.NVarChar, DBNull.Value),
                                        SqlDalParam.formatParam("@CcToken", SqlDbType.NVarChar, DBNull.Value));
            if (Utils.IsDataSetRowsNotEmpty(ds))
            {
                oTravellerDbId = ds.Tables[0].Rows[0]["id"].ToString();
            }
            else
            {
                Logger.Log("Traveller information not inserted fully to DB.");
                oTravellerDbId = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Logger.Log(ex);
            throw ex;
        }
    }

    public static string CreateBundleRow(string iDocketId, string iServiceType, int iClerkId, 
                                         string iTodayDateStr, string iFromDate, string iToDate,
                                         string iSupplierId,out string ioBundleId)
    {
        string query = string.Format(
@"INSERT INTO BUNDLES (id, docket_id, service_type, 
                       cdate, author_id, last_update_date, 
                       last_update_clerk_id, from_date, to_date, 
                       carrier, pay_to_supplier_id) 
              OUTPUT Inserted.id
     	       VALUES ({0}, '{1}', '{2}', 
                       '{3}', '{4}', '{3}', 
                       '{4}', '{5}', '{6}', 
                       '{7}', '{7}')  
			" /*Will eventualy return the inserted BUNDLES 'id'. */
            /*{0}*/, "ISNULL((SELECT max(B1.id) + 1 FROM BUNDLES B1), 1)"
            /*{1}*/, iDocketId
            /*{2}*/, iServiceType
            /*{3}*/, iTodayDateStr
            /*{4}*/, iClerkId
            /*{5}*/, iFromDate
            /*{6}*/, iToDate
            /*{7}*/, iSupplierId
        );

        string bundleId;

        try
        {
            Logger.Log(query);
            bundleId = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed To createBundleRow. Exception Message = " + ex.Message + Environment.NewLine + query);
        }

        ioBundleId = bundleId;
        return bundleId;
    }

    public static void CreateBundlesToTravellerForOneTraveller(Traveller iTraveller, string iBundleId, string iFromDate, string iToDate, string iTravellerIdFromDb)
    {
        decimal amount;
        decimal price;
        string tax = "0";
        string flightAddAmount = "0";
        decimal totalToSupp;
        string markUp = "0";
        string subsid = "0";
        string travPay = "0";
        string quantity = "1";//Always 1. cause 2 adults is 2 row. so 1 adult, 1 adult.
        string tourAmount = "0";
        string flightTaxAmount = "0";
        string tourAddAmount = "0";
        string visaAmount = "0";
        string insuranceAmount = "0";
        string remark = string.Empty;
        string fTicket = string.Empty;
        string travellerType = string.Empty;
        string nettoAmount = "0";
        string supplierAddId = string.Empty;
        string queryInsertBTTRow;

        amount = iTraveller.Brutto;
        price = iTraveller.Brutto;
        totalToSupp = iTraveller.Brutto;

        queryInsertBTTRow = string.Format(@"
INSERT INTO BUNDLES_to_TRAVELLERS (id,					bundle_id,				traveller_id,
								amount,					price,					tax,
								flight_add_amount,		total_to_sup,			mark_up,
								subsid,					trav_pay,				from_date,
								to_date,				quantity,				tour_amount,
								flight_tax_amount,		tour_add_amount,		visa_amount,
								insurance_amount,		remark,					f_ticket,
								traveller_type,			neto_amount,            supplier_add_id)
						VALUES ({0},'{1}', N'{2}', 
								'{3}', N'{4}', N'{5}', 
								'{6}', '{7}', '{8}', 
								'{9}', '{10}', '{11}', 
								'{12}', N'{13}', '{14}', 
								'{15}', '{16}', '{17}', 
								'{18}', '{19}', '{20}', 
								'{21}', '{22}', '{23}')"
            /*{0}*/, "ISNULL((SELECT max(BTT.id) + 1 FROM BUNDLES_to_TRAVELLERS BTT), 1)"
            /*{1}*/, iBundleId
            /*{2}*/, iTravellerIdFromDb
            /*{3}*/, amount
            /*{4}*/, price
            /*{5}*/, tax
            /*{6}*/, flightAddAmount
            /*{7}*/, totalToSupp
            /*{8}*/, markUp
            /*{9}*/, subsid
            /*{10}*/, travPay
            /*{11}*/, iFromDate
            /*{12}*/, iToDate
            /*{13}*/, quantity
            /*{14}*/, tourAmount
            /*{15}*/, flightTaxAmount
            /*{16}*/, tourAddAmount
            /*{17}*/, visaAmount
            /*{18}*/, insuranceAmount
            /*{19}*/, remark
            /*{20}*/, fTicket
            /*{21}*/, travellerType
            /*{22}*/, nettoAmount
            /*{23}*/, supplierAddId
);

        try
        {
            Logger.Log(queryInsertBTTRow);
            DAL_SQL.RunSql(queryInsertBTTRow);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed To createBundlesToTravellers. Exception Message = " + ex.Message + Environment.NewLine + queryInsertBTTRow);
        }
    }

    public static void CreateFlightRow(FlightRow flight ,string iBundleId)
    {
        string queryInsertFlight;

        queryInsertFlight = string.Format(@"
INSERT INTO FLIGHTS(id,				        bundle_id,				         pnr,
					departure_port_name_,	departure_date,			         departure_time,
					departure_terminal,		flight_route_type,		         arrival_port_name_,
					arrival_date,			arrival_time,			         paid_to_supplier_id,
					flight_number,			class,				             leg_order,
					service_status_id,		income_type_id,		             payment_type_id,
					intermediate_landings,	miles,					         availability,
					data_resource_id,		data_recieved_date,			     data_thru_clerk_id,
					departure_port_id,		arrival_port_id,			     _currency_id,
					_adl_price,		        _port_tax,					     _chd_price,
					_inf_price,		        _snr_price,					     _additional_tax,
					remark,		            commission_percentage_override,  nights,
					flight_price_id,		external_flight_id)
			VALUES ({0},{1}, N'{2}', 
					N'{3}', N'{4}', N'{5}', 
					'{6}',  '{7}',  '{8}', 
					'{9}',  '{10}', '{11}', 
					'{12}', '{13}', '{14}', 
					'{15}', '{16}', '{17}', 
					'{18}', '{19}', '{20}', 
					'{21}', '{22}', '{23}', 
					'{24}', '{25}', '{26}', 
					'{27}', '{28}', '{29}', 
					'{30}', '{31}', '{32}',
                    '{33}', '{34}', '{35}',
                    '{36}', '{37}')"
            /*{0}*/, "ISNULL((SELECT max(F.id) + 1 FROM FLIGHTS F), 1)"
            /*{1}*/, iBundleId
            /*{2}*/, flight.PNR
            /*{3}*/, flight.DeparturePortName
            /*{4}*/, flight.DepartureDate.ToString("dd-MMM-yy")
            /*{5}*/, flight.DepartureTime
            /*{6}*/, flight.DepartureTerminal
            /*{7}*/, flight.FlightRouteType
            /*{8}*/, flight.ArrivalPortName
            /*{9}*/, flight.ArrivalDate.ToString("dd-MMM-yy")
            /*{10}*/, flight.ArrivalTime
            /*{11}*/, flight.PaidToSupplierId
            /*{12}*/, flight.FlightNumber
            /*{13}*/, 1 + (flight.Class.ToCharArray()[0] - 'A') //Will give number from 1 to 26
            /*{14}*/, flight.LegOrder
            /*{15}*/, flight.ServiceStatusId
            /*{16}*/, flight.IncomeTypeId
            /*{17}*/, flight.PaymentTypeId
            /*{18}*/, flight.IntermediateLandings
            /*{19}*/, flight.Miles
            /*{20}*/, flight.Availability
            /*{21}*/, flight.DataResourceId
            /*{22}*/, flight.DataRecievedDate.ToString("dd-MMM-yy")
            /*{23}*/, flight.DataThruClerkId
            /*{24}*/, flight.DeparturePortId
            /*{25}*/, flight.ArrivalPortId
            /*{26}*/, flight.CurrencyId
            /*{27}*/, flight.AdultPrice
            /*{28}*/, flight.PortTax
            /*{29}*/, flight.ChildPrice
            /*{30}*/, flight.InfantPrice
            /*{31}*/, flight.SeniorPrice
            /*{32}*/, flight.AdditionalTax
            /*{33}*/, flight.Remark
            /*{34}*/, flight.CommissionPercentageOverride
            /*{35}*/, flight.Nights
            /*{36}*/, flight.FlightPriceId
            /*{37}*/, flight.ExternalFlightId
);
        try
        {
            Logger.Log(queryInsertFlight);
            DAL_SQL.RunSql(queryInsertFlight);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed To CreateNewFlight. Exception Message = " + ex.Message + Environment.NewLine + queryInsertFlight);
        }
    }

    public static string GetTitleIdByName(string iTitle)
    {
        string title = string.Empty;
		//Logger.Log("iTitle = " +iTitle);
        title = DAL_SQL.RunSql("SELECT id FROM Agency_Admin.dbo.PERSON_TITLES WHERE name = '" + iTitle + "'");

        return title;
    }

    public static DataSet GetLocations()
    {
        DataSet ds = new DataSet();
        //string query = "SELECT symbol, name,name +' (' + symbol + ')' as display FROM Agency_Admin.dbo.LOCATIONS WHERE service_type_id = 1";
		string query = "SELECT symbol, name,name +' (' + symbol + ')' as display FROM dbo.LOCATIONS WHERE service_type_id = 1";

        try
        {
            ds = DAL_SQL.RunSqlDataSet(query);
        }
        catch(Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return ds;
    }

    public static string GetCurrencySymbol(string iCurrencyName)
    {
        string symbol = string.Empty;
        string query = "SELECT ASCII_symbol as symbol FROM Agency_Admin.dbo.CURRENCIES WHERE name = '" + iCurrencyName + "'";

        try
        {
            symbol = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return symbol;
    }

    public static string GetAirlineNameByIATACode(string iIATACode)
    {
        string query = string.Format("SELECT name FROM Agency_Admin.dbo.AIRLINES_CODES WHERE code = '{0}'", iIATACode);
        string airlineName = string.Empty;

        try
        {
            airlineName = DAL_SQL.RunSql(query);
        }
        catch(Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return airlineName;
    }
	
	public static string GetAirlineNameByCarrier(string iIATACode)
    {
        string query = string.Format("SELECT TOP 1 name FROM Agency_Admin.dbo.SUPPLIERS WHERE carrier = '{0}'", iIATACode);
        string airlineName = string.Empty;

        try
        {
            airlineName = DAL_SQL.RunSql(query);
        }
        catch(Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return airlineName;
    }

    public static string GetAircraftTypeByIATACode(string iIATACode)
    {
        string query = string.Format("SELECT name FROM Agency_Admin.dbo.AIRCRAFT_TYPES WHERE iata_code = '{0}'", iIATACode);
        string aircraftType = string.Empty;

        try
        {
            aircraftType = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return aircraftType;
    }
	
	public static string GetPortIdBySymbol(string iAirPortName)
    {
        //string pordId = DAL_SQL.RunSql("SELECT id FROM Agency_Admin.dbo.LOCATIONS WHERE symbol = N'" + iAirPortName + "'");
        string pordId = DAL_SQL.RunSql("SELECT id FROM dbo.LOCATIONS WHERE symbol = '" + iAirPortName + "'");

        //TODO: If not exists consider add new location.

        return pordId;
    }
	
	public static string AddPortToLocations(string iAirPortName)
    {

        //TODO: get the name by airport symbol (TLV -> TEL-AVIV)
        string airportId = string.Empty;
        const string countryId = "500"; //in COUNTRIES - id = 500 is general
        string name = iAirPortName;//string.Empty;
        string textHebrew = string.Empty;
        string portTax = "0.00";
        string serviceTypeId = "1";
        string isVat = "0";
		//Agency_Admin.dbo.LOCATIONS
        string query = string.Format(@"INSERT INTO dbo.LOCATIONS (id, symbol, name, port_tax, service_type_id, is_vat, country_id)
OUTPUT inserted.id
VALUES (ISNULL((SELECT max(id) + 1 FROM dbo.LOCATIONS), 1), '{0}', '{1}', '{2}', {3}, {4}, {5})",
/*{0}*/iAirPortName,
/*{1}*/name,
/*{2}*/portTax,
/*{3}*/serviceTypeId,
/*{4}*/isVat,
/*{5}*/countryId);
///*{6}*/textHebrew);

        try
        {
            airportId = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return airportId;
    }
	
	public static string GetCompositionIdByTravellers(int iNumOfAdults, int iNumOfChildren, int iNumOfInfants)
    {
        string compositionId = string.Empty;
        string query = string.Format(@"SELECT TOP(1) id
FROM Agency_Admin.dbo.HOTEL_ROOM_TYPE
WHERE adt_amount = '{0}' AND chd_amount = '{1}' AND babies = '{2}' AND rooms = '1' AND isDisabled = '0'", iNumOfAdults, iNumOfChildren, iNumOfInfants);

        try
        {
            compositionId = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return compositionId;
    }
	
	public static string AddHotelBaseIdByAlpCode(string iAlpBaseName)
    {
        string baseId = string.Empty;
        string name = iAlpBaseName;
        string description = iAlpBaseName;
        string isDisabled = "1";
        string foreignName = iAlpBaseName;
        string name1251 = iAlpBaseName;
        string name1252 = iAlpBaseName;
        string name1255 = iAlpBaseName;
        string pnrToDocketOddisseyCode = iAlpBaseName;
        string govCode = "0";
        string query = string.Format(@"INSERT INTO Agency_Admin.dbo.HOTEL_ON_BASE (id,          name,           description,
                                                                                   isDisabled,  foreignName,    name_1251,
                                                                                   name_1252,   name_1255,      PNR_TO_DOCKET_ODDISSEY_CODE,
                                                                                   gov_code)
                                        OUTPUT inserted.id
                                        VALUES  ({0},  '{1}', '{2}',
                                                '{3}', '{4}', '{5}',
                                                '{6}', '{7}', '{8}',
                                                '{9}'",
                                                /*{0}*/"ISNULL((SELECT max(id) + 1 FROM Agency_Admin.dbo.HOTEL_ON_BASE), 1)",
                                                /*{1}*/name,
                                                /*{2}*/description,
                                                /*{3}*/isDisabled,
                                                /*{4}*/foreignName,
                                                /*{5}*/name1251,
                                                /*{6)*/name1252,
                                                /*{7}*/name1255,
                                                /*{8}*/pnrToDocketOddisseyCode,
                                                /*{9}*/govCode);

        try
        {
            Logger.Log(query);
            baseId = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return baseId;
    }
	
	public static string GetHotelBaseIdByCode(string iCode)
    {
        string baseId = string.Empty;
        string query = string.Format("SELECT TOP(1) id FROM Agency_Admin.dbo.HOTEL_ON_BASE WHERE PNR_TO_DOCKET_ODDISSEY_CODE = '{0}'", iCode);

        try
        {
            baseId = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            baseId = string.Empty;
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return baseId;
    }
	
	public static string GetRoomTypeNameByAlpCode(string iAlpRoomTypeCode, string iSupplierName)
    {
        string roomTypeName = string.Empty;
        string supplierNameCondition = string.Empty;
        string query = string.Empty;

        if (!string.IsNullOrEmpty(iSupplierName))
        {
            supplierNameCondition = " AND supplier_name = '" + iSupplierName + "'";
        }

        query = string.Format("SELECT TOP(1) alp_name FROM Agency_Admin.dbo.ALP_ROOM_TYPES WHERE alp_id = '{0}'{1}", iAlpRoomTypeCode, supplierNameCondition);

        try
        {
            roomTypeName = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return roomTypeName;
    }
	
	public static string GetRoomTypeIdByAlpName(string iAlpRoomTypeName)
    {
        return GetRoomTypeIdByName(iAlpRoomTypeName);
    }

    public static string GetRoomTypeIdByName(string iRoomTypeName)
    {
        string roomTypeId = string.Empty;
        string query = string.Format("SELECT TOP(1) id FROM Agency_Admin.dbo.SUPPLIERS_HOTEL_ADDS WHERE name_1252 = '{0}'", iRoomTypeName);

        try
        {
            roomTypeId = DAL_SQL.RunSql(query);
            if (string.IsNullOrEmpty(roomTypeId))
            {
                query = string.Format("SELECT TOP(1) id FROM Agency_Admin.dbo.SUPPLIERS_HOTEL_ADDS WHERE name_1251 = '{0}' OR name_1255 = '{0}' OR name = '{0}' OR foreignName = '{0}'", iRoomTypeName);
            }
        }
        catch (Exception ex)
        {
            roomTypeId = string.Empty;
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return roomTypeId;
    }
	
	public static string AddRoomTypeByAlpCode(string iAlpRoomTypeName)
    {
        return AddRoomTypeByName(iAlpRoomTypeName);
    }

    public static string AddRoomTypeByName(string iRoomTypeName)
    {
        string roomTypeName = iRoomTypeName;

        if (roomTypeName.Length > 150)
        {
            roomTypeName = roomTypeName.Substring(0, 150);
        }

        string roomTypeId = string.Empty;
        string name = roomTypeName;
        string description = roomTypeName;
        string status = "1";
        string foreignName = roomTypeName;
        string name1251 = roomTypeName;
        string name1252 = roomTypeName;
        string name1255 = roomTypeName;
        string query = string.Format(@"INSERT INTO Agency_Admin.dbo.SUPPLIERS_HOTEL_ADDS (id,           name,           description,
                                                                                          status,       foreignName,    name_1251,
                                                                                          name_1252,    name_1255)
                                       OUTPUT inserted.id
                                       VALUES  ({0},  '{1}', '{2}',
                                               '{3}', '{4}', '{5}',
                                               '{6}', '{7}')",
                                               /*{0}*/"ISNULL((SELECT max(id) + 1 FROM Agency_Admin.dbo.SUPPLIERS_HOTEL_ADDS), 1)",
                                               /*{1}*/name,
                                               /*{2}*/description,
                                               /*{3}*/status,
                                               /*{4}*/foreignName,
                                               /*{5}*/name1251,
                                               /*{6}*/name1252,
                                               /*{7}*/name1255);

        try
        {
            Logger.Log(query);
            roomTypeId = DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }

        return roomTypeId;
    }
	
	public static void AddSuppliersToHotelAdds(string iRoomTypeId, string iSupplierId)
    {
        string amountNetto = "0.00";
        string status = "1";
        string query = string.Format(@"INSERT INTO Agency_Admin.dbo.SUPPLIERS_TO_HOTEL_ADDS(id, supplier_id, add_id,
                                                                                            amount_netto, status)
                                        VALUES( {0},  '{1}', '{2}',
                                               '{3}', '{4}')",
                                               /*{0}*/"ISNULL((SELECT max(id) + 1 FROM  Agency_Admin.dbo.SUPPLIERS_TO_HOTEL_ADDS), 1)",
                                               /*{1}*/iSupplierId,
                                               /*{2}*/iRoomTypeId,
                                               /*{3}*/amountNetto,
                                               /*{4}*/status);

        try
        {
            DAL_SQL.RunSql(query);
        }
        catch (Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
            throw ex;
        }
    }
	
	public static string GetSupplierIncomeType(string iSupplierId)
	{
		string retVal = string.Empty;
		
		retVal = DAL_SQL.RunSql("SELECT income_type_id FROM SUPPLIER_DETAILS WHERE supplier_id = " + iSupplierId);
		
		return retVal;
	}
	
	public static string GetSupplierCommission(string iSupplierId)
	{
		string retVal = string.Empty;
		
		retVal = DAL_SQL.RunSql("SELECT commission_percentage FROM SUPPLIER_DETAILS WHERE supplier_id = " + iSupplierId);
		if (string.IsNullOrEmpty(retVal))
		{
			retVal = "0";
		}
		
		return retVal;
	}
	
	public static void InsertNewOrderIntoPreOrderOphirbitTable(FormParameters iSession, string iClerkId)
    {
        string query = string.Empty;
        string insertedId;

        query = string.Format("INSERT INTO dbo.PRE_ORDER_OPHIR_BIT_INSURANCE" +
                            "(created_on,       clerk_id,               aid," +
                            "personal_id,       from_date,              to_date," +
                            "destination_id,    destination_name,       first_name," +
                            "last_name,         phone_number,           email," +
                            "gender,            date_of_birth,          my_unique, " +
                            "order_status {15}) " +
                            "OUTPUT Inserted.Id " +
                            "VALUES " +
                            "('{0}', {1}, N'{2}', " +
                            "N'{3}', '{4}', '{5}'," +
                            "{6}, N'{7}', N'{8}'," +
                            "N'{9}','{10}', N'{11}'," +
                            "'{12}', N'{13}', '{14}', " +
                            "0 {16})",
                            /*{0}*/ DateTime.Now.ToString(), /*{1}*/ iClerkId, /*{2}*/ iSession.Aid,
                            /*{3}*/ iSession.Id, /*{4}*/ iSession.From.ToString("dd-MMM-yy"), /*{5}*/ iSession.To.ToString("dd-MMM-yy"),
                            /*{6}*/ iSession.DestinationId, /*{7}*/ iSession.DestinationName, /*{8}*/ iSession.FirstName,
                            /*{9}*/ iSession.LastName, /*{10}*/ iSession.PhoneNumber, /*{11}*/ iSession.Email,
                            /*{12}*/ iSession.Gender, /*{13}*/ iSession.DOB.ToString("dd-MMM-yy"), /*{14}*/ iSession.MyUnique,
                            /*{15}*/iSession.DocketId == null ? "" : ",docket_id", /*{16}*/iSession.DocketId == null ? "" : "," + iSession.DocketId);

        try
        {
            // Insert data into PRE_ORDER_OPHIR_BIT_INSURANCE table
            insertedId = DAL_SQL.RunSql(query);

            if (iSession.Travellers.Count > 0)
            {
                // Insert travellers
                query = "INSERT INTO dbo.PRE_ORDER_OPHIR_BIT_INSURANCE_TRAVELLERS" +
                        "(pre_order_id, traveller_id, first_name," +
                        "last_name, gender, date_of_birth) VALUES";

                StringBuilder stringBuilder = new StringBuilder(query);

                for (int i = 0; i < iSession.Travellers.Count; i++)
                {
                    FormParameters.Traveller traveller = iSession.Travellers[i];
                    stringBuilder.Append(string.Format("({0}, '{1}', '{2}', " +
                                                        "'{3}', '{4}', '{5}')",
                                        insertedId, traveller.Id,
                                        traveller.FirstName, traveller.LastName,
                                        traveller.Gender, traveller.DOB.ToString("dd-MMM-yy")));

                    if (i + 1 < iSession.Travellers.Count)
                    {
                        stringBuilder.Append(',');
                    }
                }

                query = stringBuilder.ToString();
                DAL_SQL.RunSql(query);
            }
        }
        catch (Exception e)
        {
            Logger.Log(string.Format("Exeption Message: {0} SQL Query: {1}", e.Message, query));
        }
    }
	
	public static void UpdatePreOrderOphirbitInsuraceTable(FormParameters iSession)
    {
        string query = string.Empty;
        try
        {
            query = string.Format("INSERT INTO dbo.PRE_ORDER_OPHIR_BIT_INSURANCE" +
                                "(aid, personal_id, from_date, to_date, destination," +
                                "first_name, last_name, phone_number, email," +
                                "date_of_birth, my_unique)" +
                                "OUTPUT Inserted.Id " +
                                "VALUES" +
                                "('{0}', '{1}', '{2}', '{3}'," +
                                 "N'{4}', N'{5}', '{6}', '{7}'," +
                                 "'{8}', '{9}', '{10}')",
                iSession.Aid, iSession.Id, iSession.From, iSession.To,
                iSession.DestinationId, iSession.FirstName, iSession.LastName,
                iSession.PhoneNumber, iSession.Email, iSession.DOB.ToString("dd-MMM-yy"), iSession.MyUnique);

            // Insert data into PRE_ORDER_OPHIR_BIT_INSURANCE table
            string insertedId = DAL_SQL.RunSql(query);

            // Insert travellers
            query = "INSERT INTO dbo.PRE_ORDER_OPHIR_BIT_INSURANCE_TRAVELLERS" +
                    "(pre_order_id, traveller_id, first_name," +
                    "last_name, gender, date_of_birth) VALUES";

            StringBuilder stringBuilder = new StringBuilder(query);

            for (int i = 0; i < iSession.Travellers.Count; i++)
            {
                FormParameters.Traveller traveller = iSession.Travellers[i];
                stringBuilder.Append(string.Format("({0}, '{1}', '{2}', " +
                                                    "'{3}', '{4}', '{5}')",
                                    insertedId, traveller.Id,
                                    traveller.FirstName, traveller.LastName,
                                    traveller.Gender, traveller.DOB.ToString("dd-MMM-yy")));

                if (i + 1 < iSession.Travellers.Count)
                {
                    stringBuilder.Append(',');
                }
            }

            query = stringBuilder.ToString();
            DAL_SQL.RunSql(query);
        }
        catch (Exception e)
        {
            Logger.Log(string.Format("Exeption Message: {0} SQL Query: {1}", e.Message, query));
        }
    }

	public static void UpdateOrderStatusInPreOrderOphirbirTable(string iMyUnique)
    {
        string query = string.Format("UPDATE dbo.PRE_ORDER_OPHIR_BIT_INSURANCE SET order_status = 1 WHERE my_unique = '{0}'" , iMyUnique);
        
		try
        {
            DAL_SQL.RunSql(query);
        } 
		catch (Exception e)
        {
            Logger.Log(string.Format("Exeption Message: {0} SQL Query: {1}", e.Message, query));
        }
    }
	
    public static DataSet GetClerkInformationFromName(string iClerkLoginName)
    {
        string query = string.Format("SELECT * FROM dbo.CLERKS WHERE login_name='{0}'", iClerkLoginName);

        return DAL_SQL.RunSqlDataSet(query);
    }

    public static bool IsDocketIdExists(string iDocketId)
    {
        string query = "SELECT id FROM dbo.DOCKETS WHERE id = " + iDocketId;
        string res = string.Empty;
		
        try
        {
            res = DAL_SQL.RunSql(query);
        } 
		catch(Exception e)
        {
            Logger.Log(string.Format("Exeption Message: {0} SQL Query: {1}", e.Message, query));
        }
		
        return res.Length > 0;
    }

    public static DataSet GetSupplierDataSetFromId(string iSupplierId)
    {
        string query = "SELECT * FROM dbo.SUPPLIER_DETAILS WHERE supplier_id = "+ iSupplierId;

        return DAL_SQL.RunSqlDataSet(query);
    }

    public static DataSet GetTravellersDataSetFromDocketId(string iDocketId)
    {
        DataSet travellersDataSet = null;
        string query = "SELECT T.id, id_no, first_name, last_name, gender_id, birth_date " +
                        "FROM dbo.TRAVELLERS T INNER JOIN dbo.DOCKETS_to_TRAVELLERS DTT ON " +
                        "T.id = DTT.traveller_id " +
                        "WHERE DTT.docket_id = " + iDocketId;
        try
        {
            return DAL_SQL.RunSqlDataSet(query);
        }
        catch (Exception e)
        {
            Logger.Log("Exception. Message = " + e.Message + ", query = " + query);
        }

        return travellersDataSet;
    }

    public static string GetTravellerEmailsOrPhonesDataSetFromTravellerId(string iTravellerId, bool mail)
    {
        string result = string.Empty;
        string tableName = mail ? "dbo.TRAVELLER_MAILS" : "dbo.PHONES_to_TRAVELLERS";
        string feild = mail ? "eMail" : "number";

        string query = string.Format("SELECT {0} FROM {1} WHERE traveller_id = {2}", feild, tableName, iTravellerId);
    
        try
        {
            result = DAL_SQL.RunSql(query);            
        }
        catch (Exception e)
        {

        }
        return result;
    }

    public static DataSet GetSessionFromDBFromMyUnique(string iMyUnique)
    {
        string query = string.Empty;
        DataSet dataSet = null;
        try
        {
            query = string.Format(@"SELECT * FROM dbo.PRE_ORDER_OPHIR_BIT_INSURANCE_TRAVELLERS
                                   INNER JOIN dbo.PRE_ORDER_OPHIR_BIT_INSURANCE ON
                                   pre_order_id = dbo.PRE_ORDER_OPHIR_BIT_INSURANCE.id 
                                   WHERE my_unique = '{0}' ", iMyUnique);

            dataSet = DAL_SQL.RunSqlDataSet(query);

        } catch (Exception) { }

        return dataSet;

    }
	
	public static DataSet GetPreOrderOphirbitInsuraceTableByClerkId(string iClerkId)
    {
        string query = string.Empty;
        string departmentId = string.Empty;        
        string branchId = string.Empty;            
        bool isAllDockets = false;                 
        bool isAllBranch = false;                  
        bool isAllDepartment = false;              

        DataSet permissionsDataSet = DAL_SQL.RunSqlDataSet(" SELECT TOP 1 C.department_id, D.branch_id, " + 
														   " 		C.all_department, C.all_departments, C.all_branch " + 
														   " FROM CLERKS C INNER JOIN DEPARTMENTS D ON C.department_id = D.id " + 
														   " WHERE C.status = 1 AND C.id = " + iClerkId);
        if (Utils.IsDataSetRowsNotEmpty(permissionsDataSet))
        {
            DataRow row = permissionsDataSet.Tables[0].Rows[0];
            isAllDockets = row["all_departments"].ToString().Equals("1");
            isAllDepartment = row["all_department"].ToString().Equals("1");
            isAllBranch = row["all_branch"].ToString().Equals("1");
            departmentId = row["department_id"].ToString();
            branchId = row["branch_id"].ToString(); 
        }

        DataSet dataSet = null;
        if (isAllBranch)
        {
            query = "SELECT * FROM dbo.PRE_ORDER_OPHIR_BIT_INSURANCE P INNER JOIN dbo.CLERKS C ON C.id = P.clerk_id INNER JOIN DEPARTMENTS D ON D.id = C.department_id WHERE C.department_id = " + departmentId + " AND D.branch_id = " + branchId;
        } else if(isAllDepartment)
        {
            query = "SELECT * FROM dbo.PRE_ORDER_OPHIR_BIT_INSURANCE P INNER JOIN dbo.CLERKS C ON C.id = P.clerk_id WHERE C.department_id = " + departmentId;

        } else
        {
            query = "SELECT * FROM dbo.PRE_ORDER_OPHIR_BIT_INSURANCE P WHERE clerk_id = " + iClerkId;
        }
        
		try
        {
			Logger.Log("query = " + query);
            dataSet = DAL_SQL.RunSqlDataSet(query);
        }
		catch (Exception e)
        {
            Logger.Log(string.Format("Exeption Message: {0} SQL Query: {1}", e.Message, query));
        }
        return dataSet;
    }

    public static DataSet GetInsuranceDataSetFromDBFromMyUnique(string iMyUnique)
    {
        string query = string.Empty;
        DataSet dataSet = null;
        try
        {
            query = string.Format("SELECT  aid, personal_id, T.traveller_id as t_personal_id, from_date," +
                                  "to_date, destination_id, destination_name, " +
                                  "email, phone_number, my_unique," +
                                  "I.first_name," +
                                  "T.first_name as t_first_name," +
                                  "I.last_name," +
                                  "T.last_name as t_last_name," +
                                  "I.gender," +
                                  "T.gender as t_gender," +
                                  "I.date_of_birth," +
                                  "T.date_of_birth as t_date_of_birth " +
                                  "FROM dbo.PRE_ORDER_OPHIR_BIT_INSURANCE_TRAVELLERS T RIGHT JOIN dbo.PRE_ORDER_OPHIR_BIT_INSURANCE I ON pre_order_id = I.id " +
                                                                      "WHERE my_unique = '{0}' ", iMyUnique);

            dataSet = DAL_SQL.RunSqlDataSet(query);

        }
        catch (Exception) { }

        return dataSet;

    }

    public static void UpdateInsuranceDataSetInDBFromMyUniqueWithStatus(string iMyUnique, string iStatus)
    {
        string query = string.Empty;
        try
        {
            query = string.Format("UPDATE dbo.PRE_ORDER_OPHIR_BIT_INSURANCE " +
                                   "SET order_status = {0} " +
                                   "WHERE my_unique = '{1}' ", iStatus, iMyUnique);

            DAL_SQL.RunSqlDataSet(query);
        }
        catch (Exception e) {
            Logger.Log(string.Format("Exception in DAL_SQL_HELPER\\UpdateInsuranceDataSetInDBFromMyUniqueWithStatus.\n" +
                                     "Exception Message: {0}\nQuery: {1}",
                                     e.Message, query));
        }
    }

    public static DataSet GetInsuranceDataSetFromDBFromDocketId(string iDocketId/*, bool iOphirBitTable*/)
    {
        string query = string.Empty;
        DataSet dataSet = null;
        try
        {
            query = 
                //iOphirBitTable ? string.Format(@"SELECT *, traveller_id as id_no, gender as gender_id, date_of_birth as birth_date FROM dbo.PRE_ORDER_OPHIR_BIT_INSURANCE_TRAVELLERS
                //                   INNER JOIN dbo.PRE_ORDER_OPHIR_BIT_INSURANCE ON
                //                   pre_order_id = dbo.PRE_ORDER_OPHIR_BIT_INSURANCE.id 
                //                   WHERE docket_id = '{0}' ", iDocketId)
                //                   :
                                   string.Format("SELECT * FROM dbo.TRAVELLERS T INNER JOIN DOCKETS_to_TRAVELLERS DTT ON DTT.traveller_id = T.id WHERE docket_id = {0}", iDocketId);

            dataSet = DAL_SQL.RunSqlDataSet(query);
        }
        catch (Exception e)
        {
            Logger.Log(string.Format("Exception in DAL_SQL_HELPER\\GetInsuranceDataSetFromDBFromDocketId.\n" +
                             "Exception Message: {0}\nQuery: {1}",
                             e.Message, query));
        }

        return dataSet;
    }	
    
    public static DataSet GetInsuranceTravellersDataSetFromDocketId(string iDocketId)
    {
        DataSet travellersDataSet = null;
        string query = "SELECT T.id, id_no, first_name, last_name, gender_id, birth_date " +
                        "FROM dbo.TRAVELLERS T INNER JOIN dbo.DOCKETS_to_TRAVELLERS DTT ON " +
                        "T.id = DTT.traveller_id " +
                        "WHERE DTT.docket_id = " + iDocketId;
        try
        {
            return DAL_SQL.RunSqlDataSet(query);
        }
        catch (Exception e)
        {
            Logger.Log("Exception. Message = " + e.Message + ", query = " + query);
        }

        return travellersDataSet;
    }
	
	public static void UpdateFlightSale(string iRowId, bool iStatus)
    {
        DAL_SQL.RunSql(" UPDATE P_FLIGHTS_SALES " +
                                   " SET status = '" + iStatus + "' " +
                                   " WHERE id = " + iRowId);
    }

    public static void AddFlightSale(string iDeparturePortId, string iArrivalPortId, DateTime iCheckIn, 
                                     DateTime iCheckOut, decimal iCommission, string iCompositionId,
                                     bool iStatus, decimal iDiscount, string iRemarks, 
                                     string iRemarksSite, bool iIsOverride, bool iIsPublishOnSite, 
                                     string iSiteOrder, string iDealId, ref string ioMessage)
    {
        Logger.Log(iRemarks);
        //To check if only changing the commission.
        string recordId = DAL_SQL.RunSql(" SELECT id " + 
                                         " FROM P_FLIGHTS_SALES " + 
                                         " WHERE departure_port_id = " + iDeparturePortId +
                                         "       AND arrival_port_id = " + iArrivalPortId +
                                         "       AND cast(check_out as smalldatetime) = cast('" + iCheckOut.ToString("dd-MMM-yy") + "' as smalldatetime) " +
                                         "       AND cast(check_in as smalldatetime) = cast('" + iCheckIn.ToString("dd-MMM-yy") + "' as smalldatetime) " + 
                                         "       AND status = 'true'");

        if (string.IsNullOrEmpty(recordId))
        {
            DAL_SQL.RunSql(" INSERT INTO P_FLIGHTS_SALES (departure_port_id, arrival_port_id, check_in, " + 
                                                        " check_out, commission, composition_id, " + 
                                                        " status,  discount, remarks, " + 
                                                        " remarks_site, is_publish_on_site, site_order, " +
                                                        " deal_id) " +
                           " VAlUES(" + iDeparturePortId + ", " + iArrivalPortId + ", '" + iCheckIn.ToString("dd-MMM-yy") + "'," +
                                    "'" + iCheckOut.ToString("dd-MMM-yy") + "'," + iCommission + "," + iCompositionId + "," +  
                                        "'" + iStatus + "', " + iDiscount + ", N'" + iRemarks + "'," + 
                                        "N'" + iRemarksSite + "'," + "'" + iIsPublishOnSite + "'," + iSiteOrder + 
                                        ",'" + iDealId + "')");
        }
        else
        {
             ////To check if same row asked.
            //recordId = DAL_SQL.RunSql(" SELECT id " + 
            //                          " FROM P_FLIGHTS_SALES " + 
            //                          " WHERE departure_port_id = " + iDeparturePortId +
            //                          "       AND arrival_port_id = " + iArrivalPortId +
            //                          "       AND traveller_discount = " + iDiscount +
            //                          "       AND commission = " + iCommission +
            //                          "       AND cast(check_out as smalldatetime) = cast('" + iCheckOut.ToString("dd-MMM-yy") + "' as smalldatetime) " +
            //                          "       AND cast(check_in as smalldatetime) = cast('" + iCheckIn.ToString("dd-MMM-yy") + "' as smalldatetime)");
            //
            //if (!string.IsNullOrEmpty(recordId))
            //{
            //    DAL_SQL.RunSql(" UPDATE P_FLIGHTS_SALES " +
            //                       " SET status = '" + "true" + "' " +
            //                       " WHERE departure_port_id = " + iDeparturePortId +
            //                       " AND arrival_port_id = " + iArrivalPortId +
            //                       " AND cast(check_in as smalldatetime) = cast('" + iCheckIn.ToString("dd-MMM-yy") + "' as smalldatetime)" +
            //                       " AND cast(check_out as smalldatetime) = cast('" + iCheckOut.ToString("dd-MMM-yy") + "' as smalldatetime)");
            //}
            //else
            //{
                //if (iIsOverride)
                //{
                //    DAL_SQL.RunSql(" UPDATE P_FLIGHTS_SALES " +
                //                   " SET commission = " + iCommission + ", " +
                //                   "     traveller_discount = " + iDiscount + ", " +
                //                   "     remarks = N'" + iRemarks + "', " +
                //                   "     remarks_site = N'" + iRemarksSite + "', " +
                //                   "     is_publish_on_site = '" + iIsPublishOnSite + "' " +
                //                   "     site_order = '" + iSiteOrder + "' " +
                //                   "     status = '" + iStatus + "' " +
                //                   " WHERE departure_port_id = " + iDeparturePortId +
                //                   " AND arrival_port_id = " + iArrivalPortId +
                //                   " AND cast(check_in as smalldatetime) = cast('" + iCheckIn.ToString("dd-MMM-yy") + "' as smalldatetime)" +
                //                   " AND cast(check_out as smalldatetime) = cast('" + iCheckOut.ToString("dd-MMM-yy") + "' as smalldatetime)");
                //    ioMessage = "העמלה השתנתה במקום מה שהיה";
                //}
                //else
                //{
                //    ioMessage = "קיימת עמלה לתאריכים שבחרת במלון זה, אם ברצונך לדרוס את מה שקיים אנא סמן בוי את תיבת הסימון";
                //}
            ioMessage = "קיים מבצע זהה (" + recordId + ")";
        }
    }

    public static DataSet GetAllFlightsSales()
    {
        DataSet ds = DAL_SQL.RunSqlDataSet("SELECT * FROM P_FLIGHTS_SALES WHERE status = 1 order by id desc");

        return ds;
    }
	
	
	public static DataSet GetOfranIataFromDB(string iCountryId)
    {
        string query = "SELECT * FROM Agency_Admin.dbo.OFRAN_COUNTRY_IATAS WHERE ofran_country_id = " + iCountryId;

        return DAL_SQL.RunSqlDataSet(query);
    }

    public static DataSet GetOfranCountriesListFromDB()
    {
        string sqlTask = "SELECT * FROM Agency_Admin.dbo.OFRAN_COUNTRIES";

        return DAL_SQL.RunSqlDataSet(sqlTask);
    }
	
	public static DataSet GetCarTypeGroupsDataSetFromDB(string iCountryId)
    {
        string query = "SELECT * FROM Agency_Admin.dbo.OFRAN_CAR_TYPES_GROUPS WHERE country_id = " + iCountryId;

        return DAL_SQL.RunSqlDataSet(query);
    }

    public static string GetOfranCountryNameFromId(string iCountryId)
    {
        string query = "SELECT country_name FROM Agency_Admin.dbo.OFRAN_COUNTRIES WHERE country_id = " + iCountryId;

        return DAL_SQL.RunSql(query);
    }

    public static string GetOfranIataNameFromId(string iIataId)
    {
        string query = "SELECT description FROM Agency_Admin.dbo.OFRAN_COUNTRY_IATAS WHERE iata_code_id = " + iIataId;

        return DAL_SQL.RunSql(query);
    }

    public static string GetCountryIdByOfranCountryId(string iOfranCountryId)
    {
        string query = string.Empty;
        string countryId = string.Empty;

        try
        {
            query = "SELECT C.id FROM Agency_Admin.dbo.COUNTRIES C INNER JOIN Agency_Admin.dbo.OFRAN_COUNTRIES OC ON country_name = name WHERE country_id = '" + iOfranCountryId + "'";
            countryId = DAL_SQL.RunSql(query);
            if (string.IsNullOrEmpty(countryId))
            {
                query = string.Format(@"INSERT INTO dbo.COUNTRIES (id, name, nationality, code) OUTPUT Inserted.id VALUES 
                                        ((SELECT MAX(id) FROM dbo.COUNTRIES) + 1,
                                        (SELECT country_name FROM dbo.OFRAN_COUNTRIES WHERE country_id = '{0}'),
                                        (SELECT country_name FROM dbo.OFRAN_COUNTRIES WHERE country_id = '{0}'), 
                                        (SELECT country_symbol FROM dbo.OFRAN_COUNTRIES WHERE country_id = '{0}'));",
                                iOfranCountryId);
                countryId = DAL_SQL.RunSql(query);
            }

        }
        catch (Exception e)
        {
            Logger.Log("Utils.GetCountryIdByOfranCountryId.\nQuery:" + query + "\nExecption Message: " + e.Message);
        }
        return countryId;
    }

    public static DataSet GetCarRentalForClerkId(string iClerkId)
    {
        string query = string.Empty;
        string departmentId = string.Empty;
        string branchId = string.Empty;
        bool isAllDockets = false;
        bool isAllBranch = false;
        bool isAllDepartment = false;

        DataSet permissionsDataSet = DAL_SQL.RunSqlDataSet(" SELECT TOP 1 C.department_id, D.branch_id, " +
                                                           " 		C.all_department, C.all_departments, C.all_branch " +
                                                           " FROM CLERKS C INNER JOIN DEPARTMENTS D ON C.department_id = D.id " +
                                                           " WHERE C.status = 1 AND C.id = " + iClerkId);
        if (Utils.IsDataSetRowsNotEmpty(permissionsDataSet))
        {
            DataRow row = permissionsDataSet.Tables[0].Rows[0];
            isAllDockets = row["all_departments"].ToString().Equals("1");
            isAllDepartment = row["all_department"].ToString().Equals("1");
            isAllBranch = row["all_branch"].ToString().Equals("1");
            departmentId = row["department_id"].ToString();
            branchId = row["branch_id"].ToString();
        }

        DataSet dataSet = null;
        if (isAllBranch)
        {
            query = "SELECT * FROM dbo.PRE_ORDER_OFRAN_CAR_RENTAL P INNER JOIN dbo.CLERKS C ON C.id = P.clerk_id INNER JOIN DEPARTMENTS D ON D.id = C.department_id WHERE C.department_id = " + departmentId + " AND D.branch_id = " + branchId;
        }
        else if (isAllDepartment)
        {
            query = "SELECT * FROM dbo.PRE_ORDER_OFRAN_CAR_RENTAL P INNER JOIN INNER JOIN dbo.CLERKS C ON C.id = P.clerk_id WHERE C.department_id = " + departmentId;

        }
        else
        {
            query = "SELECT * FROM dbo.PRE_ORDER_OFRAN_CAR_RENTAL P INNER JOIN WHERE clerk_id = " + iClerkId;
        }

        try
        {
            Logger.Log("query = " + query);
            dataSet = DAL_SQL.RunSqlDataSet(query);
        }
        catch (Exception e)
        {
            Logger.Log(string.Format("Exeption Message: {0} SQL Query: {1}", e.Message, query));
        }
        return dataSet;
    }
	
	public static void UpsertCountries(OfranGetCountriesListResponse iCountriesList)
    {
        foreach (var country in iCountriesList.Countries.Countries)
        {
            string sqlQueryCountryId = "SELECT country_id FROM Agency_Admin.dbo.OFRAN_COUNTRIES WHERE country_id = " + country.CountryId;
            // Creating the sql task accroding to the response from the sql query about country_id. If the response string is empty then
            // The length is zero and the task should be INSERT. otherwise the table will get updated. 
            string task = DAL_SQL.RunSql(sqlQueryCountryId).Length == 0 ?
                 "INSERT INTO Agency_Admin.dbo.OFRAN_COUNTRIES (country_id, country_symbol, country_name)" +
                 "                                      VALUES (" + country.CountryId + ", N'" + country.CountrySymbol + "', N'" + country.CountryName + "')" :
                 "UPDATE Agency_Admin.dbo.OFRAN_COUNTRIES SET country_symbol = N'" + country.CountrySymbol +
                                                             "', country_name = N'" + country.CountryName + "' " +
                                                             "WHERE country_id = " + country.CountryId;
            DAL_SQL.RunSql(task);
        }
    }

    public static void UpsertIatas(OfranGetIatasResponse iOfranGetIatasResponse)
    {
		string task;
		string sqlQueryIataCodeId;
		string preferred;
		
        foreach (var iata in iOfranGetIatasResponse.IatacodesElem.Iatacode)
        {
            //Make the first letter of "preferred" to Uppercase to support the SQL type. 
            preferred = iata.Preferred[0].ToString().ToUpper() + iata.Preferred.Substring(1);
			sqlQueryIataCodeId = "SELECT iata_code_id FROM Agency_Admin.dbo.OFRAN_COUNTRY_IATAS WHERE iata_code_id = " + iata.IataCodeId;
            task = DAL_SQL.RunSql(sqlQueryIataCodeId).Length == 0 ?
                "INSERT INTO Agency_Admin.dbo.OFRAN_COUNTRY_IATAS (iata_code_id, iata_name, description, ofran_country_id, preferred)" +
                "VALUES (" + iata.IataCodeId + ", N'" + iata.IataName.Replace("'", "''") + "', N'" + iata.Description.Replace("'", "''") + "', " + iata.CountryId + ", '" + preferred + "')" :
                "UPDATE Agency_Admin.dbo.OFRAN_COUNTRY_IATAS SET iata_name = N'" + iata.IataName.Replace("'", "''") + "'" +
                                                                ", description = N'" + iata.Description.Replace("'", "''") + "'" +
                                                                ", ofran_country_id = " + iata.CountryId +
                                                                ", preferred = '" + preferred + "'" +
                                                                " WHERE iata_code_id = " + iata.IataCodeId;
			try
			{
				DAL_SQL.RunSql(task);
			}
			catch (Exception e)
			{
				Logger.Log(task);
			}
        }
    }

    public static void UpsertTypes(OfranCarGroupbyCountryListResponse iOfranTypeListResponse)
    {
        bool insert = false;
        StringBuilder insertQueryCarTypes = new StringBuilder("INSERT INTO Agency_Admin.dbo.OFRAN_CAR_TYPES (country_id, " +
                                                                                                            "country_code) " +
                                                                                                            "VALUES ");
        StringBuilder insertQueryCarGroupsForeachCarType = new StringBuilder("INSERT INTO Agency_Admin.dbo.OFRAN_CAR_TYPES_GROUPS (country_id," +
                                                                                                                                   "car_group_id, " +
                                                                                                                                   "car_group_name, " +
                                                                                                                                   "display_order) VALUES ");
        foreach (var carType in iOfranTypeListResponse.CountryCarsList.CountryCars)
        {
            // Check if this carType needs to be inserted or updated
            string carTypeExistsQuery = "SELECT country_id FROM Agency_Admin.dbo.OFRAN_CAR_TYPES WHERE country_id = " + carType.CountryId;

            if (DAL_SQL.RunSql(carTypeExistsQuery).Length > 0)
            {
                // CarType contains only id and code -> shouldn't get updated
                foreach (var carGroup in carType.OfranCarGroupList.OfranCarGroup)
                {
                    string updateCarGroup = "UPDATE Agency_Admin.dbo.OFRAN_CAR_TYPES_GROUPS SET " +
                        "car_group_name = N'" + carGroup.OfranCarGroupName + "', " +
                        "display_order = N'" + carGroup.DisplayOrder + "'" +
                        "WHERE " +
                        "country_id = " + carType.CountryId +
                        "AND car_group_id = " + carGroup.OfranCarGroupId;
                    DAL_SQL.RunSql(updateCarGroup);
                }
            }
            else
            {
                insert = true;

                // Inserting the car group
                foreach (var carGroup in carType.OfranCarGroupList.OfranCarGroup)
                {
                    insertQueryCarGroupsForeachCarType.Append("(" + carType.CountryId
                                                                  + ", " + carGroup.OfranCarGroupId
                                                                  + ", N'" + carGroup.OfranCarGroupName
                                                                  + "', N'" + carGroup.DisplayOrder + "'), ");
                }

                // Inserting the car type
                insertQueryCarTypes.Append("(" + carType.CountryId + ", N'" + carType.CountryCode + "'), ");
            }
        }

        if (insert)
        {
            // Delete the comma and backspace from the last set of values.
            if (insertQueryCarGroupsForeachCarType[insertQueryCarGroupsForeachCarType.Length - 2] == ',')
            {
                insertQueryCarGroupsForeachCarType.Remove(insertQueryCarGroupsForeachCarType.Length - 2, 2);
            }
            if (insertQueryCarTypes[insertQueryCarTypes.Length - 2] == ',')
            {
                insertQueryCarTypes.Remove(insertQueryCarTypes.Length - 2, 2);
            }

            DAL_SQL.RunSql(insertQueryCarGroupsForeachCarType.ToString());
            DAL_SQL.RunSql(insertQueryCarTypes.ToString());
        }
    }


    public static string GetHotelRoomTypeIdByName(string iRoomTypeName, eLanguage iLanguage)
    {
        string roomTypeId = string.Empty;
        string query = string.Format("SELECT TOP(1) id FROM Agency_Admin.dbo.SUPPLIERS_HOTEL_ADDS WHERE name = '{1}' OR foreignName = '{1}' OR name_{0} = '{1}'", (int)iLanguage, iRoomTypeName);       
        try
        {
            roomTypeId = DAL_SQL.RunSql(query);
        }
        catch (Exception e)
        {
            Logger.Log("Exception. e.Message: " + e.Message + " StackTrace: " + e.StackTrace);
        }

        if(string.IsNullOrEmpty(roomTypeId))
        {
            roomTypeId = AddRoomTypeByName(iRoomTypeName);
        }

        return roomTypeId;
    }
	
	public static DataSet GetAllAmadeusAutoPNRUsers()
	{
		DataSet ds = null;
		string query = "SELECT * FROM Agency_Admin.dbo.AMADEUS_AUTO_QUEUE_DETAILS WHERE status = 1";
		ds = DAL_SQL.ExecuteDataset(ConfigurationManager.AppSettings["AdminDBConnStr"], CommandType.Text, query);
        
		return ds;
	}
	
	public static void SaveDocketIdInAmadeusLog(string iRunId, string iDocketId, string iPnr, string iIsRetrieveSuccess, 
												string iIsRemoveSuccess, string iRemarks)
	{
		
		string query = string.Format(
		@"INSERT INTO AMADEUS_AUTO_QUEUE_LOG (run_id, docket_id, pnr, 
											  is_succeeded_to_retrieve, is_succeeded_to_remove, remarks) 
									  VALUES (@RunId, @DocketId, @Pnr,
											  @IsRetrieveSuccess, @IsRemoveSuccess, @Remarks)");
		
		//Logger.Log("SaveDocketIdInAmadeusLog iDocketId = " + iDocketId);
		//Logger.Log("SaveDocketIdInAmadeusLog iPnr = " + iPnr);
		//Logger.Log("SaveDocketIdInAmadeusLog iRemarks = " + iRemarks);
		//Logger.Log("SaveDocketIdInAmadeusLog query = " + query);
		DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.Text, query,
			SqlDalParam.formatParam("@RunId", SqlDbType.Int, iRunId),
			SqlDalParam.formatParam("@DocketId", SqlDbType.NVarChar, iDocketId),
			SqlDalParam.formatParam("@Pnr", SqlDbType.NVarChar, iPnr),
			SqlDalParam.formatParam("@IsRetrieveSuccess", SqlDbType.Bit, iIsRetrieveSuccess),
			SqlDalParam.formatParam("@IsRemoveSuccess", SqlDbType.Bit, iIsRemoveSuccess),
			SqlDalParam.formatParam("@Remarks", SqlDbType.NVarChar, iRemarks)
		);
	}
}
 