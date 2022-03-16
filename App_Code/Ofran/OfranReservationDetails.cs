using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class OfranReservationDetails
{
    public OfranCreateDynamicReservationRequest ReservationRequest { get; set; }

    public OfranCreateDynamicReservationResponse ReservationResponse { get; set; }

    public OfranRentalCar RentalCar { get; set; }


    public class OfranRentalCar
    {
        string CarName { get; set; }
        string ImageName { get; set; }
        string SupplierCarGroupId { get; set; }
        string PriceWithCurrency { get; set; }
        string AdultsNum { get; set; }
        string KidsNum { get; set; }
        string SuitcasesNum { get; set; }
        string HandbagsNum { get; set; }
        string CarGroupName { get; set; }
        string CatalogPriceId { get; set; }
        string CurrencyId { get; set; }
        string SubContractId { get; set; }
        string SupplierPricecatalogueId { get; set; }
        string HandlingFree { get; set; }
        string GearTypes { get; set; }
        string RentalCompany { get; set; }

        public OfranRentalCar(string iCarName, string iImageName, string iSupplierCarGroupId,
                              string iPriceWithCurrency, string iAdultsNum, string iKidsNum,
                              string iSuitcasesNum, string iHandbagsNum, string iCarGroupName,
                              string iCatalogPriceId, string iCurrencyId, string iSubContractId,
                              string iSupplierPricecatalogueId, string iHandlingFree, string iGearTypes,
                              string iRentalCompany)
        {
            CarGroupName = iCarGroupName;
            ImageName = iImageName;
            SupplierCarGroupId = iSubContractId;
            PriceWithCurrency = iPriceWithCurrency;
            AdultsNum = iAdultsNum;
            KidsNum = iKidsNum;
            SuitcasesNum = iSuitcasesNum;
            HandbagsNum = iHandbagsNum;
            CarGroupName = iCarGroupName;
            SupplierPricecatalogueId = iSupplierPricecatalogueId;
            HandlingFree = iHandlingFree;
            GearTypes = iGearTypes;
            RentalCompany = iRentalCompany;
        }

        public OfranRentalCar(OfranRentalCar iOther)
        {
            CarGroupName = iOther.CarGroupName;
            ImageName = iOther.ImageName;
            SupplierCarGroupId = iOther.SubContractId;
            PriceWithCurrency = iOther.PriceWithCurrency;
            AdultsNum = iOther.AdultsNum;
            KidsNum = iOther.KidsNum;
            SuitcasesNum = iOther.SuitcasesNum;
            HandbagsNum = iOther.HandbagsNum;
            CarGroupName = iOther.CarGroupName;
            SupplierPricecatalogueId = iOther.SupplierPricecatalogueId;
            HandlingFree = iOther.HandlingFree;
            GearTypes = iOther.GearTypes;
            RentalCompany = iOther.RentalCompany;
        }
    }
}