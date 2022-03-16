using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


public enum eIncomeType
{
    COM_INC_VAT = 1,
    COM_PLUS_VAT = 2,
    COM_VAT_ZERO = 3,
    MU_INC_VAT = 4,
    MU_PLUS_VAT = 5,
    MU_VAT_ZERO = 6
}

public enum eCompany
{
	FlyingCarpet = 1, 
	OphirTours = 2, 
	KalNofesh = 3,
	BSP = 40,
	
	None = 999
}

public enum eCurrency
{
    NIS = 1
}

public class BundleRow
{
	private eCompany mCompany = eCompany.None;
    readonly string mDateFormat = "dd-MMM-yy";
	private bool mIsUsingSubsid = false;
	
    public int mId { set; get; }
    public string mDocketId { set; get; }
    public decimal mAmount { set; get; }
    public double mVatPercent { set; get; }

    //Amount of the Vat from total amount. (from <mAmount>)
    public decimal mVatValue { set; get; }
    public decimal mCommision { set; get; }
    public decimal mCommisionValue { set; get; }
    public decimal mCommisionVat { set; get; }
    //Netto to supplier
    public decimal mToSupplier { set; get; }
    public decimal mToSupplierVat { set; get; }
    //Amount of money that goes to clerk
    public decimal mToClerk { set; get; }
    public decimal mToClerkVat { set; get; }
    public decimal mToClerkPercent { set; get; }
    public decimal mTotalSupplier { set; get; }
    public double mExchangeRateUsd { set; get; }
    public double mExchangeRateNis { set; get; }
    //1 = NIS
    public eCurrency mCurrencyId { set; get; }
    //Total amount
    public decimal mPrice { set; get; }
    public decimal mMarkUp { set; get; }
    public decimal mMarkUpVat { set; get; }
    public DateTime mCdate { set; get; }
    public DateTime mLastUpdateDate { set; get; }
    public eIncomeType mIncomeType { set; get; }
    public decimal mSubsid { set; get; }
    public decimal mTravPay { set; get; }
    public string mFourOneSeven { set; get; }
    public int mGovConnectedVoucher { set; get; }
    public int mGovIndicator { set; get; }
    public DateTime mGovVoucherCancelDate { set; get; }
    public int mGovOrderId { set; get; }
    public DateTime mFromDate { set; get; }
    public DateTime mToDate { set; get; }
    public string mPayToSupplier { set; get; }
    public string mErkevType { set; get; }
    
    public BundleRow()
    {
        //All get default values. (0)
    }

    public BundleRow(decimal iBrutto, decimal iNetto, string iIncomeType, string iVatPercent)
    {
        decimal brutto = iBrutto;
        decimal netto = iNetto;
        mVatPercent = double.Parse(iVatPercent);
        mIncomeType = (eIncomeType)(int.Parse(iIncomeType));

        setPrices(brutto, netto);
    }

    public BundleRow(decimal iBrutto, decimal iNetto, decimal iTravPay, decimal iMarkUp,
                    string iIncomeType, string iVatPercent, bool isEilat, 
                    DateTime iFromDate, DateTime iToDate, eCompany company)
	{
		mCompany = company;
        decimal brutto = iBrutto;
        decimal netto = iNetto;
        
		if (isEilat)
		{
			iVatPercent = "0";
		}

        mVatPercent = double.Parse(iVatPercent);
        mIncomeType = (eIncomeType)(int.Parse(iIncomeType));
        mTravPay = iTravPay;
		mMarkUp = iMarkUp;
		
		switch (company)
		{
            case eCompany.KalNofesh:
                setPricesKalNofesh(brutto, netto);

                break;
			case eCompany.FlyingCarpet:
                setPrices(brutto, netto);
                break;
			case eCompany.OphirTours:
				setPricesOphirTours(brutto, netto);
				break;
			
			default:
				break;
		}
	}
    public BundleRow(decimal iBrutto, decimal iNetto, string iIncomeType, string iVatPercent, bool isEilat, eCompany company)
	{
		mCompany = company;
        decimal brutto = iBrutto;
        decimal netto = iNetto;
		
		if (isEilat)
		{
			iVatPercent = "0";
		}

        mVatPercent = double.Parse(iVatPercent);
        mIncomeType = (eIncomeType)(int.Parse(iIncomeType));
		
		switch (company)
		{
			case eCompany.FlyingCarpet:
                setPrices(brutto, netto);
                break;
			case eCompany.OphirTours:
				setPricesOphirTours(brutto, netto);
				break;
			
			default:
				break;
		}
	}
	
    public BundleRow(BundleRow bundleRow)
    {
        mId = bundleRow.mId;
        mDocketId = bundleRow.mDocketId;
        mAmount = bundleRow.mAmount;
        mVatPercent = bundleRow.mVatPercent;
        mVatValue = bundleRow.mVatValue;
        mCommision = bundleRow.mCommision;
        mCommisionValue = bundleRow.mCommisionValue;
        mCommisionVat = bundleRow.mCommisionVat;
        mToSupplier = bundleRow.mToSupplier;
        mToSupplierVat = bundleRow.mToSupplierVat;
        mToClerk = bundleRow.mToClerk;
        mToClerkVat = bundleRow.mToClerkVat;
        mToClerkPercent = bundleRow.mToClerkPercent;
        mTotalSupplier = bundleRow.mTotalSupplier;
        mExchangeRateUsd = bundleRow.mExchangeRateUsd;
        mExchangeRateNis = bundleRow.mExchangeRateNis;
        mCurrencyId = bundleRow.mCurrencyId;
        mPrice = bundleRow.mPrice;
        mMarkUp = bundleRow.mMarkUp;
        mMarkUpVat = bundleRow.mMarkUpVat;
        mCdate = bundleRow.mCdate;
        mLastUpdateDate = bundleRow.mLastUpdateDate;
        mIncomeType = bundleRow.mIncomeType;
        mSubsid = bundleRow.mSubsid;
        mTravPay = bundleRow.mTravPay;
        mFourOneSeven = bundleRow.mFourOneSeven;
        mGovConnectedVoucher = bundleRow.mGovConnectedVoucher;
        mGovIndicator = bundleRow.mGovIndicator;
        try
        {
            mGovVoucherCancelDate = bundleRow.mGovVoucherCancelDate;
        }
        catch(Exception ex)
        {

        }
        mGovOrderId = bundleRow.mGovOrderId;

        mPayToSupplier = bundleRow.mPayToSupplier;
        mFromDate = bundleRow.mFromDate;
        mToDate = bundleRow.mToDate;
        mErkevType = bundleRow.mErkevType;
    }

	public BundleRow(double iBrutto, double iNetto, string iIncomeType,
                     double iBundleCommisionValue, string iVatPercent, bool isEilat,
                     eCompany company, double iBundleTax, double iBundleMarkUp,
                     double iBundlePrice, double iTotalSupplier)
    {
        mCompany = company;
        double brutto = iBrutto;
        double netto = iNetto;
		mTotalSupplier = (decimal)iTotalSupplier;
        mVatPercent = 0;
        mIncomeType = (eIncomeType)(int.Parse(iIncomeType));
        mCommisionValue = (decimal)iBundleCommisionValue;
        mMarkUp = (decimal)iBundleMarkUp;
        //mTax = (decimal)iBundleTax;
        mPrice = (decimal)iBundlePrice;

        switch (company)
        {
            case eCompany.BSP:
                setPricesBSP(brutto, netto);
                break;
            default:
                break;
        }
    }

    private void setPricesBSP(double iAmountBrutto, double iAmountNetto)
    {
        mVatPercent = 0;
        mVatValue = 0; 
        mSubsid = 0;
        mCommisionValue = mCommisionValue;
        mCommision = Math.Round((mCommisionValue / mPrice), 2) * 100;
        mCommisionVat = 0;
        mToSupplier = (decimal)mTotalSupplier - mCommisionValue;
        mToSupplierVat = 0;
        mToClerk = Math.Round(mCommisionValue + mMarkUp + mMarkUpVat, 2); //Gain
        mToClerkPercent = Math.Round(mToClerk / (decimal)iAmountBrutto, 2) * 100;
        mToClerkVat = 0;
        mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
    }
	
    public BundleRow(int iId, string iDocketId, decimal iAmount, double iVatPercent, decimal iVatValue, decimal iCommision, decimal iCommisionValue,
                     decimal iCommisionVat, decimal iToSupplier, decimal iToSupplierVat, decimal iToClerk, decimal iToClerkVat,
                     decimal iToClerkPercent, decimal iTotalSupplier, double iExchangeRateUsd, double iExchangeRateNis, eCurrency iCurrencyId,
                     decimal iPrice, decimal iMarkUp, decimal iMarkUpVat, DateTime iCdate, DateTime iLastUpdateDate, eIncomeType iIncomeType,
                     decimal iSubsid, decimal iTravPay, string iFourOneSeven, int iGovConnectedVoucher, int iGovIndicator, DateTime iGovVoucherCancelDate, int iGovOrderId, 
                     string iPatToSupplierId, DateTime iFromDate, DateTime iToDate, string iErkevType)
    {
        mId = iId;
        mDocketId = iDocketId;
        mAmount = iAmount;
        mVatPercent = iVatPercent;
        mVatValue = iVatValue;
        mCommision = iCommision;
        mCommisionValue = iCommisionValue;
        mCommisionVat = iCommisionVat;
        mToSupplier = iToSupplier;
        mToSupplierVat = iToSupplierVat;
        mToClerk = iToClerk;
        mToClerkVat = iToClerkVat;
        mToClerkPercent = iToClerkPercent;
        mTotalSupplier = iTotalSupplier;
        mExchangeRateUsd = iExchangeRateUsd;
        mExchangeRateNis = iExchangeRateNis;
        mCurrencyId = iCurrencyId;
        mPrice = iPrice;
        mMarkUp = iMarkUp;
        mMarkUpVat = iMarkUpVat;
        mCdate = iCdate;
        mLastUpdateDate = iLastUpdateDate;
        mIncomeType = iIncomeType;
        mSubsid = iSubsid;
        mTravPay = iTravPay;
        mFourOneSeven = iFourOneSeven;
        mGovConnectedVoucher = iGovConnectedVoucher;
        mGovIndicator = iGovIndicator;
        mGovVoucherCancelDate = iGovVoucherCancelDate;
        mGovOrderId = iGovOrderId;

        mPayToSupplier = iPatToSupplierId;
        mFromDate = iFromDate;
        mToDate = iToDate;
        mErkevType = iErkevType;
    }

    public BundleRow(DataRow bundleRow)
    {
        mId =                    tryToParseToInt(bundleRow["id"], "id");
        mDocketId =              bundleRow["docket_id"].ToString();
        mAmount =                tryToParseToDecimal(bundleRow["Amount"], "Amount");
        mVatPercent =            tryToParseToDouble(bundleRow["vat_percent"],"vat_percent");
        mVatValue =              tryToParseToDecimal(bundleRow["vat_value"],"vat_value");
        mCommision =             tryToParseToDecimal(bundleRow["commision"],"commision");
        mCommisionValue =        tryToParseToDecimal(bundleRow["commision_value"],"commision_value");
        mCommisionVat =          tryToParseToDecimal(bundleRow["commision_vat"],"commision_vat");
        mToSupplier =            tryToParseToDecimal(bundleRow["to_supplier"],"to_supplier");
        mToSupplierVat =         tryToParseToDecimal(bundleRow["to_supplier_vat"],"to_supplier_vat");
        mToClerk =               tryToParseToDecimal(bundleRow["to_clerk"],"to_clerk");
        mToClerkVat =            tryToParseToDecimal(bundleRow["to_clerk_vat"],"to_clerk_vat");
        mToClerkPercent =        tryToParseToDecimal(bundleRow["to_clerk_percent"],"to_clerk_percent");
        mTotalSupplier =         tryToParseToDecimal(bundleRow["total_supplier"],"total_supplier");
        mExchangeRateUsd =       tryToParseToDouble(bundleRow["xchange_rate_usd"],"xchange_rate_usd"); 
        mExchangeRateNis =       tryToParseToDouble(bundleRow["xchange_rate_nis"],"xchange_rate_nis");;
        mCurrencyId =            (eCurrency)int.Parse(bundleRow["currency_id"].ToString());
        mPrice =                 tryToParseToDecimal(bundleRow["price"],"price");
        mMarkUp =                tryToParseToDecimal(bundleRow["mark_up"],"mark_up");
        mMarkUpVat =             tryToParseToDecimal(bundleRow["xchange_rate_nis"],"xchange_rate_nis");
        mCdate =                 DateTime.Parse(bundleRow["cdate"].ToString());
        mLastUpdateDate =        DateTime.Parse(bundleRow["last_update_date"].ToString());
        mIncomeType =            (eIncomeType)int.Parse(bundleRow["income_type"].ToString());
        mSubsid =                tryToParseToDecimal(bundleRow["subsid"],"subsid");
        mTravPay =               tryToParseToDecimal(bundleRow["trav_pay"],"trav_pay");

        mFourOneSeven = bundleRow["four_one_seven"].ToString();

        try
        {
            mGovConnectedVoucher = tryToParseToInt(bundleRow["gov_connected_voucher_number"], "gov_connected_voucher_number");
        }
        catch(Exception ex)
        {

        }
        mGovIndicator = tryToParseToInt(bundleRow["gov_indicator_id"], "gov_indicator_id");

        //mGovVoucherCancelDate =  DateTime.Parse(bundleRow["gov_voucher_cancel_date"].ToString());
        mGovOrderId =            tryToParseToInt( bundleRow["gov_order_id"], "gov_order_id");

        mFromDate = DateTime.Parse(bundleRow["from_date"].ToString());
        mToDate = DateTime.Parse(bundleRow["to_date"].ToString());
        mPayToSupplier = bundleRow["pay_to_supplier_id"].ToString();
        mErkevType = bundleRow["erkev_type"].ToString();

        //Change the income type according to Yossi.
        setIncomeTypes();
    }

    private double tryToParseToDouble(object iVal, string iValueName)
    {
        double retVal = -1.00;

        if (iVal != null)
        {
            if (!double.TryParse(iVal.ToString(), out retVal))
            {
                throw new Exception("Param Name: " + iValueName);
            }
        }

        return retVal;
    }

    private decimal tryToParseToDecimal(object iVal, string iValueName)
    {
        decimal retVal = -1.00M;

        if (iVal != null)
        {
            if (!decimal.TryParse(iVal.ToString(), out retVal))
            {
                throw new Exception("Param Name: " + iValueName);
            }
        }

        return retVal;
    }

    private int tryToParseToInt(object iVal, string iValueName)
    {
        int retVal = -1;

        if (iVal != null)
        {
            if (!int.TryParse(iVal.ToString(), out retVal))
            {
                throw new Exception("Param Name: " + iValueName);
            }
        }

        return retVal;
    }

    private void setIncomeTypes()
    {
        switch (mIncomeType)
        {
            case eIncomeType.COM_INC_VAT:
                mIncomeType = eIncomeType.MU_INC_VAT;
                break;

            case eIncomeType.COM_PLUS_VAT:
                mIncomeType = eIncomeType.MU_PLUS_VAT;
                break;

            case eIncomeType.COM_VAT_ZERO:
                mIncomeType = eIncomeType.MU_VAT_ZERO;
                break;

            default:
                break;
        }
    }

    public void setPrices(decimal iAmountBrutto, decimal iAmountNetto)
    {
        decimal extraPay = 0;
        decimal commisionDecimal;
        double origVat = mVatPercent;

        switch (mIncomeType)
        {
            case eIncomeType.COM_INC_VAT: //1
            case eIncomeType.COM_PLUS_VAT: //2
                commisionDecimal = mCommision / 100;
                break;

            case eIncomeType.COM_VAT_ZERO: //3
                commisionDecimal = mCommision / 100;
                mVatPercent = 0;
                break;

                //There is no commision in flying shikum.
            case eIncomeType.MU_INC_VAT: //4
            case eIncomeType.MU_PLUS_VAT: //5
                commisionDecimal = 0;
                break;

            case eIncomeType.MU_VAT_ZERO: //6
                commisionDecimal = 0;
                mVatPercent = 0;
                break;

            default:
                throw new Exception("Wrong income_type = " + (int)mIncomeType);
        }

        extraPay = (mTravPay != 0) ? mTravPay : (mAmount - mSubsid);
		if (iAmountBrutto != 0.0M)
		{
			//calculated by brutto
			mAmount = iAmountBrutto;
			mPrice = iAmountBrutto;
			mTotalSupplier = iAmountBrutto;
			mVatValue = Math.Round(getVatAmountOf(iAmountBrutto),2);
	
			mSubsid = iAmountBrutto;//new brutto
	
			//calculated by netto
			mToSupplier = iAmountNetto;
			mToSupplierVat = Math.Round(getVatAmountOf(mToSupplier),2);
			
			//Calculate by netoo and brutto        
			mToClerk = Math.Round(getAmountWithoutVatOf(iAmountBrutto - iAmountNetto),2);
			if (Math.Abs(mToClerk - (int)mToClerk) > 0.99M)
				mToClerk = Math.Round(mToClerk, 2);
			mToClerkVat = Math.Round(getVatAmountOf(iAmountBrutto - iAmountNetto),2);
			mToClerkPercent = Math.Round(mToClerk / iAmountBrutto, 2);
	
			mCommisionVat = mToClerkVat;
			mCommisionValue = mToClerk;
	
			mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
			mVatPercent = origVat;
		}
		else
		{
			//calculated by brutto
			mAmount = 0;
			mPrice = 0;
			mTotalSupplier = 0;
			mVatValue = 0;
			
			mSubsid = 0;//new brutto
			
			//calculated by netto
			mToSupplier = 0;
			mToSupplierVat = 0;
			
			//Calculate by netoo and brutto        
			mToClerk = 0;
			
			mToClerkVat = 0;
			mToClerkPercent = 0;
			
			mCommisionVat = 0;
			mCommisionValue = 0;
			
			mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
			mVatPercent = origVat;
		}
    }

    public void setPricesOphirTours(decimal iAmountBrutto, decimal iAmountNetto)
    {
        decimal extraPay = 0;
        decimal commisionDecimal;
        double origVat = mVatPercent;

        switch (mIncomeType)
        {
            case eIncomeType.COM_INC_VAT: //1
            case eIncomeType.COM_PLUS_VAT: //2
            case eIncomeType.COM_VAT_ZERO: //3
                commisionDecimal = mCommision / 100;
                break;

                //There is no commision in flying shikum.
            case eIncomeType.MU_INC_VAT: //4
            case eIncomeType.MU_PLUS_VAT: //5
                commisionDecimal = 0;
                break;

            case eIncomeType.MU_VAT_ZERO: //6
                commisionDecimal = 0;
                mVatPercent = 0;
                break;

            default:
                throw new Exception("Wrong income_type = " + (int)mIncomeType);
        }

        extraPay = (mTravPay != 0) ? mTravPay : (mAmount - mSubsid);
		if (iAmountBrutto != 0.0M)
		{
			//calculated by brutto
			mAmount = iAmountBrutto;
			mTotalSupplier = iAmountBrutto;
            mVatValue = Math.Round(getVatAmountOf(iAmountBrutto), 2);
	
			if (mIsUsingSubsid)
				mSubsid = iAmountBrutto;//new brutto
			else
				mSubsid = 0;//new brutto
	
			//calculated by netto
			mToSupplier = iAmountNetto;
			mPrice = iAmountNetto;
            mToSupplierVat = Math.Round(getVatAmountOf(mToSupplier), 2);
			
			//Calculate by netoo and brutto        
			mMarkUp = iAmountBrutto - iAmountNetto;

            mToClerk = Math.Round(getAmountWithoutVatOf(iAmountBrutto - iAmountNetto), 2);
			if (Math.Abs(mToClerk - (int)mToClerk) > 0.99M)
				mToClerk = Math.Round(mToClerk, 2);
            mToClerkVat = Math.Round(getVatAmountOf(iAmountBrutto - iAmountNetto), 2);
			mToClerkPercent = Math.Round(mToClerk / iAmountBrutto, 2) * 100;
	
			mCommisionVat = mToClerkVat;
			mCommisionValue = mToClerk;
	
			mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
			mVatPercent = origVat;
		}
		else
		{
			//calculated by brutto
			mAmount = 0;
			mPrice = 0;
			mTotalSupplier = 0;
			mVatValue = 0;
			
			mSubsid = 0;//new brutto
			
			//calculated by netto
			mToSupplier = 0;
			mToSupplierVat = 0;
			
			//Calculate by netoo and brutto        
			mToClerk = 0;
			
			mToClerkVat = 0;
			mToClerkPercent = 0;
			
			mCommisionVat = 0;
			mCommisionValue = 0;
			
			mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
			mVatPercent = origVat;
		}
    }

    private void setPricesKalNofesh(decimal iAmountBrutto, decimal iAmountNetto)
    {
        decimal commisionDecimal;
        double origVat = mVatPercent;

        switch (mIncomeType)
        {
            case eIncomeType.COM_INC_VAT: //1
            case eIncomeType.COM_PLUS_VAT: //2
                commisionDecimal = mCommision / 100;
                break;

            case eIncomeType.COM_VAT_ZERO: //3
                commisionDecimal = mCommision / 100;
                mVatPercent = 0;
                break;

            //There is no commision in flying shikum.
            case eIncomeType.MU_INC_VAT: //4
            case eIncomeType.MU_PLUS_VAT: //5
                commisionDecimal = 0;
                break;

            case eIncomeType.MU_VAT_ZERO: //6
                commisionDecimal = 0;
                mVatPercent = 0;
                break;

            default:
                throw new Exception("Wrong income_type = " + (int)mIncomeType);
        }

        if (iAmountBrutto != 0.0M)
        {
            //calculated by brutto
            mAmount = iAmountBrutto;
            mPrice = iAmountBrutto - mMarkUp;
            mTotalSupplier = iAmountBrutto - mMarkUp;
            mVatValue = Math.Round(getVatAmountOf(iAmountBrutto), 2);

            //travPay already assigned
            mSubsid = iAmountBrutto - mTravPay - mMarkUp;//new brutto

            //calculated by netto
            mToSupplier = iAmountNetto;
            mToSupplierVat = Math.Round(getVatAmountOf(mToSupplier), 2);

            //Calculate by netoo and brutto        
            mToClerk = Math.Round(getAmountWithoutVatOf(iAmountBrutto - iAmountNetto), 2);
            if (Math.Abs(mToClerk - (int)mToClerk) > 0.99M)
                mToClerk = Math.Round(mToClerk, 2);
            mToClerkVat = Math.Round(getVatAmountOf(iAmountBrutto - iAmountNetto), 2);
            mToClerkPercent = Math.Round(mToClerk / iAmountBrutto, 2);

            mCommisionVat = mToClerkVat;
            mCommisionValue = mToClerk;

            mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
            mVatPercent = origVat;
        }
        else
        {
            //calculated by brutto
            mAmount = 0;
            mPrice = 0;
            mTotalSupplier = 0;
            mVatValue = 0;

            mSubsid = 0;//new brutto

            //calculated by netto
            mToSupplier = 0;
            mToSupplierVat = 0;

            //Calculate by netoo and brutto        
            mToClerk = 0;

            mToClerkVat = 0;
            mToClerkPercent = 0;

            mCommisionVat = 0;
            mCommisionValue = 0;

            mLastUpdateDate = DateTime.Parse(DateTime.Now.Date.ToString(mDateFormat));
            mVatPercent = origVat;
        }
    }

    public void setSubsid(decimal iSubsid)
    {
        mSubsid = iSubsid;
    }

    public void setTravPay(decimal iTravPay)
    {
        mTravPay = iTravPay;
    }

    private decimal getAmountWithoutVatOf(decimal iPrice)
    {
        //return the vat value.
        return Math.Round((iPrice / ((decimal)(mVatPercent / 100) + 1)) , 2);
    }

    private decimal getVatAmountOf(decimal iPrice)
    {
        //return the full price minus the vat.
        return iPrice - getAmountWithoutVatOf(iPrice);
    }

	public string BSPgetBUNDLESUpdateString()
    {
        string ret = string.Empty;

        string[] parameters = {"vat_percent" , "vat_value" , "commision" , "commision_value" , "commision_vat" , "to_supplier" , "to_supplier_vat" , "to_clerk" , 
							   "to_clerk_vat" , "to_clerk_percent"};

        ret = parameters[0] + " = " + mVatPercent +
              ", " + parameters[1] + " = " + mVatValue +
              ", " + parameters[2] + " = " + mCommision +
              ", " + parameters[3] + " = " + mCommisionValue +
              ", " + parameters[4] + " = " + mCommisionVat +
              ", " + parameters[5] + " = " + mToSupplier +
              ", " + parameters[6] + " = " + mToSupplierVat +
              ", " + parameters[7] + " = " + mToClerk +
              ", " + parameters[8] + " = " + mToClerkVat +
              ", " + parameters[9] + " = " + mToClerkPercent;

        return ret;
    }
	
    public string getBUNDLESUpdateString()
    {
        string ret = string.Empty;
       
        string[] parameters = {"Amount" , "vat_percent" , "vat_value" , "commision" , "commision_value" , "commision_vat" , "to_supplier" , "to_supplier_vat" , "to_clerk" , 
                    "to_clerk_vat" , "to_clerk_percent" , "total_supplier" , "price" , "mark_up" , "income_type" , "subsid" , "trav_pay"};

        ret = parameters[0]  + " = " + mAmount +
              ", " + parameters[1]  + " = " + mVatPercent +
              ", " + parameters[2]  + " = " + mVatValue +
              ", " + parameters[3]  + " = " + mCommision +
              ", " + parameters[4]  + " = " + mCommisionValue +
              ", " + parameters[5]  + " = " + mCommisionVat +
              ", " + parameters[6]  + " = " + mToSupplier +
              ", " + parameters[7]  + " = " + mToSupplierVat +
              ", " + parameters[8]  + " = " + mToClerk +
              ", " + parameters[9]  + " = " + mToClerkVat +
              ", " + parameters[10] + " = " + mToClerkPercent +
              ", " + parameters[11] + " = " + mTotalSupplier +
              ", " + parameters[12] + " = " + mPrice +
              ", " + parameters[13] + " = " + mMarkUp +
              ", " + parameters[14] + " = " + (int)mIncomeType +
              ", " + parameters[15] + " = " + mSubsid +
              ", " + parameters[16] + " = " + mTravPay;

        return ret;
    }

    public string getBUNDLES_to_TRAVELLERSUpdateString()
    {
        string ret = string.Empty;

        string[] parameters = {"Amount" , "price" , "total_to_sup" , "subsid", "mark_up", "trav_pay"};

        ret = parameters[0] + " = " + mAmount +
              ", " + parameters[1] + " = " + mPrice +
              ", " + parameters[2] + " = " + mTotalSupplier +
              ", " + parameters[3] + " = " + mSubsid;
			  
		if (mCompany == eCompany.OphirTours)
		{
			ret += (", " + parameters[4] + " = " + mMarkUp );
		}
		else if (mCompany == eCompany.KalNofesh)
		{
			ret += (", " + parameters[4] + " = " + mMarkUp );
			ret += (", " + parameters[5] + " = " + mTravPay );
		}

        return ret;
    }

    public override string ToString()
    {
        string ret = "<table class='trans'><tr>";
        foreach (var ob in this.GetType().GetProperties())
        {
            ret += "<th width=120>" + ob.Name + " </th> ";
        }
        ret += "</tr><tr>";
        foreach (var ob in this.GetType().GetProperties())
        {
            ret +=  "<td>"+ob.GetValue(this,null) + "</td> ";
        }
        ret += "</tr></table><br/> *********************************************************************** <br/>";

        return ret;
    }
}
