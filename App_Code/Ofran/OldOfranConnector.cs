using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Summary description for Ofran
/// </summary>
public class OldOfranConnector
{
    private OfranWs.OfranService mService = new OfranWs.OfranService();

    public OfranGetAgentLoginResponse GetAgentLogin(string iUsername, string iPassword, string iWebCustomerId)
    {
        OfranGetAgentLoginRequest req = new OfranGetAgentLoginRequest();
        req.Username = iUsername;
        req.Password = iPassword;
        req.WebCustomerID = iWebCustomerId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetAgentLogin(reqStr);
        OfranGetAgentLoginResponse res = Utils.Deserialize<OfranGetAgentLoginResponse>(result.InnerXml);

        return res;
    }

    public OfranGetCountriesListResponse GetCountriesList(string iWebCustomerId)
    {
        //string result = string.Empty;
        OfranGetCountriesListRequest req = new OfranGetCountriesListRequest();
        req.WebCustomerID = iWebCustomerId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = null;
        OfranGetCountriesListResponse res = null;

        try
        {
            result = mService.GetCountriesList(reqStr);
            res = Utils.Deserialize<OfranGetCountriesListResponse>(result.InnerXml);
            writeCommunicationToFiles(reqStr, result.InnerXml);
        }
        catch (Exception e)
        {
        }


        return res;
    }

    public OfranGetIatasResponse GetIatas(string iWebCustomerId)
    {
        OfranGetIatasResponse res = null;
        OfranGetIatasRequest req = new OfranGetIatasRequest();
        req.WebCustomerID = iWebCustomerId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetIatas(reqStr);

        try
        {
            res = Utils.Deserialize<OfranGetIatasResponse>(result.InnerXml);
            writeCommunicationToFiles(reqStr, result.InnerXml);
        }
        catch (Exception e)
        {

        }

        return res;
    }

    public OfranCarGroupbyCountryListResponse GetCarTypes(string iWebCustomerId)
    {
        OfranCarGroupbyCountryListResponse res = null;
        OfranCarGroupbyCountryListRequest req = new OfranCarGroupbyCountryListRequest();
        req.WebCustomerID = iWebCustomerId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetOfranCarGroupbyCountryList(reqStr);

        try
        {
            res = Utils.Deserialize<OfranCarGroupbyCountryListResponse>(result.InnerXml);
        }
        catch (Exception e)
        {

        }

        return res;
    }


    public OfranGetDynamicResultsResponse SearchCars(string iWebCustomerId, string iWebConsumerId, string iCountryId,
                           string iDriverAge, string iIsDirect, string iLanguageCode,
                           string iOfranCarGroupId, string iPickUpDate, string iPickUpHour,
                           string iPickUpIataId, string iDropoffDate, string iDropoffHour,
                           string iDropoffIataId, string iUniqueUserId)
    {
        OfranGetDynamicResultsRequest req = new OfranGetDynamicResultsRequest();
        req.WebConsumerId = iWebConsumerId;
        req.WebCustomerID = iWebCustomerId;
        req.CountryID = iCountryId;
        req.DriverAge = iDriverAge;
        req.IsDirect = iIsDirect;
        req.LanguageCode = iLanguageCode;
        req.OfranCarGroupid = iOfranCarGroupId;
        req.PickupDate = iPickUpDate;
        req.PickupHour = iPickUpHour;
        req.PickupIataID = iPickUpIataId;
        req.DropDate = iDropoffDate;
        req.DropHour = iDropoffHour;
        req.DropIataID = iDropoffIataId;
        req.UniqueUserID = iUniqueUserId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetDynamicResults(reqStr);

        try
        {
            OfranGetDynamicResultsResponse res = Utils.Deserialize<OfranGetDynamicResultsResponse>(result.OuterXml);
            writeCommunicationToFiles(reqStr, result.OuterXml);
            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("SearchCars: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetSupplierCarGroupIdResponse GetSupplierCarGroupIdResponse(string iCarGroupId)
    {
        OfranGetSupplierCarGroupIdRequest req = new OfranGetSupplierCarGroupIdRequest();
        req.SupplierCarGroupId = iCarGroupId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetSupplierCarGroupById(reqStr);

        try
        {
            OfranGetSupplierCarGroupIdResponse res = Utils.Deserialize<OfranGetSupplierCarGroupIdResponse>(result.InnerXml);
            writeCommunicationToFiles(reqStr, result.InnerXml);
            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetSupplierCarGroupIdResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetResultConditionsResponse GetResultConditions(string iWebCustomerId, string iLangCode, string iPriceCatalogId,
                                                                string iCarGroupId, OfranAdditionalProduct iProductDetails)
    {
        OfranGetResultConditionsRequest req = new OfranGetResultConditionsRequest();
        req.WebCustomerID = iWebCustomerId;
        req.LanguageCode = iLangCode;
        req.PriceCatalogID = iPriceCatalogId;
        req.SupplierCarGroupID = iCarGroupId;
        req.AdditionalProductsX = new OfranGetResultConditionsRequest.AdditionalProducts();
        req.AdditionalProductsX.Products = new OfranGetResultConditionsRequest.Products();
        req.AdditionalProductsX.Products.AdditionalProduct = iProductDetails;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetResultConditions(reqStr);

        try
        {
            OfranGetResultConditionsResponse res = Utils.Deserialize<OfranGetResultConditionsResponse>(result.InnerXml);
            writeCommunicationToFiles(reqStr, result.InnerXml);

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetResultConditions: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetPossibleUpgradesResponse GetPossibleUpgrades(string iWebCustomerId, string iWebConsumerId, string iPriceCatalogId,
                           string iDriverAge, string iIsDirect, string iLanguageCode,
                           string iSupplierCarGroupId, string iPickUpDate, string iPickUpHour,
                           string iPickUpIataId, string iDropoffDate, string iDropoffHour,
                           string iDropoffIataId, string iUniqueUserId, string iHandlingFee,
                           string iSupplierPricecatalogueId)
    {
        OfranGetPossibleUpgradesRequest req = new OfranGetPossibleUpgradesRequest();
        req.WebCustomerID = iWebCustomerId;
        req.WebConsumerId = iWebConsumerId;
        req.DriverAge = iDriverAge;
        req.DropoffDate = iDropoffDate;
        req.DropoffHour = iDropoffHour;
        req.DropoffStationID = iDropoffIataId;
        req.IsDirect = iIsDirect;
        req.Lang = iLanguageCode;
        req.PickupDate = iPickUpDate;
        req.PickupHour = iPickUpHour;
        req.PickupStationID = iPickUpIataId;
        req.PriceCatalogueID = iPriceCatalogId;
        req.SupplierCarGroupID = iSupplierCarGroupId;
        req.UniqueUserID = iUniqueUserId;
        req.HandlingFee = iHandlingFee;
        req.SupplierPriceCatalogueID = iSupplierPricecatalogueId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetPossibleUpgrades(reqStr);

        try
        {
            OfranGetPossibleUpgradesResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetPossibleUpgradesResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);
            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetPossiblieUpgrades: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetBasicProductsResponse GetBasicProducts(string iWebCustomerId, string iIsDirect, string iUniqueUserId,
                                                          string iDriverAge, string iPickUpDate, string iPickUpTime,
                                                          string iDropoffDate, string iDropoffTime, string iCurrencyId,
                                                          string iSupplierCarGroupId, string iSubContractId, string iPickUpCountryId,
                                                          string iWebConsumerId)
    {
        OfranGetBasicProductsRequest req = new OfranGetBasicProductsRequest();
        req.WebCustomerID = iWebCustomerId;
        req.IsDirect = iIsDirect;
        req.UniqueUserID = iUniqueUserId;
        req.DriverAge = iDriverAge;
        req.PickupDate = iPickUpDate;
        req.PickupHour = iPickUpTime;
        req.DropoffDate = iDropoffDate;
        req.DropoffHour = iDropoffTime;
        req.CurrencyID = iCurrencyId;
        req.SupplierCarGroupID = iSupplierCarGroupId;
        req.PickupCountryID = iPickUpCountryId;
        req.SubContractID = iSubContractId;
        req.WebConsumerId = iWebConsumerId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetBasicProducts(reqStr);

        try
        {
            OfranGetBasicProductsResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetBasicProductsResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetBasicProducts: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetPrebooksResponse GetPrebooks(string iSubContractId, string iLanguageCode)
    {
        OfranGetPrebooksRequest req = new OfranGetPrebooksRequest();
        req.SubContractId = iSubContractId;
        req.LanguageCode = iLanguageCode;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetPrebooks(reqStr);

        try
        {
            OfranGetPrebooksResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetPrebooksResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetPrebooks: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetTermsAndConditionsResponse GetTermsAndConditions(string iCountryId, string iLanguageCode)
    {
        OfranGetTermsAndConditionsRequest req = new OfranGetTermsAndConditionsRequest();
        req.DestinationID = iCountryId;
        req.Lang = iLanguageCode;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetTermsAndConditions(reqStr);

        try
        {
            OfranGetTermsAndConditionsResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetTermsAndConditionsResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetPrebooks: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetOptionalProductsResopnse GetOptionalProducts(string iWebCustomerId, string iIsDirect, string iUniqueUserId,
                                                          string iDriverAge, string iPickUpDate, string iPickUpTime,
                                                          string iDropoffDate, string iDropoffTime, string iCurrencyId,
                                                          string iSupplierCarGroupId, string iSubContractId, string iPickUpCountryId,
                                                          string iWebConsumerId)
    {
        OfranGetOptionalProductsRequest req = new OfranGetOptionalProductsRequest();
        req.WebCustomerID = iWebCustomerId;
        req.IsDirect = iIsDirect;
        req.UniqueUserID = iUniqueUserId;
        req.DriverAge = iDriverAge;
        req.PickupDate = iPickUpDate;
        req.PickupHour = iPickUpTime;
        req.DropoffDate = iDropoffDate;
        req.DropoffHour = iDropoffTime;
        req.CurrencyID = iCurrencyId;
        req.SupplierCarGroupID = iSupplierCarGroupId;
        req.PickupCountryID = iPickUpCountryId;
        req.SubContractID = iSubContractId;
        req.WebConsumerId = iWebConsumerId;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetOptionalProducts(reqStr);

        try
        {
            OfranGetOptionalProductsResopnse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetOptionalProductsResopnse>(result.OuterXml);
            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetBasicProducts: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetPriceDetailsDataResponse GetPriceDetailsData(OfranGetPriceDetailsDataRequest iRequest)
    {
        OfranGetPriceDetailsDataResponse res = null;
        string reqStr = Utils.Serialize(iRequest);
        XmlNode result = mService.GetPriceDetailsData(reqStr);

        try
        {
            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetPriceDetailsDataResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("OfranCreatePriceQuoteResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }



    public OfranCreatePriceQuoteResponse GetCreatePriceQuoteResponse(OfranCreatePriceQuoteRequest iRequest)
    {
        OfranCreatePriceQuoteResponse res = null;
        string reqStr = Utils.Serialize(iRequest);
        XmlNode result = mService.CreatePriceQuote(reqStr);

        try
        {
            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranCreatePriceQuoteResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("OfranCreatePriceQuoteResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranCreatePriceQuoteResponse CreatePriceQuote(string iWebCustomerId, string iIsDirect, string iUniqueUserId,
                                                          string iFirstName, string iLastName, string iTitle,
                                                          string iCountryId, string iPickUpIata, string iPickUpDate,
                                                          string iPickUpTime, string iDropoffIata, string iDropoffDate,
                                                          string iDropoffTime, string iDriverAge, string iSupplierCarGroupId,
                                                          string iSubContractId, string iPriceCatalogueId, string iCurrencyId,
                                                          string iSupplierPriceCatalogueId, string iBasicPrice, string iNettoPrice,
                                                          List<OfranAdditionalProduct> iBasicProducts, string iHandlingFee, string iCommission,
                                                          string iComissionPercent, string iVatFromComission, string iVatPercentFromComission,
                                                          string iDomesticVat, OfranCreatePriceQuoteRequest.CountryList iCountriesList, OfranCreatePriceQuoteRequest.PrebookList iPrebooksList,
                                                          string iFlightNum, string iPremiumStationCharge, string iDiscountPercent,
                                                          string iDiscount, bool iIsSendAdvertisement, string iLanguage,
                                                          string iWebConsumerId, string iIsLiveRate)

    {
        OfranCreatePriceQuoteRequest req = new OfranCreatePriceQuoteRequest();
        req.WebCustomerID = iWebCustomerId;
        req.IsDirect = iIsDirect;
        req.UniqueUserID = iUniqueUserId;
        req.FirstName = iFirstName;
        req.LastName = iLastName;
        req.Title = iTitle;
        req.CountryID = iCountryId;
        req.PickupStationID = iPickUpIata;
        req.PickupDate = iPickUpDate;
        req.PickupHour = iPickUpTime;
        req.DropoffStationID = iDropoffIata;
        req.DropoffDate = iDropoffDate;
        req.DropoffHour = iDropoffTime;
        req.DriverAge = iDriverAge;
        req.SupplierCarGroupID = iSupplierCarGroupId;
        req.SubContractId = iSubContractId;
        req.PriceCatalogueID = iPriceCatalogueId;
        req.CurrencyID = iCurrencyId;
        req.SupplierPriceCatalogueID = iSupplierPriceCatalogueId;
        req.BasicPrice = iBasicPrice;
        req.NetAmount = iNettoPrice;
        req.AdditionalProductsX = new OfranCreatePriceQuoteRequest.AdditionalProducts();
        req.AdditionalProductsX.Products = new OfranCreatePriceQuoteRequest.Products();
        req.AdditionalProductsX.Products.AdditionalProduct = iBasicProducts;
        req.HandlingFee = iHandlingFee;
        req.Commission = iCommission;
        req.ComissionPercent = iComissionPercent;
        req.Vat = iVatFromComission;
        req.VatPercent = iVatPercentFromComission;
        req.DomesticVat = iDomesticVat;
        req.CountriesList = iCountriesList;
        req.PrebooksList = iPrebooksList;
        req.FlightNum = iFlightNum;
        req.PremiumStationCharge = iPremiumStationCharge;
        req.DiscountPer = iDiscountPercent;
        req.Discount = iDiscount;
        req.SendAdvertisement = iIsSendAdvertisement.ToString().ToLower();
        req.IsConfirmed = "true";
        req.Lang = iLanguage;
        req.WebConsumerId = iWebConsumerId;
        //req.Live = iIsLiveRate;

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.CreatePriceQuote(reqStr);

        try
        {
            OfranCreatePriceQuoteResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranCreatePriceQuoteResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);
            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("GetBasicProducts: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetStationsListResponse GetStationsListResponse(string iWebCustomerID, string iPickupIataId, string iDropIataId,
                                                          string iPickupDate, string iPickupHour, string iDropDate,
                                                          string iDropHour, string iSupplierCarGroupId, string iSupplierPriceCatalogueId)
    {
        OfranGetStationsListRequest req = new OfranGetStationsListRequest
        {
            WebCustomerID = iWebCustomerID,
            PickupIataID = iPickupIataId,
            DropIataID = iDropIataId,
            PickupDate = iPickupDate,
            PickupHour = iPickupHour,
            DropDate = iDropDate,
            DropHour = iDropHour,
            SupplierCarGroupID = iSupplierCarGroupId,
            SupplierPriceCatalogueID = iSupplierPriceCatalogueId
        };

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetStationsList(reqStr);

        try
        {
            OfranGetStationsListResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetStationsListResponse>(result.InnerXml);
            }

            return res;
        }
        catch (Exception e)
        {
            throw new Exception("GetStationsList: <br>Message = " + e.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public OfranGetOneStationResponse GetOneStationResponse(string iStationId, string iDropOffDate)
    {
        OfranGetOneStationRequest req = new OfranGetOneStationRequest
        {
            StationID = iStationId,
            DropoffDate = iDropOffDate
        };

        string reqStr = Utils.Serialize(req);
        XmlNode result = mService.GetOneStation(reqStr);

        try
        {
            OfranGetOneStationResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetOneStationResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception e)
        {
            throw new Exception("GetOneStation: <br>Message = " + e.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }

    }

    public OfranCreateDynamicReservationResponse GetDynamicReservationResponse(OfranCreateDynamicReservationRequest iReq)
    {
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.CreateDynamicReservation(reqStr);

        try
         {
            OfranCreateDynamicReservationResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranCreateDynamicReservationResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("OfranCreateDynamicReservationResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public string GetClientIdFromOfranFullQuoteDetailsRequest(OfranGetPriceQuoteFullDetailsRequest iReq)
    {
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.GetPriceQuoteFullDetails(reqStr);

        try
        {
            OfranGetPriceQuoteFullDetailsResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetPriceQuoteFullDetailsResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res.Clientid;
        }
        catch (Exception ex)
        {
            throw new Exception("OfranCreateDynamicReservationResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }
    public OfranGetReservationPQListResponse GetOfranGetReservationPQListResponse(OfranGetReservationPQListRequest iReq)
    {
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.GetReservationPQList(reqStr);

        try
        {
            OfranGetReservationPQListResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranGetReservationPQListResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("OfranCreateDynamicReservationResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }


    public OfranCancelReservationResponse GetOfranCancelReservationResponse(OfranCancelReservationRequest iReq)
    {
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.CancelReservation(reqStr);

        try
        {
            OfranCancelReservationResponse res = null;

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                res = Utils.Deserialize<OfranCancelReservationResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }

            return res;
        }
        catch (Exception ex)
        {
            throw new Exception("OfranCreateDynamicReservationResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }
    }

    public object GetCarRentalCancelReservationResponse(Agency2000Ws_Test.eSourceTypes iSourceTypes, object iReq)
    {
        switch (iSourceTypes)
        {
            case Agency2000Ws_Test.eSourceTypes.Ofran:
                return GetOfranCancelReservationResponse((OfranCancelReservationRequest)iReq);
            default:
                return null;
        }
    }

    public OfranGetPriceQuoteFullDetailsResponse GetPriceQuoteFullDetailsResponse(OfranGetPriceQuoteFullDetailsRequest iReq)
    {
        OfranGetPriceQuoteFullDetailsResponse response = null;
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.GetPriceQuoteFullDetails(reqStr);

        try
        {

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                response = Utils.Deserialize<OfranGetPriceQuoteFullDetailsResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);

            }
        }
        catch (Exception ex)
        {
            throw new Exception("GetPriceQuoteFullDetailsResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }

        return response;
    }

    public OfranGetReservationFullDetailsResponse GetReservationFullDetailsResponse(OfranGetReservationFullDetailsRequest iReq)
    {
        OfranGetReservationFullDetailsResponse response = null;
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.GetReservationFullDetails(reqStr);

        try
        {

            if (!string.IsNullOrEmpty(result.InnerXml))
            {
                response = Utils.Deserialize<OfranGetReservationFullDetailsResponse>(result.InnerXml);
                writeCommunicationToFiles(reqStr, result.InnerXml);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("GetReservationFullDetailsResponse: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }

        return response;
    }
    
    public OfranSendVoucherResponse SendVoucher(OfranSendVoucherRequest iReq)
    {
        OfranSendVoucherResponse response = null;
        string reqStr = Utils.Serialize(iReq);
        XmlNode result = mService.SendVoucher(reqStr);

        try
        {

            if (!string.IsNullOrEmpty(result.OuterXml))
            {
                response = Utils.Deserialize<OfranSendVoucherResponse>(result.OuterXml);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("SendVoucher: <br>Message = " + ex.Message + "<br>req = " + reqStr + ",<br> =========================== <br> res =  " + result.InnerXml);
        }

        return response;
    }


    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeCommunicationToFiles(string iRequest, string iResponse)
    {
        //var st = new StackTrace();
        //var sf = st.GetFrame(1);
        //string currentMethodName = Regex.Replace(sf.GetMethod().Name, "(.*)(Request|Response)(?i)", "$1");
        //// DEBUG
        //using (StreamWriter streamRequest = new StreamWriter(HttpContext.Current.Server.MapPath("~\\OfranXmls\\" + currentMethodName + "Request.xml")))
        //{
        //    streamRequest.WriteLine(formatXml(iRequest));

        //}
        //using (StreamWriter streamResult = new StreamWriter(HttpContext.Current.Server.MapPath("~\\OfranXmls\\" + currentMethodName + "Response.xml")))
        //{
        //    streamResult.WriteLine(formatXml(iResponse));
        //}



    }

    private string formatXml(string iXml)
    {
        string result = "";

        MemoryStream mStream = new MemoryStream();
        XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
        XmlDocument document = new XmlDocument();

        try
        {
            // Load the XmlDocument with the XML.
            document.LoadXml(iXml);

            writer.Formatting = Formatting.Indented;

            // Write the XML into a formatting XmlTextWriter
            document.WriteContentTo(writer);
            writer.Flush();
            mStream.Flush();

            // Have to rewind the MemoryStream in order to read
            // its contents.
            mStream.Position = 0;

            // Read MemoryStream contents into a StreamReader.
            StreamReader sReader = new StreamReader(mStream);

            // Extract the text from the StreamReader.
            string formattedXml = sReader.ReadToEnd();

            result = formattedXml;
        }
        catch (XmlException)
        {
            // Handle the exception
        }

        mStream.Close();
        writer.Close();

        return result;
    }
}
