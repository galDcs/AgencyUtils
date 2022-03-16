using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class FlightsOutgoingWS : System.Web.Services.WebService
{
    private const int mSessionTimeout = 15;
    public const string AdultType = "adult";
    public const string StudentType = "student";
    public const string YoungType = "young";
    public const string ChildType = "child";
    public const string InfantType = "infant";
    public const string SeniorType = "senior";

    public FlightsOutgoingWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public AlpFlightGetDataResponse GetAlpFlightGetDataResponse(SearchParams iSearchParams)
    {
        AmadeusConnector ac = new AmadeusConnector();
        string request = createDataRequest(iSearchParams);
        //List<eDealType> dealTypes = Enum.GetValues(typeof(eDealType)).Cast<eDealType>().ToList();
        string response = string.Empty;
        //foreach (eDealType dealType in dealTypes)
        //{
        //    response += ac.GetDataRequest(request);
        //}
        response = ac.GetDataRequest(request);
        AlpFlightGetDataResponse alpResponse = null;

        alpResponse = JsonConvert.DeserializeObject<AlpFlightGetDataResponse>(response);
        
        return alpResponse;
    }

    //Suppose to check for new dealId with the same parameters as the first order.
    private List<Segment> findSegments(SearchParams iSearchParams, FlightOrder iOriginalFlightOrder, AlpFlightGetDataResponse iAlpResponse,
                                        string iBound)
    {
        //Suppose to check for new dealId with the same parameters as the first order.
        List<Segment> segments = new List<Segment>();
        Dictionary<string, List<Dictionary<string, Bound>>> dealFlightSegments = iAlpResponse.result.dealFlightsSegments;

        //Suppose to check for new dealId with the same parameters as the first order.
        if (iAlpResponse.result.Deals != null)
        {
            //Maybe not relevant
            //foreach (FlightResponse flightX in iOriginalFlightOrder.OutboundItinerary)
            //{
            //    var res = iAlpResponse.result.flights.Select(x => x.Value.departureTime == flightX.departureTime &&
            //                                                      x.Value.arrivalTime == flightX.arrivalTime &&
            //                                                      x.Value.flightDuration == flightX.flightDuration);
            //}

            //Maybe not relevant
            //foreach (Deal deal in iAlpResponse.result.Deals)
            //{
            //    List<Dictionary<string, Bound>> dealFlightSegment = iAlpResponse.result.dealFlightsSegments[deal.dealId];
            //    foreach (Dictionary<string, Bound> option in dealFlightSegment)
            //    {
            //        if (isSameDeal(option["1"], iOriginalFlightOrder, "OUT"))
            //        {
            //
            //        }
            //    }
            //}
        }

        return segments;
    }

    public FlightOrder GetFlightResponseWithoutSearch(string iDealId, string iBookingId, AlpFlightGetDataResponse iAlpResponse,
                                                        bool iIsRoundTrip, int iNumAdults, int iNumStudents,
                                                        int iNumYoungs, int iNumChildren, int iNumInfants,
                                                        int iNumSeniors)
    {
        FlightOrder flightResponse = null;
        Deal deal = null;
        List<Dictionary<string, Bound>> dealFlightSegment = null;
        List<Segment> outSegments = null;
        List<Segment> inSegments = null;
        List<FlightResponse> outboundItinerary = null;
        List<FlightResponse> inboundItinerary = null;

        deal = iAlpResponse.result.Deals.Find(x => x.dealId == iDealId);

        if (deal.dealType == eDealType.FLIGHT.ToString())
        {
            dealFlightSegment = iAlpResponse.result.dealFlightsSegments[deal.dealId];
        }
        else if (deal.dealType == eDealType.CHARTER.ToString())
        {
            //dealFlightSegment = iResponse.result.dealFlightsSegments[deal.dealId + "_" + dealsIndex];
            string currDealId = iAlpResponse.result.dealFlightsSegments.Keys.ToList().Find(x => x.Contains(deal.dealId + "_"));

            dealFlightSegment = iAlpResponse.result.dealFlightsSegments[currDealId];
        }
        //dealFlightSegment = iAlpResponse.result.dealFlightsSegments[deal.dealId];
        outSegments = getDirectionSegments(dealFlightSegment, "OUT", iBookingId,
                                            deal.dealType);
        outboundItinerary = getDirectionItinerary(outSegments, iAlpResponse.result.flights);
        if (iIsRoundTrip)
        {
            inSegments = getDirectionSegments(dealFlightSegment, "IN", iBookingId,
                                                deal.dealType);
            inboundItinerary = getDirectionItinerary(inSegments, iAlpResponse.result.flights);
        }

        flightResponse = new FlightOrder(outboundItinerary, inboundItinerary, deal,
                                            outSegments, inSegments, iNumAdults,
                                            iNumChildren, iNumStudents, iNumInfants,
                                            iNumSeniors, iNumYoungs, iDealId,
                                            iBookingId, iIsRoundTrip);

        return flightResponse;
    }

    private List<Segment> getDirectionSegments(List<Dictionary<string, Bound>> iDealFlightSegment, string iDirection, string iBookingId,
                                                string iDealType)
    {
        List<Segment> segments = new List<Segment>();
        string key = iDirection == "OUT" ? "1" : "2";

        foreach (Dictionary<string, Bound> option in iDealFlightSegment)
        {
            List<Segment> tmpSegments = option[key].segments.Values.ToList();

            if (tmpSegments[0].bookingId == iBookingId && iDealType == eDealType.FLIGHT.ToString())
            {
                segments = tmpSegments;
                break;
            }
            else if(iDealType == eDealType.CHARTER.ToString())
            {
                segments = tmpSegments;
            }
        }

        return segments;
    }

    private List<FlightResponse> getDirectionItinerary(List<Segment> iSegments, Dictionary<string, FlightResponse> iFlights)
    {
        List<FlightResponse> itinerary = new List<FlightResponse>();

        foreach (Segment segment in iSegments)
        {
            itinerary.Add(iFlights[segment.flightId.ToString()]);
        }

        return itinerary;
    }

    public string createDataRequest(SearchParams iSearch)
    {
        string user = "AGNCY2";//LEVHFA";
        string pass = "Agency2000";//"Ruti5858";
        string request = string.Empty;
        var iCountPaxType = 0; //pax type counter
        DateTime dt = new DateTime();
        AlpGetDataRequest dataRequest = new AlpGetDataRequest();

        dataRequest.id = 1;
        dataRequest.jsonrpc = "2.0";
        dataRequest.method = "getData";
        //md5($password.$identifier.$method.$token)
        dataRequest.@params = new RegFligtParams();
        dataRequest.@params.identifier = user;//"MEGATO";//
        string MyToken = Guid.NewGuid().ToString().Substring(0, 8);
        string sChecksum = CreateMD5(pass + user + "getData" + MyToken);
        //var sChecksum = MyEncrypt.getMd5Hash("MEGA347" + "MEGATO" + "getData" + MyToken);
        dataRequest.@params.checkSum = sChecksum;

        dataRequest.@params.token = MyToken;
        dataRequest.@params.data = new RegFligtData();
        dataRequest.@params.data.numberOfAdults = int.Parse(iSearch.Adults);
        dataRequest.@params.data.numberOfChildren = int.Parse(iSearch.Childern);
        dataRequest.@params.data.numberOfInfants = int.Parse(iSearch.Infants);
        dataRequest.@params.data.numberOfSeniors = int.Parse(iSearch.Seniors);
        dataRequest.@params.data.numberOfStudents = int.Parse(iSearch.Students);
        dataRequest.@params.data.numberOfYoung = int.Parse(iSearch.Youngs);
        dataRequest.@params.data.debug = "";

        //TODO: check currency
        //dataRequest.@params.data.searchCurrency = "USD";
        dataRequest.@params.data.dealType = iSearch.DealType;
        dataRequest.@params.data.departure = ("TLV");//iSearch.DepartureLocation;
        dataRequest.@params.data.date = iSearch.DepartureDate.Value.ToString("yyyy-MM-dd");// "2019-05-12";
        if (iSearch.IsRoundTrip)
        {
            dataRequest.@params.data.returnDate = iSearch.ReturnDate.Value.ToString("yyyy-MM-dd");
            dataRequest.@params.data.segments = "FF";
        }
        else
        {
            dataRequest.@params.data.returnDate = " ";
            dataRequest.@params.data.segments = "F";
        }

        dataRequest.@params.data.destinationList = new List<string>();
        dataRequest.@params.data.destinationList.Add("HER");//iSearch.DestinationLocation);
        //TODO:
        //if (!string.IsNullOrEmpty(gap.Ipcc) && gap.Ipcc.Length > 3)
        //{
        //    dataRequest.@params.data.commission = gap.Ipcc;
        //}

        //if(iSearch.isFlightOneWay)
        //{
        //dataRequest.@params.data.departure = iSearch.DepartureLocation;
        //dataRequest.@params.data.date = iSearch.DepartureDate.Value.ToString("yyyy-MM-dd");// "2019-05-12";
        //dataRequest.@params.data.returnDate = iSearch.ReturnDate.Value.ToString("yyyy-MM-dd");
        //dataRequest.@params.data.destinationList = new List<string>();
        //dataRequest.@params.data.destinationList.Add(iSearch.DestinationLocation);

        dataRequest.@params.data.flightItinerary = new List<RegFlightItinerary>();
        RegFlightItinerary f1 = new RegFlightItinerary();
        f1.departureCode = iSearch.DepartureLocation;
        f1.arraivalCode = iSearch.DestinationLocation;
        f1.departureDate = iSearch.DepartureDate.Value.ToString("yyyy-MM-dd");

        f1.radius = "100";
        //queryFS.Query.FltSearchPrefernce.
        //dataRequest.@params.data.flightItinerary.Add(f1);
        //}

        request = JsonConvert.SerializeObject(dataRequest);
        return request;
    }

    public string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }

    public bool IsFlightAvailable(string iProductId, out decimal ioPrice)
    {
        string price = string.Empty;
        bool isAvailable = false;
        AmadeusConnector ac = new AmadeusConnector();
        string request = createCheckSeatAndPriceRequest(iProductId);
        string responseStr = ac.CheckSeatAndPriceRequest(request);

        ioPrice = 0;

        try
        {
            AlpCheckSeatAndPriceResponse response = JsonConvert.DeserializeObject<AlpCheckSeatAndPriceResponse>(responseStr);
            if (response.result.isBookable.ToLower() == "yes")
            {
                isAvailable = true;
                price = response.result.fareAmount.fareAmount;
                ioPrice = decimal.Parse(price);
            }

        }
        catch(Exception ex)
        {
            Logger.Log(ex.Message + " " + ex.StackTrace);
        }

        return isAvailable;
    }

    private string createCheckSeatAndPriceRequest(string iProductId)
    {
        string user = "AGNCY2";
        string pass = "Agency2000";
        string request = string.Empty;
        AlpCheckSeatAndPriceRequest dataRequest = new AlpCheckSeatAndPriceRequest();
        dataRequest.id = 1;
        dataRequest.jsonrpc = "2.0";
        dataRequest.method = "checkSeatAndPrice";
        dataRequest.@params = new CheckSeatAndPriceParams();
        dataRequest.@params.identifier = user;
        string MyToken = Guid.NewGuid().ToString().Substring(0, 8);
        string sChecksum = CreateMD5(pass + user + "checkSeatAndPrice" + MyToken);
        dataRequest.@params.token = MyToken;
        dataRequest.@params.checkSum = sChecksum;
        dataRequest.@params.data = new CheckSeatAndPriceData();
        dataRequest.@params.data.debug = "true";
        dataRequest.@params.data.productId = iProductId;
        request = JsonConvert.SerializeObject(dataRequest);

        return request;
    }

    public string GenerateCreateDocketRequest(Dictionary<string, string> iTravellersDetails)
    {
        string request = string.Empty;
        AlpCreateDocketRequest alpRequest = new AlpCreateDocketRequest();
        try
        {
            FlightOrder order = FlightOrder.LoadFromSession();
            alpRequest.id = 1;
            alpRequest.jsonrpc = "2.0";
            alpRequest.method = "createDocket";
            string user = "AGNCY2";
            string pass = "Agency2000";
            string MyToken = Guid.NewGuid().ToString().Substring(0, 8);
            var sChecksum = CreateMD5(pass + user + "createDocket" + MyToken);
            alpRequest.@params = new CreateDocketParams();
            alpRequest.@params.identifier = user;
            alpRequest.@params.checkSum = sChecksum;
            alpRequest.@params.token = MyToken;
            alpRequest.@params.data = new CreateDocketData();
            alpRequest.@params.data.debug = "true";
            alpRequest.@params.data.referenceId = getReferenceId(order.DealId, order.Deal.dealType);
            alpRequest.@params.data.referenceSource = "Json";
            alpRequest.@params.data.supplier = order.Deal.provider;
            alpRequest.@params.data.currency = order.Deal.currency;
            alpRequest.@params.data.clients = new Clients();
            Dictionary<int, double?> clientToPrice = new Dictionary<int, double?>();
            alpRequest.@params.data.clients.client = createClientList(clientToPrice, order, iTravellersDetails);
            alpRequest.@params.data.reservations = new Reservations();
            alpRequest.@params.data.reservations.reservation = createReservationList(order, alpRequest.@params.data.clients.client, clientToPrice);
            request = JsonConvert.SerializeObject(alpRequest);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return request;
    }

    private List<Reservation> createReservationList(FlightOrder iOrder, List<Client> ioClients, Dictionary<int, double?> iClientToPrice)
    {
        List<Reservation> reservations = new List<Reservation>();
        Reservation reservation = new Reservation();
        int reservationIndex = 1;
        reservation.reservationIndex = reservationIndex.ToString();
        reservation.requestPnr = "No"; // FOR TESTING
        reservation.reservationSupplier = iOrder.Deal.provider;
        reservation.reservationProducts = new ReservationProducts();
        reservation.reservationProducts.product = new List<Product>();
        foreach (Segment segment in iOrder.OutboundSegments)
        {
            Product product = new Product();
            product.productType = eProductType.F.ToString();
            product.productId = segment.flightId.ToString();
            product.productClients = new ProductClients();
            product.productClients.productClient = new List<ProductClient>();
            foreach (Client client in ioClients)
            {
                ProductClient productClient = new ProductClient();
                productClient.clientRef = client.clientIndex;
                productClient.price = iClientToPrice[client.clientIndex];
                product.productClients.productClient.Add(productClient);
            }
            product.productAdditionalDetails = new ProductAdditionalDetails();
            product.productAdditionalDetails.description = new List<object>(); //TODO ?????
            reservation.reservationProducts.product.Add(product);
        }
        foreach (Segment segment in iOrder.InboundSegments)
        {
            Product product = new Product();
            product.productType = eProductType.F.ToString();
            product.productId = segment.flightId.ToString();
            product.productClients = new ProductClients();
            product.productClients.productClient = new List<ProductClient>();
            foreach (Client client in ioClients)
            {
                ProductClient productClient = new ProductClient();
                productClient.clientRef = client.clientIndex;
                productClient.price = iClientToPrice[client.clientIndex];
                product.productClients.productClient.Add(productClient);
            }
            product.productAdditionalDetails = new ProductAdditionalDetails();
            product.productAdditionalDetails.description = new List<object>(); //TODO ?????
            reservation.reservationProducts.product.Add(product);
        }
        reservation.reservationAdditionalDetails = new ReservationAdditionalDetails();
        reservation.reservationAdditionalDetails.description = new List<object>(); //TODO ?????
        reservations.Add(reservation);
        return reservations;
    }

    private string getReferenceId(string iDealId, string iDealType)
    {
        //string[] substrings = iDealId.Split('_');

        //string dealId = iDealId.Remove()
        //return substrings[1];

        string referenceId = string.Empty;
        eDealType dealType = (eDealType)System.Enum.Parse(typeof(eDealType), iDealType);

        switch (dealType)
        {
            case eDealType.CHARTER:
                referenceId = iDealId;
                break;
            case eDealType.FLIGHT:
                string[] substrings = iDealId.Split('_');
                referenceId = substrings[1];
                break;
        }

        return referenceId;
    }

    private List<Client> createClientList(Dictionary<int, double?> iClientToPrice, FlightOrder iOrder, Dictionary<string, string> iTravellersDetails)
    {
        List<Client> clients = new List<Client>();
        int clientIndex = 1;

        addClients(AdultType, clients, ref clientIndex,
                    iOrder, iClientToPrice, iTravellersDetails);
        addClients(StudentType, clients, ref clientIndex,
                    iOrder, iClientToPrice, iTravellersDetails);
        addClients(YoungType, clients, ref clientIndex,
                    iOrder, iClientToPrice, iTravellersDetails);
        addClients(ChildType, clients, ref clientIndex,
                    iOrder, iClientToPrice, iTravellersDetails);
        addClients(InfantType, clients, ref clientIndex,
                    iOrder, iClientToPrice, iTravellersDetails);
        addClients(SeniorType, clients, ref clientIndex,
                    iOrder, iClientToPrice, iTravellersDetails);

        return clients;
    }

    private void addClients(string iTravellerType, List<Client> iClients, ref int ioClientIndex,
                        FlightOrder iOrder, Dictionary<int, double?> iClientToPrice, Dictionary<string, string> iTravellerDetails)
    {
        int numTravellers = 0;

        switch (iTravellerType)
        {
            case AdultType:
                numTravellers = iOrder.Adults;
                break;
            case StudentType:
                numTravellers = iOrder.Students;
                break;
            case YoungType:
                numTravellers = iOrder.Youngs;
                break;
            case ChildType:
                numTravellers = iOrder.Children;
                break;
            case InfantType:
                numTravellers = iOrder.Infants;
                break;
            case SeniorType:
                numTravellers = iOrder.Seniors;
                break;
        }

        for (int i = 1; i <= numTravellers; i++)
        {
            string priceStr = Utils.GetPassengerPrice(iTravellerType, iOrder.Deal);
            double? price = double.Parse(priceStr);
            //double? price = getTravellerPriceType(iOrder, iTravellerType);
            iClientToPrice.Add(ioClientIndex, price);
            Client client = new Client();
            string key = iTravellerType + "_" + i;
            client.firstName = iTravellerDetails["firstName_" + key];
            client.lastName = iTravellerDetails["lastName_" + key];
            client.clientIndex = ioClientIndex;
            ioClientIndex++;
            client.idType = eIdType.Passport.ToString();
            client.gender = iTravellerDetails["genderSelect_" + key];
            client.dateOfBirth = iTravellerDetails["dateOfBirth" + key];
            client.phoneNum = iTravellerDetails["phone_" + key];
            client.email = iTravellerDetails["email_" + key];
            iClients.Add(client);
        }
    }
}
