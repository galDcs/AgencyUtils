using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LineActionLogVCH
/// </summary>
public class LineActionLogVCH
{
    public string Error { get; set; }
    public int NumberOfTicketsInLineFromDB { get; set; }
    public bool IsMoreThanOneTicketsInTraveller { get; set; }
    public string DocketId { get; set; }
    public string VoucherId { get; set; }
    public string BundleId { get; set; }
    public string AllTickets { get; set; }
    public string TicketNumberFromDB { get; set; }
    public string TicketNumber { get; set; }
    public string CurrencyCode { get; set; }
    public string CurrencyIdFromDB { get; set; }
    public string PayToSupplierFromDB { get; set; }
    public decimal CommissionableAmount { get; set; }
    public decimal StandartCommissionRate { get; set; }
    public decimal StandardCommissionAmount { get; set; }
    public decimal SupplementaryCommissionRate { get; set; }
    public decimal SupplementaryCommissionAmount { get; set; }
    public decimal EffectiveCommissionRate { get; set; }
    public decimal EffectiveCommissionAmount { get; set; }
    public decimal RemittanceAmount { get; set; }
    public decimal TaxOnCommission { get; set; }
    public decimal TaxandMiscellaneousFeesTax { get; set; }
    public decimal TaxandMiscellaneousFeesFees { get; set; }
    public decimal TaxandMiscellaneousFeesPenalties { get; set; }
    public decimal FileTotalTax { get; set; }
    public decimal FileTotalTax2 { get; set; }
    public string NetRemitIndicator { get; set; }
    public string NetRemitORCommissionCalculationMethod { get; set; }
    public string CashAmount { get; set; }
    public string CreditAmount { get; set; }
    public string RelatedTicketOrDocumentType { get; set; }
    public string TaxOnCommissionCalculationMethod { get; set; }
    public string Carrier { get; set; }
    public decimal CommissionPercent { get; set; }
    public string ToClerk { get; set; }
    public string ToClerkVat { get; set; }
    public decimal TotalNetto { get; set; }
    public decimal TicketsPrice { get; set; }
    public decimal TicketsTax { get; set; }
    public decimal TicketsMarkUp { get; set; }
    public decimal TicketsAmount { get; set; }
    public string ValueDate { get; set; }
    public string RefDate { get; set; }
    public decimal ExchangeRateUsd { get; set; }
    public decimal ExchangeRateNis { get; set; }
    public string IncomeTypeId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalMarkUp { get; set; }
    public string PaymentTypeId { get; set; }

    public decimal BruttoFromDb { get; set; }
    public decimal NettoFromDB { get; set; }
    public string TransactionCode { get; set; }
    public string TotalNettoReason { get; set; }
    public decimal CommissionFromDb { get; set; }

	public LineActionLogVCH()
	{

	}

    public override string ToString()
    {
        string ret = "";
        int pos = 0;
        foreach (var ob in this.GetType().GetProperties())
        {
            ret += (ob.Name + ":" + ob.GetValue(this, null) + ", ");
        }

        return ret;
    }
}