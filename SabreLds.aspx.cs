using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SabreLds : System.Web.UI.Page
{

    SabreLdsConnector mSabreLtdConnector = new SabreLdsConnector();

    protected void Page_Load(object sender, EventArgs e)
    {
        string x = "12".Substring(0, 0);
        if (!IsPostBack)
        {
            fillDdls();
        }
    }

    private void fillDdls()
    {
        string query = string.Empty;
        string language = string.Empty;
        try
        {
            language = Utils.GetLangCodeAsStringFromCookies();
            string allText = language.Equals("1255") ? "הכל" : "All";
            query = "SELECT (name_" + language + ") as name, id FROM Agency_Admin.dbo.DOCKET_TYPES ORDER BY id";
            fillDropDownListsWithQuery(allText, ddlDocketTypes, query);

            query = "SELECT (name) as name, id FROM BUSINESS_CLIENTS WHERE status = 1 and type_id = 2 ORDER BY name";
            fillDropDownListsWithQuery(allText, ddlBussinessClients, query);

            query = "SELECT (description) as name, id FROM DOCKET_DESCRIBES ORDER BY name";
            fillDropDownListsWithQuery(allText, ddlDocketDescribes, query);
        }
        catch (Exception e)
        {
            //Logger.Log(e, query, language);
			Logger.Log("Exception. Message: " + e.Message + ". StackTrace: " + e.StackTrace);

        }
    }
    private void fillDropDownListsWithQuery(string iAllText, DropDownList iDdl, string iQuery)
    {
        iDdl.Items.Clear();
        iDdl.Items.Add(new ListItem(iAllText, "0"));
        DataSet dataSet = DAL_SQL.RunSqlDataSet(iQuery);
        ListItem tempItem = null;

        if (Utils.IsDataSetRowsNotEmpty(dataSet))
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                tempItem = new ListItem(row["name"].ToString(), row["id"].ToString());
                iDdl.Items.Add(tempItem);
            }
        }
    }

    private SabreLdsRetrieveReservationResponse getPnrResponse(string iPnr)
    {
        SabreLdsRetrieveReservationResponse reservationResonse = null;

        try
        {
            SabreLdsRetrieveReservationRequest sabreLtdRequest = new SabreLdsRetrieveReservationRequest
            {
                Body = new SabreLdsRetrieveReservationRequest.BodyClass
                {
                    RetrieveReservation = new SabreLdsRetrieveReservationRequest.RetrieveReservation
                    {
                        ReservationForm = new SabreLdsRetrieveReservationRequest.ReservationForm
                        {
                            ClientVersion = "1.0",
                            IdentificationData = new SabreLdsRetrieveReservationRequest.IdentificationData
                            {
                                Password = "12345a",
                                UserName = "GALT"
                            },
                            Pnr = iPnr
                        },
                    }
                },
                Header = ""
            };

            reservationResonse = mSabreLtdConnector.GetRetreiveReservationResponse(sabreLtdRequest);

        }
        catch (Exception e)
        {
            //Logger.Log(e);
			Logger.Log("Exception. Message: " + e.Message + ". StackTrace: " + e.StackTrace);

        }

        return reservationResonse;
    }
    protected void btnInsertPnr_Click(object sender, EventArgs e)
    {
        Agency2000Ws_Test.Agency2000WS webService = new Agency2000Ws_Test.Agency2000WS();
        Agency2000Ws_Test.CreateAgencyDocketParams docketParams = new Agency2000Ws_Test.CreateAgencyDocketParams();
        var response = getPnrResponse(txtPnr.Text.Trim());
        if (response != null)
        {
            var reservation = response.Body.RetrieveReservationResponse.Return.Reservation;
            if (reservation != null)
            {
                try
                {
                    fillParamsWithAdminInfo(ref docketParams);
                    fillParamsWithTravellers(ref docketParams, ref reservation);
                    fillParamsWithServices(ref docketParams, ref webService, ref reservation);
                    docketParams = (Agency2000Ws_Test.CreateAgencyDocketParams)webService.CreateDocketWithServicesFromParams(docketParams);
                    if(docketParams.DocketId != null && !docketParams.DocketId.Equals("-1"))
                    {
                        lblDocketId.InnerText = docketParams.DocketId;
                    }
                    else
                    {
                        throw new Exception("S|" + Utils.GetTextFromFile("excMess_CrtDocket"));
                    }
                }
                catch (Exception ex)
                {
                    if(ex.Message.StartsWith("S|"))
                    {
                        popUpMessage(ex.Message.Substring(2));
                    }
                    else
                    {
                        //Logger.Log(e);
						Logger.Log("Exception. Message: " + ex.Message + ". StackTrace: " + ex.StackTrace);
                    }
                }
            } else
            {
                Logger.Log("SabreLds: Bad Reservation. Pnr: " + txtPnr.Text);
            }
        } else
        {
            Logger.Log("SabreLds: Bad Response. Pnr: " + txtPnr.Text);
        }
    }

    private void fillParamsWithAdminInfo(ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams)
    {
        iDocketParams.AgencyId = int.Parse(((MasterPage)Master).AgencyId);
        iDocketParams.SystemType = int.Parse(((MasterPage)Master).SystemType);
        iDocketParams.UserName = ((MasterPage)Master).UserName;
        iDocketParams.Password = ((MasterPage)Master).Password;
        iDocketParams.ClerkId = int.Parse(((MasterPage)Master).ClerkId);
        iDocketParams.Language = Agency2000Ws_Test.eLanguage.Hebrew;
    }

    private void fillParamsWithServices(ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams,
                                       ref Agency2000Ws_Test.Agency2000WS iWebService,
                                       ref SabreLdsRetrieveReservationResponse.Reservation iResponse)
    {
        List<Agency2000Ws_Test.Service> services = new List<Agency2000Ws_Test.Service>();
        Agency2000Ws_Test.Flight flight = null;
        Agency2000Ws_Test.HotelService hotelService = null;

        if (iResponse.Flight != null && iResponse.Flight.Count > 0)
        {
            flight = new Agency2000Ws_Test.Flight();
            fillServiceWithSupplierId(ref iWebService, ref iDocketParams, flight, "1", iResponse.Flight[0].Leg.SupplierId, "");
            var flights = iResponse.Flight.Select(f => f.Leg);
            foreach (var flightDetails in flights)
            {
                // All Travellers are in all the flights.
                fillServiceWithFlightRow(ref flight, ref iDocketParams, ref iWebService, flightDetails,
                                        iResponse.Currency, iResponse.SabrePNR, iResponse.Pax.Select(pax => pax.RefId).ToArray());
            }
            services.Add(flight);
        }

        if (iResponse.Hotel != null)
        {
            List<Agency2000Ws_Test.Hotel> hotels = new List<Agency2000Ws_Test.Hotel>();
            int adultCount = 0, childCount = 0, infantCount = 0;
            var rooms = iResponse.Hotel.Room;

            hotelService = new Agency2000Ws_Test.HotelService
            {
                Name = iResponse.Hotel.HotelName
            };
            fillServiceWithSupplierId(ref iWebService, ref iDocketParams, hotelService, "2", iResponse.Hotel.HotelId, iResponse.Hotel.HotelName);

            foreach (var room in rooms)
            {
                var roomCount = Regex.Match(room.RoomSet, "(A([0-9]+))?(C([0-9]+))?(I([0-9]+))?");
                adultCount = string.IsNullOrEmpty(roomCount.Groups[2].Value) ? 0 : int.Parse(roomCount.Groups[2].Value);
                childCount = string.IsNullOrEmpty(roomCount.Groups[4].Value) ? 0 : int.Parse(roomCount.Groups[4].Value);
                infantCount = string.IsNullOrEmpty(roomCount.Groups[6].Value) ? 0 : int.Parse(roomCount.Groups[6].Value);
				Logger.Log("Debug: adultCount: " + adultCount);
				Logger.Log("Debug: childCount: " + childCount);
				Logger.Log("Debug: infantCount: " + infantCount);

                hotels.Add(
                   new Agency2000Ws_Test.Hotel
                   {
                       OrderNumber = iResponse.SabrePNR,
                       Id = hotelService.Id,
                       PaidToSupplierId = hotelService.PaidToSupplierId,
                       ServiceStatusId = "2",
                       CompositionId = Utils.GetCompositionIdByTravellelrsAmount(adultCount, childCount, infantCount),
                       BaseId = Utils.GetHotelBaseIdByCode(iResponse.Hotel.Board),
                       FromDate = Utils.GetDateTimeFromString(iResponse.Hotel.CheckInDate),
                       ToDate = Utils.GetDateTimeFromString(iResponse.Hotel.CheckOutDate),
                       CurrencyId = (Agency2000Ws_Test.eCurrency)Enum.Parse(typeof(Agency2000Ws_Test.eCurrency), iResponse.Currency),                      
                       RoomsAmount = iResponse.Hotel.Room.Count.ToString(),
                       VoucherStatus = "1",
                       IsCreateVoucher = true,
                       ServiceType = "2",
                       TravellersAssociationIds = room.PaxRef.Select(pax => pax.RefId).ToArray(),
                       RoomTypeId = iWebService.GetHotelRoomTypeIdByName(room.RoomType, Agency2000Ws_Test.eLanguage.English),
					   IncomeType = Agency2000Ws_Test.eIncomeType.COM_VAT_ZERO
                   }
               );
            }

            hotelService.Hotels = hotels.ToArray();
            services.Add(hotelService);
        }

        Agency2000Ws_Test.Package package = new Agency2000Ws_Test.Package
        {
            HotelService = hotelService,
            Flight = flight,            
            Id = flight.Id,
            PaidToSupplierId = flight.PaidToSupplierId,
            FromDate = getPackageDateByFlights(flight.Flights, true),
            ToDate = getPackageDateByFlights(flight.Flights, false),
            CurrencyId = flight.CurrencyId
        };

        iDocketParams.Services = new[] { package };
        //iDocketParams.Services =  s ervices.ToArray();
    }

    private void fillServiceWithSupplierId(ref Agency2000Ws_Test.Agency2000WS iWebService,
                                           ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams,
                                           Agency2000Ws_Test.Service iService,
                                           string iServiceType, string iSupplierCode, string iSupplierName)
    {
        string supplierId = string.Empty;

        // If the company name is empty, try to get it from the service via code.
        if(string.IsNullOrEmpty(iSupplierName))
        {
            iSupplierName = iWebService.GetAirlineNameByCarrier(iDocketParams.AgencyId.ToString(), iDocketParams.SystemType.ToString(),
                                                                iDocketParams.UserName, iSupplierCode);
        }

        if (!string.IsNullOrEmpty(iSupplierName))
        {
            supplierId = iWebService.GetSupplierIdByName(iSupplierName, iDocketParams.AgencyId.ToString(),
                                                                iDocketParams.SystemType.ToString(), "0", iServiceType,
                                                                iSupplierCode, Agency2000Ws_Test.eSourceTypes.None, "", "");
            iService.Id = supplierId;
            iService.PaidToSupplierId = iWebService.GetBspIdForSupplier(iDocketParams.AgencyId.ToString(),
                                                                       iDocketParams.SystemType.ToString(),
                                                                       iDocketParams.UserName, supplierId);
            if (string.IsNullOrEmpty(iService.PaidToSupplierId))
            {
                iService.PaidToSupplierId = supplierId;
            }
        } else
        {
            Logger.Log("SabreLds: Supplier name is empty.");
            throw new Exception("S|" + Utils.GetTextFromFile("ExcMes_SuppName") + iSupplierCode);
        }
    }
    private void fillServiceWithFlightRow(ref Agency2000Ws_Test.Flight iFlight,
                                          ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams,
                                          ref Agency2000Ws_Test.Agency2000WS iWebService,
                                          SabreLdsRetrieveReservationResponse.Leg iFlightDetails,
                                          string iCurrency, string iPnr, string[] iTravellersAssociationIds)
    {
        DateTime arrivalDateTime = Utils.GetDateTimeFromString(iFlightDetails.ArrDate);
        DateTime DepartureDateTime = Utils.GetDateTimeFromString(iFlightDetails.DepDate);

        Agency2000Ws_Test.FlightRow flightRow = new Agency2000Ws_Test.FlightRow
        {
            ArrivalDate = arrivalDateTime.Date,
            ArrivalTime = arrivalDateTime.ToString("HH:mm"),
            ArrivalPortId = iWebService.GetPortIdByName(iDocketParams.AgencyId.ToString(),
                                                          iDocketParams.SystemType.ToString(), iDocketParams.UserName,
                                                          iFlightDetails.ArrCity),
            Id = iFlight.Id,
            SupplierId = iFlight.Id,
            PNR = iPnr,
            Class = iFlightDetails.FlightClass,
            TravellersAssociationIds = iTravellersAssociationIds,
            CurrencyId = (Agency2000Ws_Test.eCurrency)Enum.Parse(typeof(Agency2000Ws_Test.eCurrency), iCurrency),
            CurrencyIdX = Utils.GetCurrencyIdByName(iCurrency),
            DataThruClerkId = iDocketParams.ClerkId.ToString(),
            DepartureDate = DepartureDateTime.Date,
            DepartureTime = DepartureDateTime.ToString("HH:mm"),
            DataRecievedDate = DateTime.Now,
            DeparturePortId = iWebService.GetPortIdByName(iDocketParams.AgencyId.ToString(),
                                                          iDocketParams.SystemType.ToString(), iDocketParams.UserName,
                                                          iFlightDetails.DepCity),
            ServiceType = "1",
            ServiceStatusId = "2",
            FlightNumber = iFlightDetails.FlightNumber,
            IsCreateVoucher = true,
            VoucherStatus = "1",
            IncomeTypeId = "1"
        };

        if (iFlight.Flights == null || iFlight.Flights.Length == 0)
        {
            iFlight.Flights = new[] { flightRow };
        }
        else
        {
            var flights = iFlight.Flights.ToList();
            flights.Add(flightRow);
            iFlight.Flights = flights.ToArray();
        }
    }

    private void fillParamsWithTravellers(ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams,
                                          ref SabreLdsRetrieveReservationResponse.Reservation iResponse)
    {
        Agency2000Ws_Test.Escort traveller = null;
        Agency2000Ws_Test.Escort currentTraveller = null;

        foreach (SabreLdsRetrieveReservationResponse.Pax passenger in iResponse.Pax)
        {
            currentTraveller = new Agency2000Ws_Test.Escort
            {
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                DateOfBirth = DateTime.Parse(Utils.getDateByFormat(passenger.BirthDate)),
                GenderId = Utils.GetGenderByTitle(passenger.PaxTitle),
                Title = passenger.PaxTitle,
                AssociationId = passenger.RefId
            };

            switch (passenger.PaxType)
            {
                case "INFANT":
                    currentTraveller.AgeGroupId = "1";
                    break;
                case "CHILD":
                    currentTraveller.AgeGroupId = "2";
                    break;
                case "ADULT":
                    currentTraveller.AgeGroupId = "3";
                    break;
            }

            if (traveller == null)
            {
                traveller = currentTraveller;
                traveller.Brutto = decimal.Parse(iResponse.TotalFare);
            }
            else
            {
                var docketEscorts = traveller.Escorts == null ? new List<Agency2000Ws_Test.Escort>() : traveller.Escorts.ToList();
                var escort = docketEscorts.Find(es => es.FirstName.Equals(currentTraveller.FirstName) && es.LastName.Equals(currentTraveller.LastName));
                if (escort == null)
                {
                    docketEscorts.Add(currentTraveller);
                }
                traveller.Escorts = docketEscorts.ToArray();
            }
        }

        iDocketParams.IsAddTravellers = true;
        iDocketParams.IsAddTravellersToServices = true;
        iDocketParams.Traveller = traveller;
    }


    private void popUpMessage(string iMessage)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "Popup", "ShowPopup('" + iMessage + "');", true);
    }

    private DateTime getPackageDateByFlights(Agency2000Ws_Test.FlightRow[] iFlights, bool iIsFrom)
    {
        DateTime date = iFlights[0].DepartureDate;

        foreach (Agency2000Ws_Test.FlightRow flight in iFlights)
        {
            if (iIsFrom ? flight.DepartureDate < date : flight.DepartureDate > date)
            {
                date = flight.DepartureDate;
            }
        }

        return date;
    }
}