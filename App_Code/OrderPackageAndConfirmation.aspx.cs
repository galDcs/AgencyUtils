//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Configuration;
//using System.Globalization;

//public partial class OrderPackageAndConfirmation : System.Web.UI.Page
//{
//    const int mAgencyIdToSend = 77;
//    const int mSystemTypeToSend = 3;

//    public string mPackageId;
//    public const string ddlTitle = "ddlTitle_";
//    public const string tbAdultFirstName = "tbAdultFirstName_";
//    public const string tbAdultLastName = "tbAdultLastName_";
//    public const string tbChildFirstName = "tbChildFirstName_";
//    public const string tbChildLastName = "tbChildLastName_";
//    public const string tbInfantFirstName = "tbInfantFirstName_";
//    public const string tbInfantLastName = "tbInfantLastName_";
//    public const string tbTravellerId = "tbTravellerId_";
//    public const string tbTravellerMail = "tbTravellerMail_";
//    public const string tbTravellerPhone = "tbTravellerPhone_";
//    public const string travellerDob = "travellerDob_";

//    private Package mPackageManager;
//    private bool isMiniPrices = true;

//    public eLanguage mLang
//    {
//        get
//        {
//            return ((MasterPage)Master).mLang;
//        }
//    }

//    public string mLangStr
//    {
//        get
//        {
//            return ((int)mLang).ToString();
//        }
//    }

//    public Package mPackage
//    {
//        get
//        {
//            if (mPackageManager == null)
//            {
//                try
//                {
//                    mPackageManager = Utils.GetPackage(mPackageId, isMiniPrices, mLang);
//                }
//                catch (Exception ex)
//                {
//                    Logger.Log("1 execption = " + ex.Message);
//                    Logger.Log("1 execption = " + ex.StackTrace);
//                }
//            }

//            return mPackageManager;
//        }
//        set
//        {
//            mPackageManager = value;
//        }
//    }

//    protected void Page_Load(object sender, EventArgs e)
//    {
//        Agency2000WS x = new Agency2000WS();
//        string docketId = string.Empty;
//        string attractionPriceId = string.Empty;
//        string clerkId = "1";

//        setAgencyData();
//        mPackageId = Request.QueryString["PackageId"];

//        if (!Page.IsPostBack)
//        {
//            if (mPackage.Type != "3")
//            {
//                loadCompositions(mLangStr);
//                fillPagePackageContent();
//            }
//            else
//            {
//                //TODO
//            }
//        }

//        List<AgencyTraveller> travellers = new List<AgencyTraveller>();
//        travellers.Add(new AgencyTraveller("Testchen", "Testchen", string.Empty, string.Empty, string.Empty, string.Empty));
//        //Empty docketId will create new docket.
//        //x.CreateAttractionInDocket(mAgencyIdToSend, mSystemTypeToSend, "Agency2000", "11071964",
//        //                           travellers, docketId, attractionPriceId, mPackage.CurrencyId, mPackage.FromDate.Value,
//        //                           mPackage.ToDate.Value, clerkId, false, mLangStr);
//        if (!string.IsNullOrEmpty(Request.Form["pagefunc"]))
//        {
//            switch (Request.Form["pagefunc"])
//            {
//                case "order":
//                    makeOrder();
//                    break;
//            }
//        }
//        //    //loadPackage();
//        //    switch (Request.Form["pagefunc"].ToString())
//        //    {
//        //        case "compositionSelected":
//        //            if (!string.IsNullOrEmpty(Request.Form["trigger"].ToString()))
//        //            {
//        //                if (pagefuncServer.Value != "done")
//        //                {
//        //                    pagefuncServer.Value = "done";
//        //                    string selectedCompositionId = Request.Form["trigger"].ToString();


//        //                }
//        //            }
//        //        break;
//        //    }
//        //}
//    }

//    private void fillPagePackageContent()
//    {
//        spanHeader.InnerHtml = mPackage.Header;
//        spanDates.InnerHtml = mPackage.FromDate.Value.ToString("dd/MM/yy") + " - " + mPackage.ToDate.Value.ToString("dd/MM/yy");
//        spanTotalPrice.InnerHtml = mPackage.GetTotalPrice().ToString() + Utils.GetCurrencySign(mPackage.CurrencyId);
//    }

//    private void setAgencyData()
//    {
//        HttpCookie cookie = new HttpCookie("Agency2000");
//        cookie.Values["AgencyId"] = "7";
//        cookie.Values["SystemType"] = "1";
//        cookie.Values["ClerkName"] = "Agency2000";
//        Request.Cookies.Add(cookie);

//        string agencyId = "7";//Response.Cookies["Agency2000"]["AgencyId"];
//        string systemType = "1";//Response.Cookies["Agency2000"]["SystemType"];

//        DAL_SQL.ConnStr = ConfigurationManager.AppSettings["CurrentAgencyDBConnStr"];
//        DAL_SQL.ConnStr = DAL_SQL.ConnStr.Replace("^agencyId^", agencyId.PadLeft(4, '0'));
//        DAL_SQL.ConnStr = DAL_SQL.ConnStr.Replace("^systemType^", ((systemType == "3") ? "INN" : (systemType == "2") ? "OUT" : "ICC"));
//    }

//    //DataBind for the DropDownList
//    private void loadCompositions(string iLangStr)
//    {
//        DataSet dsServices = DAL_SQL_Helper.GetCompositions(iLangStr);

//        if (Utils.IsDataSetRowsNotEmpty(dsServices))
//        {
//            ddlComposition.Items.Clear();
//            ddlComposition.DataSource = dsServices.Tables[0];
//            ddlComposition.DataTextField = dsServices.Tables[0].Columns["name"].ToString();
//            ddlComposition.DataValueField = dsServices.Tables[0].Columns["id"].ToString();
//            ddlComposition.DataBind();

//            for (int i = 0; i < ddlComposition.Items.Count; i++)
//            {
//                ddlComposition.Items[i].Attributes.Add("adults", dsServices.Tables[0].Rows[i]["adults"].ToString());
//                ddlComposition.Items[i].Attributes.Add("children", dsServices.Tables[0].Rows[i]["children"].ToString());
//                ddlComposition.Items[i].Attributes.Add("babies", dsServices.Tables[0].Rows[i]["babies"].ToString());
//            }

//            ddlComposition.Items.Insert(0, new ListItem("Select", "0"));
//        }
//    }

//    private void makeOrder()
//    {
//        Traveller traveller = new Traveller();
//        string invalidDetails = string.Empty;
//        bool isFirstTravellerSet = false;
//        int adultsNum = 0, childrenNum = 0, infantsNum = 0;
//        string ageGroup = string.Empty;


//        howManyTravellers(ref adultsNum, ref childrenNum, ref infantsNum);

//        ageGroup = "adult";
//        for (int i = 0; i < adultsNum; i++)
//        {
//            if (!verifyDetailsFromClientAndUpdate(ref isFirstTravellerSet, i, traveller, ageGroup, ref invalidDetails))
//            {
//                adultsNum = 0;
//                childrenNum = 0;
//                infantsNum = 0;
//                popUpMessage(invalidDetails);
//            }
//        }

//        ageGroup = "child";
//        for (int i = 0; i < childrenNum; i++)
//        {
//            if (!verifyDetailsFromClientAndUpdate(ref isFirstTravellerSet, i, traveller, ageGroup, ref invalidDetails))
//            {
//                adultsNum = 0;
//                childrenNum = 0;
//                infantsNum = 0;
//                popUpMessage(invalidDetails);
//            }
//        }

//        ageGroup = "infant";
//        for(int i = 0; i < infantsNum; i++)
//        {
//            if (!verifyDetailsFromClientAndUpdate(ref isFirstTravellerSet, i, traveller, ageGroup, ref invalidDetails))
//            {
//                adultsNum = 0;
//                childrenNum = 0;
//                infantsNum = 0;
//                popUpMessage(invalidDetails);
//            }
//        }

//        //TODO: add the traveller & escorts to DB
//        // //
//        Agency2000WS proxy = new Agency2000WS();
        
//    }

//    private void howManyTravellers(ref int oAdultsNum, ref int oChildrenNum, ref int oInfantsNum)
//    {
//        oAdultsNum = 0;
//        oChildrenNum = 0;
//        oInfantsNum = 0;

//        foreach (string key in Request.Form)
//        {
//            if (key.Contains("AdultFirstName"))
//            {
//                oAdultsNum++;
//            }
//            else if (key.Contains("ChildFirstName"))
//            {
//                oChildrenNum++;
//            }
//            else if (key.Contains("InfantFirstName"))
//            {
//                oInfantsNum++;
//            }
//        }
//    }

//    private void verifyAndUpdateNames(ref string oFirstName, ref string oLastName, int iIndex, string iAgeGroup)
//    {
//        string keyFirstName = string.Empty;
//        string keyLastName = string.Empty;

//        switch (iAgeGroup)
//        {
//            case "adult":
//                keyFirstName = string.Format(tbAdultFirstName + iIndex);
//                keyLastName = string.Format(tbAdultLastName + iIndex);
//                break;
//            case "child":
//                keyFirstName = string.Format(tbChildFirstName + iIndex);
//                keyLastName = string.Format(tbChildLastName + iIndex);
//                break;
//            case "infant":
//                keyFirstName = string.Format(tbInfantFirstName + iIndex);
//                keyLastName = string.Format(tbInfantLastName + iIndex);
//                break;
//        }

//        if (Validator.isValidName(Request.Form[keyFirstName]))
//        {
//            oFirstName = Request.Form[keyFirstName];
//        }
//        else
//        {
//            oFirstName = string.Empty;
//        }

//        if (Validator.isValidName(Request.Form[keyLastName]))
//        {
//            oLastName = Request.Form[keyLastName];
//        }
//        else
//        {
//            oLastName = string.Empty;
//        }
//    }

//    private void verifyAndUpdateExtraDetails(ref string oId, ref string oMail, ref string oPhone, ref string oDateOfBirth)
//    {
//        string key = string.Format(tbTravellerId + "0");

//        if (Validator.isValidId(Request.Form[key]))
//        {
//            oId = Request.Form[key];
//        }
//        else
//        {
//            oId = string.Empty;
//        }

//        key = string.Format(tbTravellerMail + "0");
//        if (Validator.isValidMail(Request.Form[key]))
//        {
//            oMail = Request.Form[key];
//        }
//        else
//        {
//            oMail = string.Empty;
//        }

//        key = string.Format(tbTravellerPhone + "0");
//        if (Validator.isValidPhoneNumber(Request.Form[key]))
//        {
//            oPhone = Request.Form[key];
//        }
//        else
//        {
//            oPhone = string.Empty;
//        }

//        key = string.Format(travellerDob + "0");
//        if (Validator.isValidDateOfBirth(Request.Form[key]))
//        {
//            oDateOfBirth = Request.Form[key];
//        }
//        else
//        {
//            oDateOfBirth = string.Empty;
//        }
//    }

//    private void updateTravellerInfo(Traveller oTraveller, string iFirstName, string iLastName,
//                                    string iId, string iMail, string iPhone,
//                                    string iDateOfBirth)
//    {
//        oTraveller.FirstName = iFirstName;
//        oTraveller.LastName = iLastName;
//        oTraveller.Id = iId;
//        oTraveller.Mail = iMail;
//        oTraveller.Phone = iPhone;
//        DateTime dateOfBirth;
//        DateTime.TryParse(iDateOfBirth, out dateOfBirth);
//        oTraveller.DateOfBirth = dateOfBirth;
//    }

//    private string getGender(string key)
//    {
//        string gender = string.Empty;

//        if(Request.Form[key] == "Mr.")
//        {
//            gender = "male";
//        }
//        else if(Request.Form[key] == "Ms.")
//        {
//            gender = "female";
//        }

//        return gender;
//    }

//    private bool verifyDetailsFromClientAndUpdate(ref bool ioIsFirstTravellerSet, int iIndex, Traveller oTraveller, string iAgeGroup, ref string oErrorMessage)
//    {
//        bool isValid = true;

//        string firstName = string.Empty;
//        string lastName = string.Empty;
//        string gender = string.Empty;
//        string key = string.Empty;

//        key = string.Format(ddlTitle + iIndex);
//        gender = getGender(key);
//        verifyAndUpdateNames(ref firstName, ref lastName, iIndex, iAgeGroup);
//        if (string.IsNullOrEmpty(firstName))
//        {
//            isValid = false;
//            oErrorMessage += Utils.GetTextFromFile("ErrorFirstNameInvalid", mLang);
//            oErrorMessage += "<br />";
//        }
//        else if (string.IsNullOrEmpty(lastName))
//        {
//            isValid = false;
//            oErrorMessage += Utils.GetTextFromFile("ErrorLastNameInvalid", mLang);
//            oErrorMessage += "<br />";
//        }
//        else
//        {
//            if (!ioIsFirstTravellerSet)
//            {
//                string id = string.Empty;
//                string mail = string.Empty;
//                string phone = string.Empty;
//                string dateOfBirth = string.Empty;

//                verifyAndUpdateExtraDetails(ref id, ref mail, ref phone, ref dateOfBirth);
//                if (string.IsNullOrEmpty(id))
//                {
//                    isValid = false;
//                    oErrorMessage += Utils.GetTextFromFile("ErrorIdInvalid", mLang);
//                    oErrorMessage += "<br />";
//                }
//                else if (string.IsNullOrEmpty(mail))
//                {
//                    isValid = false;
//                    oErrorMessage += Utils.GetTextFromFile("ErrorMailInvalid", mLang);
//                    oErrorMessage += "<br />";
//                }
//                else if (string.IsNullOrEmpty(phone))
//                {
//                    isValid = false;
//                    oErrorMessage += Utils.GetTextFromFile("ErrorPhoneInvalid", mLang);
//                    oErrorMessage += "<br />";
//                }
//                else if (string.IsNullOrEmpty(dateOfBirth))
//                {
//                    isValid = false;
//                    oErrorMessage += Utils.GetTextFromFile("ErrorDateOfBirthInvalid", mLang);
//                    oErrorMessage += "<br />";
//                }
//                else
//                { //everything is valid
//                    updateTravellerInfo(oTraveller, firstName, lastName, id, mail, phone, dateOfBirth);
//                    ioIsFirstTravellerSet = true;
//                }
//            }
//            else
//            {
//                updateEscortDetails(oTraveller, firstName, lastName, gender);
//            }
//        }

//        return isValid;
//    }

//    private void updateEscortDetails(Traveller oTraveller, string iFirstName, string iLastName, string iGender)
//    {
//        oTraveller.mEscorts.Add(new Traveller.Escort(iLastName, iFirstName, string.Empty, iGender));
//    }

//    private void popUpMessage(string iMessage)
//    {
//        ClientScript.RegisterStartupScript(Page.GetType(), "Popup", "ShowPopup('" + iMessage + "');", true);
//    }
//}