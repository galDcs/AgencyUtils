using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

public partial class SabrePNR : Page
{

    /*
     * BJZBXV
ZKHDEA
SRMPPX
     * 
     */
    ////MessageHeader

    //private string mFromPartyId = "Agency"; //this name has no connection to Agency2000...
    //private string mToPartyId = "Sabre_API";

    ////Security > UsernameToken
    //private string mUsername = "516420";
    //private string mPassword = "T0H85T2";
    //private string mOrganization = "T4QK";
    //private string mDomain = "AA";
    private string mPcc = "T4QK";//lachish: "K9HK";
    private string mPcc2 = "T4QK";//lachish: K9HK";
    private SabreConnector mSabreConnector = new SabreConnector();
    private Dictionary<string, string> mSuccessfulPnrsToDockets = new Dictionary<string, string>();
    private Dictionary<string, string> mBadPnrsToReasons = new Dictionary<string, string>();
    private Dictionary<string, List<string>> mTicketsToFlightNumbers = new Dictionary<string, List<string>>();
    private Dictionary<string, List<SabreGetReservationResponse.Passenger_stl19>> mTicketsToPassengers = new Dictionary<string, List<SabreGetReservationResponse.Passenger_stl19>>();
    private List<string> mReplacedTickets = new List<string>();
        
	private string mSabreSessionToken
    {
        get
        {
			Logger.Log("here.2");
            string sabreSession = (string)Session["sabreSessionToken"];
			Logger.Log("here.3 sabreSession = " + sabreSession);
            if (string.IsNullOrEmpty(sabreSession))
            {
				Logger.Log("here.4");
                sabreSession = getSession();
				Logger.Log("here.10 sabreSession = " + sabreSession);
                Session["sabreSessionToken"] = sabreSession;
            }
			Logger.Log("here.11");
            return sabreSession;
        }
    }   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			Session["bliHello"] = "jsdjsjsj";
            loadBussinessClients();
            loadDocketDescribes();
            // string sabreSession = string.Empty;

            // if (Session["SabreQueueAccessResponse"] == null)
            // {
            //     sabreSession = getSession();
            // }

            // if (!string.IsNullOrEmpty(sabreSession) || Session["SabreQueueAccessResponse"] != null)
            // {
            //     queueAccess(sabreSession);
            // }  
            createQueueHtml(sendQueueAccessRequest());
        }
		
		if (Session["bliHello"] == null)
			Logger.Log("1bli hello null");
		else
			Logger.Log("1im hello");
    }

    private void loadBussinessClients()
    {
        ddlBussinessClients.Items.Clear();
        ddlBussinessClients.Items.Add(new ListItem("All", "0"));
        fillDropDownListsWithQuery(ddlBussinessClients, "SELECT (name) as name, id FROM BUSINESS_CLIENTS WHERE status = 1 and type_id = 2 ORDER BY name");
    }

    private void loadDocketDescribes()
    {
        ddlDocketDescribes.Items.Clear();
        ddlDocketDescribes.Items.Add(new ListItem("All", "0"));
        fillDropDownListsWithQuery(ddlDocketDescribes, "SELECT (description) as name, id FROM DOCKET_DESCRIBES ORDER BY name");//WHERE status = 1 
    }

    private void fillDropDownListsWithQuery(DropDownList iDdl, string iQuery)
    {
        DataSet ds = DAL_SQL.RunSqlDataSet(iQuery);
        ListItem tempItem = null;

        if (Utils.IsDataSetRowsNotEmpty(ds))
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                tempItem = new ListItem(row["name"].ToString(), row["id"].ToString());
                iDdl.Items.Add(tempItem);
            }
        }
    }

    private string getSession()
    {
        string sabreSession = string.Empty;

        SabreRequest<SabreSessionCreateRequest> sessionCreateReq = new SabreRequest<SabreSessionCreateRequest>();
        sessionCreateReq = SabreUtils.SetSabreHeader<SabreSessionCreateRequest>("SessionCreateRQ", "SessionCreateRQ");
        sessionCreateReq.Body = new SabreSessionCreateRequest();

        try
        {
			Logger.Log("here.5");
            //SabreRequest<SabreSessionCreateRequest> sessionRes = sabreConnector.GetSessionToken(sessionCreateReq);
            sabreSession = mSabreConnector.GetSessionToken(sessionCreateReq);
			Logger.Log("here.6");
        }
        catch (Exception ex)
        {
            Response.Write("<br/>getSession Exception. Message = " + ex.Message);
            Response.Write("<br/>Trace = " + ex.StackTrace);
        }

        return sabreSession;
    }

    // private void queueAccess(string iSabreSession)
    // {
    //     //chkListPNRS.Items.Clear();
    //     int itemCount = 0;

    //     SabreRequest<SabreQueueAccessRequest> queueAccess = new SabreRequest<SabreQueueAccessRequest>();
    //     queueAccess = SabreUtils.SetSabreHeader<SabreQueueAccessRequest>("QueueAccessLLSRQ", "QueueAccessLLSRQ", iSabreSession);
    //     queueAccess.Body = new SabreQueueAccessRequest
    //     {
    //         ReturnHostCommand = "true",
    //         Version = "2.1.0",
    //         QueueIdentifierX = new SabreQueueAccessRequest.QueueIdentifier
    //         {
    //             Number = "501", //TODO: from db maybe?
    //             PseudoCityCode = mPcc,
    //             List = new SabreQueueAccessRequest.List
    //             {
    //                 Ind = "true",
    //                 PrimaryPassenger = "true"
    //             }
    //         }
    //     };

    //     try
    //     {
    //         SabreResponse<SabreQueueAccessResponse> res;

    //         if (Session["SabreQueueAccessResponse"] == null)
    //         {
    //             res = mSabreConnector.GetQueue(queueAccess);
    //             Session["SabreQueueAccessResponse"] = res;
    //             Session.Timeout = 20;
    //         }
    //         else
    //         {
    //             res = (SabreResponse<SabreQueueAccessResponse>)Session["SabreQueueAccessResponse"];
    //         }

    //         if (res != null)
    //         {
    //             string text;
    //             DateTime departureDate;
    //             string departureDateStr;
    //             StringBuilder tableBodyHtml = new StringBuilder();

    //             foreach (SabreQueueAccessResponse.LineClass line in res.Body.QueueAccess.Line)
    //             {
    //                 DateTime.TryParse(line.DateTime, out departureDate);
    //                 departureDateStr = departureDate.ToString("dd/MM/yy");
    //                 tableBodyHtml.Append(
    //                     string.Format(
    //                         @"<tr onclick='markInput({5}, false);'>
    //                             <td><input type='checkbox' id='chk{5}' value='{0}' onclick='markInput({5}, true); event.stopPropagation();'></td>
    //                             <td>{0}</td>
    //                             <td>{1}</td>
    //                             <td>{2}</td>
    //                             <td>{3}</td>
    //                             <td>{4}</td>
    //                         </tr>",
    //                         line.UniqueID.ID, line.POS.Source.PseudoCityCode,
    //                         line.POS.Source.AgentSine, departureDateStr,
    //                         line.PassengerName, itemCount++));
    //             }

    //             tableBody.InnerHtml = tableBodyHtml.ToString();
    //         }
    //     }
    //     catch (Exception hh)
    //     {
    //         Response.Write("<h2>queueAccess: <br/>" + hh.Message + "</h2>");
    //     }
    // }

	private SabreResponse<SabreQueueAccessResponse> sendQueueAccessRequest()
    {
        return sendQueueAccessRequest(string.Empty);
    }

    private SabreResponse<SabreQueueAccessResponse> sendQueueAccessRequest(string iAction)
    {
        SabreRequest<SabreQueueAccessRequest> queueAccess = new SabreRequest<SabreQueueAccessRequest>();
		
		Logger.Log("here.1");
        queueAccess = SabreUtils.SetSabreHeader<SabreQueueAccessRequest>("QueueAccessLLSRQ", "QueueAccessLLSRQ", mSabreSessionToken);
        queueAccess.Body = new SabreQueueAccessRequest
        {
            Navigation = !string.IsNullOrEmpty(iAction) ? new SabreQueueAccessRequest.NavigationClass
            {
                Action = iAction
            } : null,
            ReturnHostCommand = "true",
            Version = "2.1.0",
            QueueIdentifierX = new SabreQueueAccessRequest.QueueIdentifier
            {
                Number = "501", //TODO: from db maybe?
                PseudoCityCode = mPcc,
                List = string.IsNullOrEmpty(iAction) ? new SabreQueueAccessRequest.List
                {
                    Ind = "true",
                    PrimaryPassenger = "true"
                } : null
            }
        };

        //mSabreQueueAccessResponse = mSabreConnector.GetQueue(queueAccess);
        return mSabreConnector.GetSabreResponse<SabreQueueAccessRequest, SabreQueueAccessResponse>(queueAccess);


        //try
        //{
        //    SabreResponse<SabreQueueAccessResponse> res;

        //    if (Session["SabreQueueAccessResponse"] == null)
        //    {
        //        res = mSabreConnector.GetQueue(queueAccess);
        //        Session["SabreQueueAccessResponse"] = res;
        //        Session.Timeout = 20;
        //    }
        //    else
        //    {
        //        res = (SabreResponse<SabreQueueAccessResponse>)Session["SabreQueueAccessResponse"];
        //    }

        //    if (res != null)
        //    {
        //        createQueueHtml(res);
        //    }
        //}
        //catch (Exception hh)
        //{
        //    Response.Write("<h2>queueAccess: <br/>" + hh.Message + "</h2>");
        //}
    }

    private void createQueueHtml(SabreResponse<SabreQueueAccessResponse> iResponse)
    {
        int itemCount = 0;
        DateTime departureDate;
        string departureDateStr;
        StringBuilder tableBodyHtml = new StringBuilder();

        foreach (SabreQueueAccessResponse.LineClass line in iResponse.Body.QueueAccess.Line)
        {
            DateTime.TryParse(line.DateTime, out departureDate);
            departureDateStr = departureDate.ToString("dd/MM/yy");
            tableBodyHtml.Append(
                string.Format(
                    @"<tr onclick='markInput({5}, false);'>
                                <td><input type='checkbox' id='chk{5}' value='{0}' onclick='markInput({5}, true); event.stopPropagation();'></td>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                <td>{4}</td>
                            </tr>",
                    line.UniqueID.ID, line.POS.Source.PseudoCityCode,
                    line.POS.Source.AgentSine, departureDateStr,
                    line.PassengerName, itemCount++));
        }

        tableBody.InnerHtml = tableBodyHtml.ToString();
    }

    protected void btnCreateOrUpdateDocket_Click(object sender, EventArgs e)
    {
		if (Session["bliHello"] == null)
			Logger.Log("2bli hello null");
		else
			Logger.Log("2im hello");
		return;
        //Creating one docket for all selected items.
        Agency2000Ws_Test.Agency2000WS webService = new Agency2000Ws_Test.Agency2000WS();
        Agency2000Ws_Test.CreateAgencyDocketParams docketParams = new Agency2000Ws_Test.CreateAgencyDocketParams();
        if (!string.IsNullOrEmpty(textBoxDebugPnr.Text))
        {
            createOrUpdateDocket(textBoxDebugPnr.Text, ref webService, ref docketParams);
        }
        else
        {
			List<string> selectedPnr = txtPnrList.Text.Split('|').Where(pnr => pnr.Length > 0).ToList();

			if (!Utils.isEnumerableNullOrEmpty(selectedPnr))
			{
				if (!txtOpenInDocketId.Text.Equals("")) // Specific docketId
				{
					docketParams.DocketId = txtOpenInDocketId.Text;
				}
				if (!ddlDocketType.SelectedValue.Equals("1")) // Bussiness or Group
				{
					docketParams.DocketDetails = new Agency2000Ws_Test.DocketDetails
					{
						BussinessClientId = ddlBussinessClients.SelectedValue,
						DocketDescribe = ddlDocketDescribes.SelectedValue,
						DocketType = ddlDocketType.SelectedValue
					};
				}
            
                // Docket id list to handle reissues 
                Dictionary<string, string> pnrToDocket = new Dictionary<string, string>();
                string docketId = null;
                foreach (string pnr in selectedPnr)
                {
                    docketParams.DocketId = docketId;
                    createOrUpdateDocket(pnr, ref webService, ref docketParams);
                    if(mSuccessfulPnrsToDockets.ContainsKey(pnr))
                    {
                        removePnrFromQueue(pnr);
                    }

                    // If this is a new docket
                    if (docketParams.Services != null && docketParams.Traveller != null &&
                        (docketParams.Traveller.ReIssueTicketNumbers == null ||
                        docketParams.Traveller.ReIssueTicketNumbers.Length == 0 ||
                        docketParams.Traveller.Escorts == null ||
                        docketParams.Traveller.Escorts.All(escort => escort.ReIssueTicketNumbers == null || escort.ReIssueTicketNumbers.Length == 0))) 
                    {
                        if (docketId == null)
                        {
                            docketId = docketParams.DocketId;
                        }
                    }

                    divReplacedTickets.InnerHtml += string.Join("", mReplacedTickets.Select(ticket => "<span>" + ticket + "</span>"));
                }
			}
		}
		
        if (mSuccessfulPnrsToDockets.Count > 0)
        {
            divInsertedPnrs.InnerHtml = string.Join("", mSuccessfulPnrsToDockets.Select(pnr => "<span>" + pnr.Key + " - " + pnr.Value + "</span>"));
        }
        if (mBadPnrsToReasons.Count > 0)
        {
            divFailedPnrs.InnerHtml = string.Join("", mBadPnrsToReasons.Select(pnr => "<span>" + pnr.Key + " - " + pnr.Value + "</span>"));
        }
        
        createQueueHtml(sendQueueAccessRequest());
    }

	private void removePnrFromQueue(string iPnr)
    {
        sendQueueAccessRequest("QR");
        closeSession();
    }

    private SabreGetReservationResponse retrivePnr(string iPnr)
    {
        SabreGetReservationResponse response = null;
        SabreConnector sabreConnector;
        SabreResponse<SabreGetReservationResponse> sabreResponse;
        SabreRequest<SabreGetReservationRQ> sabreRequest = SabreUtils.SetSabreHeader<SabreGetReservationRQ>("GetReservationRQ", "GetReservationRQ", mSabreSessionToken);
        sabreRequest.Body = new SabreGetReservationRQ
        {
            Locator = iPnr,
            RequestType = "Stateful",
            Version = "1.19.0",
            ReturnOptionsX = new SabreGetReservationRQ.ReturnOptions
            {
                PriceQuoteServiceVersion = "4.1.0",
                ResponseFormat = "STL",
                ViewName = "Full",
                SubjectAreas = new SabreGetReservationRQ.SubjectAreas
                {
                    SubjectArea = "PRICE_QUOTE"
                }
            }
        };
        sabreConnector = new SabreConnector();
        sabreResponse = sabreConnector.GetReservationRS(sabreRequest);
        response = sabreResponse.Body;
        
        return response;
    }

    private void closeSession()
    {
        // Send Close session request
        SabreRequest<SabreSessionCloseRQRequest> sabreRequest = new SabreRequest<SabreSessionCloseRQRequest>();

        sabreRequest = SabreUtils.SetSabreHeader<SabreSessionCloseRQRequest>("SessionCloseRQ", "SessionCloseRQ", mSabreSessionToken);
        sabreRequest.Body = new SabreSessionCloseRQRequest
        {            
            Version = "2.1.0",
            POS = new SabreSessionCloseRQRequest.POSClass
            {
                Source = new SabreSessionCloseRQRequest.Source
                {
                    PseudoCityCode = mPcc
                }
            }
        };

        mSabreConnector.GetSabreResponse<SabreSessionCloseRQRequest, SabreSessionCloseRSResponse>(sabreRequest);

        // Clean session token
        Session["sabreSessionToken"] = null;
    }



    private void createOrUpdateDocket(string iPnr, ref Agency2000Ws_Test.Agency2000WS iWebService,
                                        ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams)
    {        
        try
        {
            SabreGetReservationResponse response = retrivePnr(iPnr);
            if (response == null)
            {
                mBadPnrsToReasons.Add(iPnr, "Response is Empty");
            }
            else if (response.GetReservation.Reservation_stl19.PassengerReservation_stl19.Segments_stl19.Segment_stl19.Count > 0)
            {
                string reason;
                if (setTicketToFlightsMap(ref response, out reason))
                {
                    fillParamsWithAdminInfo(ref iDocketParams);
                    fillDocketParamsWithService(ref iWebService, ref iDocketParams, ref response);
                    mSuccessfulPnrsToDockets.Add(iPnr, iDocketParams.DocketId);
                    
                }
                else
                {
                    mBadPnrsToReasons.Add(iPnr, reason);
                }
            }
            else
            {
                mBadPnrsToReasons.Add(iPnr, "There are no segments in the pnr");
            }
        }
        catch (Exception exception)
        {
            Logger.Log("Failed on createOrUpdateDocket.\nPnr no. " + iPnr + "\nException: " + exception.Message);
        }
    }


    // private void createOrUpdateDocket(string iPnr, ref Agency2000Ws_Test.Agency2000WS iWebService,
    //                                     ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams)
    // {
    //     SabreConnector sabreConnector;
    //     SabreResponse<SabreGetReservationResponse> sabreResponse;
    //     // DEBUG -
    //     try
    //     {
    //         string session = SabreUtils.GetSession();
    //         SabreRequest<SabreGetReservationRQ> sabreRequest = SabreUtils.SetSabreHeader<SabreGetReservationRQ>("GetReservationRQ", "GetReservationRQ", session);
    //         sabreRequest.Body = new SabreGetReservationRQ
    //         {
    //             Locator = iPnr,
    //             RequestType = "Stateful",
    //             Version = "1.19.0",
    //             ReturnOptionsX = new SabreGetReservationRQ.ReturnOptions
    //             {
    //                 PriceQuoteServiceVersion = "4.1.0",
    //                 ResponseFormat = "STL",
    //                 ViewName = "Full",
    //                 SubjectAreas = new SabreGetReservationRQ.SubjectAreas
    //                 {
    //                     SubjectArea = "PRICE_QUOTE"
    //                 }
    //             }
    //         };
    //         sabreConnector = new SabreConnector();
    //         sabreResponse = sabreConnector.GetReservationRS(sabreRequest);

    //         SabreGetReservationResponse response = sabreResponse.Body;
    //         if (response == null)
    //         {
    //             mBadPnrsToReasons.Add(iPnr, "Response is Empty");
    //         }
    //         else if (response.GetReservation.Reservation_stl19.PassengerReservation_stl19.Segments_stl19.Segment_stl19.Count > 0)
    //         {
    //             string reason;
    //             if (setTicketToFlightsMap(ref response, out reason))
    //             {
    //                 fillParamsWithAdminInfo(ref iDocketParams);
    //                 fillDocketParamsWithService(ref iWebService, ref iDocketParams, ref response);
    //                 //cancelReplacedFlights();
    //                 mSuccessfulPnrsToDockets.Add(iPnr, iDocketParams.DocketId);
    //             }
    //             else
    //             {
	// 				Logger.Log("here1");
    //                 mBadPnrsToReasons.Add(iPnr, reason);
    //             }
    //         }
    //         else
    //         {
	// 			Logger.Log("here2");
    //             mBadPnrsToReasons.Add(iPnr, "There are no segments in the pnr");
    //         }
    //     }
    //     catch (Exception exception)
    //     {
    //         Logger.Log("Failed on createOrUpdateDocket.\nPnr no. " + iPnr + "\nException: " + exception.Message);
    //     }
    // }

    private void fillParamsWithAdminInfo(ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams)
    {
        iDocketParams.AgencyId = int.Parse(((MasterPage)Master).AgencyId);
        iDocketParams.SystemType = int.Parse(((MasterPage)Master).SystemType);
        iDocketParams.UserName = ((MasterPage)Master).UserName;
        iDocketParams.Password = ((MasterPage)Master).Password;
        iDocketParams.ClerkId = int.Parse(((MasterPage)Master).ClerkId);
        iDocketParams.Language = ((MasterPage)Master).Lang.Equals("1252") ? Agency2000Ws_Test.eLanguage.English :
                                 ((MasterPage)Master).Lang.Equals("1255") ? Agency2000Ws_Test.eLanguage.Hebrew :
                                                                            Agency2000Ws_Test.eLanguage.Russian;


    }

    

    private void checkExtras(ref Dictionary<string, Agency2000Ws_Test.Flight> iCarrierToFlightServices,
                              ref Dictionary<string, Agency2000Ws_Test.Traveller> iCarrierToTravellers,
                              ref Agency2000Ws_Test.Agency2000WS iWebService, ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams,
                              ref SabreGetReservationResponse iResponse)
    {
        List<string> additionalTickets = null;
        List<Agency2000Ws_Test.Flight> additionalFlightServices = new List<Agency2000Ws_Test.Flight>();
        List<Agency2000Ws_Test.Traveller> additionalFlightTravellers = new List<Agency2000Ws_Test.Traveller>();
        try
        {
            additionalTickets =
            iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Passengers_stl19.Passenger_stl19
            .Select(passenger => passenger.TicketingInfo_stl19.TicketDetails_stl19)
            .SelectMany(t => t)
            .Where(ticketDetails => !ticketDetails.OriginalTicketDetails_stl19.Contains("*VOID*") &&
                                    !ticketDetails.OriginalTicketDetails_stl19.Equals("TV") &&
                                    !ticketDetails.TransactionIndicator_stl19.Equals("TE"))
            .Select(ticketDetails => ticketDetails.TicketNumber_stl19).ToList();
        }
        catch { }

        Dictionary<string, Agency2000Ws_Test.Traveller> ticketToTravellers = new Dictionary<string, Agency2000Ws_Test.Traveller>();
        if (!Utils.isEnumerableNullOrEmpty(additionalTickets))
        {
            foreach (var additionalTicket in additionalTickets)
            {
                string key = getSimilarKeyFromTicketDictonary(mTicketsToFlightNumbers, additionalTicket);
                var flightNumbers = mTicketsToFlightNumbers[key];
                if (!Utils.isEnumerableNullOrEmpty(flightNumbers))
                {
                    foreach (var flightNumber in flightNumbers)
                    {
                        // find flight from flight number
                        foreach (var carrierToFlightsPair in iCarrierToFlightServices)
                        {
                            var flight = carrierToFlightsPair.Value.Flights.ToList().Find(f => f.FlightNumber.Equals(flightNumber));
                            if (flight != null)
                            {
                                iDocketParams.Services = new[] {
                                new Agency2000Ws_Test.Flight
                                {
                                    Id = flight.Id,
                                    PaidToSupplierId = flight.PaidToSupplierId,
                                        Flights = new [] {
                                            new Agency2000Ws_Test.FlightRow
                                            {
                                                FlightAdditionId = "6",
                                                Id = flight.Id,
                                                ServiceType = flight.ServiceType,
                                                ServiceStatusId = flight.ServiceStatusId,
                                                SupplierId = flight.SupplierId,
                                                PNR = flight.PNR,
                                                DeparturePortId = flight.DeparturePortId,
                                                DepartureDate = flight.DepartureDate,
                                                DepartureTime = flight.DepartureTime,
                                                ArrivalPortId = flight.ArrivalPortId,
                                                ArrivalDate = flight.ArrivalDate,
                                                ArrivalTime = flight.ArrivalTime,
                                                DataRecievedDate = flight.DataRecievedDate,
                                                FlightNumber = flight.FlightNumber,
                                                Class = flight.Class,
                                                IsCreateVoucher = flight.IsCreateVoucher,
                                                IncomeTypeId = flight.IncomeTypeId,
                                                CurrencyIdX = flight.CurrencyIdX,
                                                CurrencyId = flight.CurrencyId,
                                                VoucherStatus = flight.VoucherStatus
                                            }
                                        }
                                    }
                                };
                            Agency2000Ws_Test.Traveller traveller;

                            if (ticketToTravellers.ContainsKey(key))
                            {
                                traveller = ticketToTravellers[key];
                            }
                            else
                            {
                                traveller = new Agency2000Ws_Test.Traveller();
                            }
                            fillTravellerWithTravellers(additionalTicket, ref traveller, ref iResponse);
                            iDocketParams.Traveller = traveller;
                            iDocketParams = (Agency2000Ws_Test.CreateAgencyDocketParams)iWebService.CreateDocketWithServicesFromParams(iDocketParams);
                            break;
                            }
                        }
                        
                    }
                }

            }
        }
    }

private void fillDocketParamsWithService(ref Agency2000Ws_Test.Agency2000WS iWebService,
                                               ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParam,
                                               ref SabreGetReservationResponse iResponse)
    {
        Dictionary<string, Agency2000Ws_Test.Flight> carrierToFlightServices = new Dictionary<string, Agency2000Ws_Test.Flight>();
        Dictionary<string, string> ticketsToCarriers = new Dictionary<string, string>();
        Dictionary<string, Agency2000Ws_Test.Traveller> carrierToTravellers = new Dictionary<string, Agency2000Ws_Test.Traveller>();

        // Get all flight numbers, find their segment, get the right service from the dictonary according to their carrier,
        // or create a new service for them and fill all the information from the response.
        var alreadyUsed = new List<string>();
        foreach (KeyValuePair<string, List<string>> ticketFlightNumbersPair in mTicketsToFlightNumbers)
        {
            List<string> flightNumbers = ticketFlightNumbersPair.Value;
            foreach (var flightNumber in flightNumbers)
            {
                // Take carrier from accounting lines according to ticket
                string carrier = iResponse.GetReservation.Reservation_stl19.AccountingLines_stl19.AccountingLine_stl19
                    .Where(al => Utils.IsStringsOverlapping(al.DocumentNumber_stl19, ticketFlightNumbersPair.Key))
                    .Select(al => al.AirlineDesignator_stl19)
                    .FirstOrDefault();

                // Add this carrier to the dictonary to use later for travellers
                if (!ticketsToCarriers.ContainsKey(ticketFlightNumbersPair.Key))
                {
                    ticketsToCarriers.Add(ticketFlightNumbersPair.Key, carrier);
                }

                // Avoid inserting flights twice if flight appears more than once.
                if (alreadyUsed.Contains(flightNumber)) continue;
                alreadyUsed.Add(flightNumber);

                // Find the segment that matches the flight number
                var segment = iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Segments_stl19.Segment_stl19
                                .Select(seg => seg.Air_stl19)
                                .Where(seg => seg.FlightNumber_stl19.Equals(flightNumber)).First();

                // Add this flight row to an existing service, or create a new one 
                Agency2000Ws_Test.Flight flight = null;
                if (carrierToFlightServices.ContainsKey(carrier))
                {
                    flight = carrierToFlightServices[carrier];
                }
                else
                {
                    flight = new Agency2000Ws_Test.Flight();
                    carrierToFlightServices.Add(carrier, flight);
                }

                fillFlightServiceWithFlightInformation(ref flight, carrier, ref segment, ref iWebService, ref iDocketParam, ref iResponse);

            }
        }

        // Get or Create traveller object for each ticket, and update the prices
        foreach (KeyValuePair<string, string> ticketCarrierPair in ticketsToCarriers)
        {
            Agency2000Ws_Test.Traveller traveller = null;
            if (carrierToTravellers.ContainsKey(ticketCarrierPair.Value))
            {
                traveller = carrierToTravellers[ticketCarrierPair.Value];
            } else
            {
                traveller = new Agency2000Ws_Test.Traveller();
            }
            fillTravellerWithTravellers(ticketCarrierPair.Key, ref traveller, ref iResponse);
            carrierToTravellers[ticketCarrierPair.Value] = traveller;
        }
        iDocketParam.IsAddTravellers = true;
        iDocketParam.IsAddTravellersToServices = true;

        // For each carrier, create the service with the corresponding travellers. 
        foreach (var carrier in carrierToFlightServices.Keys)
        {
            var flight = carrierToFlightServices[carrier];
            var traveller = carrierToTravellers[carrier];
            iDocketParam.Services = new[] { flight };
            iDocketParam.Traveller = traveller;
            iDocketParam = (Agency2000Ws_Test.CreateAgencyDocketParams)iWebService.CreateDocketWithServicesFromParams(iDocketParam);
        }

        // Check if there are tickets that are extras as seating and add them too to the docket.
        checkExtras(ref carrierToFlightServices, ref carrierToTravellers, ref iWebService, ref iDocketParam, ref iResponse);

    }
    private void fillFlightServiceWithFlightInformation(ref Agency2000Ws_Test.Flight iFlight, string iCarrier,
                                                        ref SabreGetReservationResponse.Air_stl19 iFlightRow,
                                                        ref Agency2000Ws_Test.Agency2000WS iWebService,
                                                        ref Agency2000Ws_Test.CreateAgencyDocketParams iDocketParams,
                                                        ref SabreGetReservationResponse iResponse)
    {
        List<Agency2000Ws_Test.FlightRow> flightRows = new List<Agency2000Ws_Test.FlightRow>();
        List<string> accountedTickets = new List<string>();

        // Initialize carrier details for the flight rows.
        string companyName = iWebService.GetAirlineNameByCarrier(iDocketParams.AgencyId.ToString(),
                                            iDocketParams.SystemType.ToString(),
                                            iDocketParams.UserName, iCarrier);
        string supplierId = iWebService.GetSupplierIdByName(companyName, iDocketParams.AgencyId.ToString(),
                                        iDocketParams.SystemType.ToString(), "0", "1",
                                        iCarrier, Agency2000Ws_Test.eSourceTypes.None, "", "");										

        string currencyCode;

        var accountingLines = iResponse.GetReservation.Reservation_stl19.AccountingLines_stl19.AccountingLine_stl19
                                .Where(al => al.AirlineDesignator_stl19 != null && al.AirlineDesignator_stl19.Equals(iCarrier) && al.CurrencyCode_stl19 != null)
                                .Select(al => al.CurrencyCode_stl19).ToList();

        if (accountingLines.Count == 0)
        {
            currencyCode = "USD";
        }
        else
        {
            currencyCode = accountingLines.First();
        }
        iFlight.Id = supplierId;
        iFlight.PaidToSupplierId = iWebService.GetBspIdForSupplier(iDocketParams.AgencyId.ToString(), iDocketParams.SystemType.ToString(),
                                                                  iDocketParams.UserName, supplierId);
        if (string.IsNullOrEmpty(iFlight.PaidToSupplierId))
        {
            iFlight.PaidToSupplierId = supplierId;
        }

        // Inserting flight details to the service.
        DateTime departureDateTime = DateTime.Parse(iFlightRow.DepartureDateTime_stl19);
        DateTime arrivalDateTime = DateTime.Parse(iFlightRow.ArrivalDateTime_stl19);
        var flightRow = new Agency2000Ws_Test.FlightRow
        {
			PaidToSupplierId = iFlight.PaidToSupplierId,            
            Id = supplierId,
            ServiceType = "1",
            ServiceStatusId = "2",
            SupplierId = supplierId,
            PNR = iResponse.GetReservation.Reservation_stl19.BookingDetails_stl19.RecordLocator_stl19,
            DeparturePortId = iWebService.GetPortIdByName(iDocketParams.AgencyId.ToString(),
                                                          iDocketParams.SystemType.ToString(), iDocketParams.UserName,
                                                          iFlightRow.DepartureAirport_stl19),
            DepartureDate = departureDateTime.Date,
            DepartureTime = departureDateTime.ToString("HH:mm"),
            ArrivalPortId = iWebService.GetPortIdByName(iDocketParams.AgencyId.ToString(),
                                                        iDocketParams.SystemType.ToString(), iDocketParams.UserName,
                                                        iFlightRow.ArrivalAirport_stl19),
            ArrivalDate = arrivalDateTime.Date,
            ArrivalTime = arrivalDateTime.ToString("HH:mm"),
            DataRecievedDate = DateTime.Now,
            FlightNumber = iFlightRow.FlightNumber_stl19,
            Class = iFlightRow.ClassOfService_stl19,
            IsCreateVoucher = true,
            IncomeTypeId = "1",
            CurrencyIdX = Utils.GetCurrencyIdByName(currencyCode),
            CurrencyId = (Agency2000Ws_Test.eCurrency)Enum.Parse(typeof(Agency2000Ws_Test.eCurrency), currencyCode),
            VoucherStatus = "1"
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


    private void fillTravellerWithTravellers(string iTicket, ref Agency2000Ws_Test.Traveller iTraveller, ref SabreGetReservationResponse iResponse)
    {
        var key = getSimilarKeyFromTicketDictonary(mTicketsToPassengers, iTicket);
        var passengers = mTicketsToPassengers[key];
        List<Agency2000Ws_Test.Escort> escorts = new List<Agency2000Ws_Test.Escort>();
        if (!Utils.isEnumerableNullOrEmpty(passengers))
        {
            // Getting the adults first to avoid child be saved as main traveller.
            passengers.Sort((passenger, other) => string.Compare(passenger.PassengerType, other.PassengerType));
            foreach (SabreGetReservationResponse.Passenger_stl19 passenger in passengers)
            {
                Agency2000Ws_Test.Escort traveller = new Agency2000Ws_Test.Escort
                {
                    FirstName = passenger.FirstName_stl19,
                    LastName = passenger.LastName_stl19,
                    CellPhone = passenger.PhoneNumbers_stl19,
                    Phone = passenger.PhoneNumbers_stl19
                };
                switch (passenger.PassengerType)
                {
                    case "INF": // Infant
                        traveller.AgeGroupId = "1";
                        traveller.Title = "INF";
                        break;
                    case "CNN": // Child
                    case "CHD": // Child
                        traveller.AgeGroupId = "2";
                        traveller.Title = "CHD";
                        break;
                    case "ADT": // Adult
                    case "SRC": // Senior Citizen
                        traveller.AgeGroupId = "3";
                        break;
                    default: break;
                }

                // Try to get extra information
                if (passenger.EmailAddress_stl19 != null &&
                    !string.IsNullOrEmpty(passenger.EmailAddress_stl19.Address_stl19))
                {
                    traveller.Mail = passenger.EmailAddress_stl19.Address_stl19;
                }
                try
                {
                    var travellerDocEntry = passenger.SpecialRequests_stl19.APISRequest_stl19
                        .Where(apiReq => apiReq.DOCSEntry_stl19 != null);

                    traveller.Id = travellerDocEntry.Where(doc => doc.DOCSEntry_stl19.DocumentNumber_stl19 != null)
                                                    .Select(doc => doc.DOCSEntry_stl19.DocumentNumber_stl19).First();
                    traveller.DateOfBirth = DateTime.Parse(travellerDocEntry.Where(doc => doc.DOCSEntry_stl19.DateOfBirth_stl19 != null)
                                                    .Select(doc => doc.DOCSEntry_stl19.DateOfBirth_stl19).First());
                    traveller.GenderId = travellerDocEntry.Where(doc => doc.DOCSEntry_stl19.Gender_stl19 != null)
                                                    .Select(doc => doc.DOCSEntry_stl19.Gender_stl19).First().Equals("M") ? "2" : "1";
                }
                catch { }

                traveller.TicketNumber = iTicket;
				// Get reissue tickets for this traveller
                traveller.ReIssueTicketNumbers = passenger.AccountingLines_stl19.AccountingLine_stl19
                                                .Where(al => al.OriginalTicketNumber_stl19 != null)
                                                .Select(al => al.OriginalTicketNumber_stl19)
                                                .ToArray();

                // Add prices of ticket
                SabreGetReservationResponse.AccountingLine_stl19 accountingLine =
                    passenger.AccountingLines_stl19.AccountingLine_stl19.Find(al => Utils.IsStringsOverlapping(al.DocumentNumber_stl19, iTicket));

                // if the accountingLines don't appear in the passenger, check outside passengers in the overall accounting.
                if(accountingLine == null)
                {
                    accountingLine = iResponse.GetReservation.Reservation_stl19.AccountingLines_stl19.AccountingLine_stl19
                         .Find(al => Utils.IsStringsOverlapping(al.DocumentNumber_stl19, iTicket));
                }

                if (accountingLine != null)
                {
                    decimal netto = decimal.Parse(accountingLine.BaseFare_stl19),
                        tax = decimal.Parse(accountingLine.TaxAmount_stl19);
                    traveller.Brutto = netto + tax;
                    traveller.Netto = netto;
                    traveller.Tax = tax;
                }

                if (iTraveller.FirstName == null)
                {
                    iTraveller = traveller;
                }
                else
                {
                    if (iTraveller.FirstName.Equals(traveller.FirstName) && iTraveller.LastName.Equals(traveller.LastName))
                    {
                        iTraveller.TicketNumber += "|" + traveller.TicketNumber;
                    }
                    else
                    {
                        var docketEscorts = iTraveller.Escorts == null ? new List<Agency2000Ws_Test.Escort>() : iTraveller.Escorts.ToList();
                        var escort = docketEscorts.Find(es => es.FirstName.Equals(traveller.FirstName) && es.LastName.Equals(traveller.LastName));
                        if (escort == null)
                        {
                            docketEscorts.Add(traveller);
                        }
                        else
                        {
                            escort.TicketNumber += "|" + traveller.TicketNumber;
                        }
                        iTraveller.Escorts = docketEscorts.ToArray();
                    }
                }

            }
        }
    }

   

private bool setTicketToFlightsMap(ref SabreGetReservationResponse iResponse, out string oReason)
    {
        oReason = "";
        bool success = false;
        mTicketsToFlightNumbers.Clear();
        mTicketsToPassengers.Clear();
        mReplacedTickets.Clear();

        // Get all tickets
        List<string> tickets = getValidTicketList(ref iResponse);
        if (tickets.Count > 0)
        {

            // --- Get all flight numbers  --- //

            foreach (string ticket in tickets)
            {
                try
                {
                    List<string> carrier =
                    iResponse.GetReservation.Reservation_stl19.AccountingLines_stl19.AccountingLine_stl19
                        .Where(al => al.DocumentNumber_stl19.Equals(ticket))
                        .Select(al => al.AirlineDesignator_stl19).ToList();
                    //addValuesToTicketBasedDictonary(mTicketsToCarriers, ticket, carrier);
                }
                catch { }

            }

            // Option 1 - ORE 
            // OpenReservationElement -> AncillaryProduct -> XmlData -> AncillaryServiceData -> EMDNumber With SegmentAssociationList -> SegmentAssociationTag

            foreach (var ticket in tickets)
            {
                try
                {
                    // Finding all the flight numbers associated with the ticket and adding them to the dictonary.
                    var ores =
                     iResponse.GetReservation.Reservation_stl19.OpenReservationElements_stl19.OpenReservationElement_or114
                         .Where(ore => ore.AncillaryProduct_or114 != null &&
                                       ore.AncillaryProduct_or114.XmlData_or114 != null &&
                                       ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114 != null &&
                                       ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114.EMDNumber_or114 != null &&
                                       (Utils.IsStringsOverlapping(ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114.EMDNumber_or114, ticket) ||
                                       Utils.IsStringsOverlapping(ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114.ETicketNumber_or114.ETicketNumber_or114X, ticket)))
                                       .Select(ore => ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114)
                                       .ToList();

                    var flightNumbers = ores.Where(ore => ore.Segment_or114 != null).Select(ore => ore.Segment_or114.FlightNumber_or114).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToFlightNumbers, ticket, flightNumbers);

                    var passengerRefNum = ores.Select(ore => ore.NameAssociationList_or114.NameAssociationTag_or114.ReferenceId_or114).ToList();
                    var passengers = iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Passengers_stl19.Passenger_stl19.Where(pass => passengerRefNum.Contains(pass.NameAssocId)).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToPassengers, ticket, passengers);

                    //var carriers = ores.Select(ore => ore.Segment_or114.MarketingCarrier_or114).ToList();
                    //addValuesToTicketBasedDictonary(mTicketsToCarriers, ticket, carriers);
                }
                catch { }
            }


            // Option 2 - ORE
            // OpenReservationElement -> AncillaryProduct -> XmlData -> AncillaryServiceData -> EMDNumber With SegmentId = (SegmentAssociationList -> SegmentAssociationId)
            foreach (var ticket in tickets)
            {
                try
                {
                    // Finding all the segment ids associated with the ticket number
                    var ancillarySD =
                     iResponse.GetReservation.Reservation_stl19.OpenReservationElements_stl19.OpenReservationElement_or114
                         .Where(ore => ore.AncillaryProduct_or114 != null &&
                                       ore.AncillaryProduct_or114.XmlData_or114 != null &&
                                       ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114 != null &&
                                       ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114.EMDNumber_or114 != null &&
                                       Utils.IsStringsOverlapping(ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114.EMDNumber_or114, ticket));

                    var segmentsId = ancillarySD.Select(ore => ore.AncillaryProduct_or114.XmlData_or114.AncillaryServiceData_or114.SegmentAssociationList_or114.SegmentAssociationId_or114);

                    // Finding the flight number via the segment id.
                    foreach (var segmentId in segmentsId)
                    {
                        var flightNumbers =
                            iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Segments_stl19.Segment_stl19
                            .Select(seg => seg.Air_stl19)
                            .Where(air => air.SegmentAssociationId.Equals(segmentId))
                            .Select(air => air.FlightNumber_stl19).ToList();

                        addValuesToTicketBasedDictonary(mTicketsToFlightNumbers, ticket, flightNumbers);
                    }

                    var passengerRefNum = ancillarySD.Select(asd => asd.NameAssociation_or114.NameRefNumber_or114).ToList();
                    var passengers = iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Passengers_stl19.Passenger_stl19.Where(pass => passengerRefNum.Contains(pass.NameAssocId)).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToPassengers, ticket, passengers);

                }
                catch { }
            }


            // Option 3 - Segments
            // Segment -> Air -> SegmentSpecialRequests -> FreeText Contains ticket

            foreach (var ticket in tickets)
            {
                try
                {
                    var specialReq =
                        iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Segments_stl19.Segment_stl19
                            .Select(seg => seg.Air_stl19)
                            .Where(air => air.SegmentSpecialRequests_stl19 != null &&
                                          air.SegmentSpecialRequests_stl19.GenericSpecialRequest_stl19 != null &&
                                          air.SegmentSpecialRequests_stl19.GenericSpecialRequest_stl19.Exists(gsr => gsr.FreeText_stl19 != null &&
                                                                                                                     gsr.FreeText_stl19.Contains(ticket)));
                    var flightNumbers = specialReq.Select(air => air.FlightNumber_stl19).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToFlightNumbers, ticket, flightNumbers);
                }
                catch
                {
                }
            }


            // Option 4 - Segments
            // Segment -> Air -> SegmentSpecialRequests -> FullText Contains ticket

            foreach (var ticket in tickets)
            {
                try
                {
                    var segments =
                        iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Segments_stl19.Segment_stl19
                            .Select(seg => seg.Air_stl19)
                                                        .Where(air => air.SegmentSpecialRequests_stl19 != null &&
                                                                      air.SegmentSpecialRequests_stl19.GenericSpecialRequest_stl19 != null &&
                                                                      air.SegmentSpecialRequests_stl19.GenericSpecialRequest_stl19.Exists(gsr => gsr.FullText_stl19 != null &&
                                                                                                                                                 gsr.FullText_stl19.Contains(ticket)));
                    var flightNumbers = segments.Select(air => air.FlightNumber_stl19).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToFlightNumbers, ticket, flightNumbers);
                }
                catch
                {
                }

            }


            // Option 5 - ORE
            // ServiceRequest -> FreeText Contains ticket with SegmentAssociation -> AirSegment -> FlightNumber


            foreach (var ticket in tickets)
            {
                try
                {
                    var ores =
                        iResponse.GetReservation.Reservation_stl19.OpenReservationElements_stl19.OpenReservationElement_or114
                            .Where(ore => ore.ServiceRequest_or114 != null &&
                                          ore.ServiceRequest_or114.FreeText_or114 != null &&
                                          ore.ServiceRequest_or114.FreeText_or114.Contains(ticket));

                    var flightNumbers = ores.Select(ore => ore.SegmentAssociation_or114.AirSegment_or114.FlightNumber_or114).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToFlightNumbers, ticket, flightNumbers);

                    var passengerRefNum = ores.Select(ore => ore.NameAssociation_or114.NameRefNumber_or114).ToList();
                    var passengers = iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Passengers_stl19.Passenger_stl19.Where(pass => passengerRefNum.Contains(pass.NameId)).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToPassengers, ticket, passengers);

                }
                catch
                {
                }

            }

            // Option 5 - ORE
            // ServiceRequest -> FreeText Contains ticket with SegmentAssociation -> AirSegment -> FlightNumber

            foreach (var ticket in tickets)
            {
                try
                {
                    var ores =
                         iResponse.GetReservation.Reservation_stl19.OpenReservationElements_stl19.OpenReservationElement_or114
                             .Where(ore => ore.ServiceRequest_or114 != null &&
                                           ore.ServiceRequest_or114.FullText_or114 != null &&
                                           ore.ServiceRequest_or114.FullText_or114.Contains(ticket)).ToList();

                    var flightNumbers = ores.Select(ore => ore.SegmentAssociation_or114.AirSegment_or114.FlightNumber_or114).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToFlightNumbers, ticket, flightNumbers);

                    var passengerRefNum = ores.Select(ore => ore.NameAssociation_or114.NameRefNumber_or114).ToList();
                    var passengers = iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.Passengers_stl19.Passenger_stl19.Where(pass => passengerRefNum.Contains(pass.NameId)).ToList();
                    addValuesToTicketBasedDictonary(mTicketsToPassengers, ticket, passengers);
                }
                catch
                {

                }
                if (mTicketsToFlightNumbers.Values.Count == 0)
                {
                    oReason = "Could not match tickets to flight numbers";
                    success = false;
                } else if (mTicketsToPassengers.Values.Count == 0)
                {
                    oReason = "Could not match tickets to passengers";
                    success = false;
                } else
                {
                    success = true;
                }
            }
        } else
        {
            oReason = "There are no valid tickets";
            success = false;
        }

        return success;

    }




    private List<string> getValidTicketList(ref SabreGetReservationResponse iResponse)
    {
        // Get all the BASE tickets (for a flight rather than flight row - i.e no connections) from accounting lines, THAT ARE VALID
        List<SabreGetReservationResponse.AccountingLine_stl19> accountingLines = 
                    iResponse.GetReservation.Reservation_stl19.AccountingLines_stl19.AccountingLine_stl19;
        List<string> tickets = accountingLines
            .Select(al => al.DocumentNumber_stl19).ToList();

        var ticketInformation = iResponse.GetReservation.Reservation_stl19.PassengerReservation_stl19.TicketingInfo_stl19.TicketDetails_stl19;

        // Go through ticket details in a differnt section in the xml and check if they are valid or void.
        foreach (string ticket in new List<string>(tickets))
        {
            var currentTicketsInformation = ticketInformation.Find(ti => Utils.IsStringsOverlapping(ti.TicketNumber_stl19, ticket) &&
            (ti.TransactionIndicator_stl19.Equals("TV") || ti.OriginalTicketDetails_stl19.Contains("VOID")));
            if (currentTicketsInformation != null)
            {
                tickets.Remove(ticket);
            }
        }

        // Set the list holding all the tickets that has a newer number.
        var accountingLinesReplacedTickets = accountingLines
            .Where(al => al.OriginalTicketNumber_stl19 != null)
            .Select(al => al.OriginalTicketNumber_stl19);
			
		foreach	(string replacedTicket in accountingLinesReplacedTickets) {
			if(!mReplacedTickets.Contains(replacedTicket)){
				mReplacedTickets.Add(replacedTicket);
			}
		}

        // Remove the replaced ticket
        foreach (string ticket in new List<string>(tickets))
        {
            if(mReplacedTickets.Exists(t => Utils.IsStringsOverlapping(t, ticket)))
            {
                tickets.Remove(ticket);
            }
        }
        return tickets;

    }

    private void addValuesToTicketBasedDictonary(Dictionary<string, List<string>> iDictonary, string iTicket, List<string> iValues)
    {
        if (iValues.Count == 0) return;

        var key = getSimilarKeyFromTicketDictonary(iDictonary, iTicket);
        if (string.IsNullOrEmpty(key))
        {
            iDictonary.Add(iTicket, new List<string>());
            key = iTicket;
        }
        foreach (var value in iValues)
        {
            if (!iDictonary[key].Contains(value))
            {
                iDictonary[key].Add(value);
            }
        }
    }

    private void addValuesToTicketBasedDictonary(Dictionary<string, List<SabreGetReservationResponse.Passenger_stl19>> iDictonary,
                                                 string iTicket, List<SabreGetReservationResponse.Passenger_stl19> iValues)
    {
        if (iValues.Count == 0) return;

        var key = getSimilarKeyFromTicketDictonary(iDictonary, iTicket);
        if (string.IsNullOrEmpty(key))
        {
            iDictonary.Add(iTicket, new List<SabreGetReservationResponse.Passenger_stl19>());
            key = iTicket;
        }
        foreach (var value in iValues)
        {
            if (!iDictonary[key].Contains(value))
            {
                iDictonary[key].Add(value);
            }
        }
    }

    private void popUpMessage(string iMessage)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "Popup", "ShowPopup('" + iMessage + "');", true);
    }

    private string getSimilarKeyFromTicketDictonary(Dictionary<string, List<string>> dictonary, string iTicket)
    {
        foreach (var ticket in dictonary.Keys)
        {
            if (Utils.IsStringsOverlapping(ticket, iTicket)) return ticket;
        }
        return string.Empty;
    }

    private string getSimilarKeyFromTicketDictonary(Dictionary<string, List<SabreGetReservationResponse.Passenger_stl19>> dictonary, string iTicket)
    {
        foreach (var ticket in dictonary.Keys)
        {
            if (Utils.IsStringsOverlapping(ticket, iTicket)) return ticket;
        }
        return string.Empty;
    }

}