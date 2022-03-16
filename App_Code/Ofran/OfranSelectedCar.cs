using System.Collections.Generic;

public class OfranSelectedCar
{
    public string CarName { get; set; }
    public string CarGroupName { get; set; }
    public string SupplierCarGroupId { get; set; }
    public string HandlingFee { get; set; }
    public string PremiumFee { get; set; }
    public string PriceCatalogId { get; set; }
    public string SupplierPricecatalogueId { get; set; }
    public string CurrencyId { get; set; }
    public string SubContractId { get; set; }
    public OfranAdditionalProduct ProductDetails { get; set; }
    public string ImageName { get; set; }
    public string PriceWithCurrency { get; set; }
    public string AdultsNum { get; set; }
    public string KidsNum { get; set; }
    public string SuitcasesNum { get; set; }
    public string HandbagsNum { get; set; }
    public string BasicPrice { get; set; }
    public string NettoPrice { get; set; }
    public string GrossTotal { get; set; }
    public string Commission { get; set; }
    public string CommissionPercent { get; set; }
    public string VatFromCommission { get; set; }
    public string VatPercentFromCommission { get; set; }
    public string DomesticVat { get; set; }
    public string DiscountPercent { get; set; }
    public string Discount { get; set; }
    public OfranGetResultConditionsResponse Conditions { get; set; }
    public string carDoors { get; set; }
    public string RentalCompany { get; set; }

    public string OfranCarGroup { get; set; }

    public bool isUpgraded { get; set; }

    public List<OfranGetPrebooksResponse.Prebookcondition> Prebooks { get; set; }
    public List<OfranAdditionalProduct> BasicProducts { get; set; }
}