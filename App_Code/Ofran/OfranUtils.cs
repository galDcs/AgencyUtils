using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for OfranUtils
/// </summary>
public static class OfranUtils
{
    //public static string SetConditions(List<OfranGetResultConditionsResponse.Condition> iConditions, string iConditionType)
    //{
    //    //iConditionType
    //    string html = string.Empty;
    //    int index = 0;

    //    foreach (OfranGetResultConditionsResponse.Condition condition in iConditions)
    //    {
    //        switch (iConditionType)
    //        {
    //            case "includingRates":
    //                html += "<div style='display:inline-flex; padding-bottom:5px;'><div class='markIcons'><i class='far fa-check-circle'></i></div>";
    //                html += "<span style='padding-left:10px'>" + condition.Description + "</span></div>";
    //                break;
    //            case "extras":
    //            case "importantInfo":
    //            case "informative":
    //                if (index == 0) html += "<ul class='" + iConditionType + "'>";
    //                html += "<li class='fas fa-square'>" + condition.Description + ": " + condition.Content + "</li>";
    //                if (index == iConditions.Count - 1) html += "</ul>";
    //                break;

    //        }

    //        index++;
    //    }
    //    //if(iConditionType.Equals("includingRates"))
    //    //{
    //    //    html += "<span id='spnShowMore' onclick='expandDiv();'>Show More</span>";
    //    //}

    //    return html;
    //}

    public static string SetConditions(List<OfranGetResultConditionsResponse.Condition> iConditions, string iConditionType)
    {
        return SetConditions(iConditions, iConditionType, 12);
    }

    public static string SetConditions(List<OfranGetResultConditionsResponse.Condition> iConditions, string iConditionType, int textWidth)
    {
        //iConditionType
        string html = string.Empty;
        StringBuilder stringBuilder = new StringBuilder();
        //int index = 0;

        foreach (OfranGetResultConditionsResponse.Condition condition in iConditions)
        {
            switch (iConditionType)
            {
                case "includingRates":
                    stringBuilder.Append(
                        string.Format(
                            @"<div style='display:inline-flex; padding-bottom:5px;' class='col-lg-{0}'>
                                <i class='far fa-check-circle markIcons'></i>
                                <span style='padding-left:10px'>{1}</span>" +
                            "</div>",
                            textWidth, condition.Description)
                        );
                    break;
                case "extras":
                case "importantInfo":
                case "informative":
                    stringBuilder.Append(
                        string.Format(
                            @"<div style='display: inline-flex; padding-bottom: 5px'>
                                <i class='fas fa-chevron-circle-right'></i>
                                <span style='padding-left:10px;'>{0}: {1}</span>
                            </div>",
                            condition.Description, condition.Content)
                        );
                    break;

            }

            //index++;
        }
        //if(iConditionType.Equals("includingRates"))
        //{
        //    html += "<span id='spnShowMore' onclick='expandDiv();'>Show More</span>";
        //}

        return stringBuilder.ToString();
    }

    public static string GetCarHtmlForOfranOrderExtras(string iCarName, string iImageName, string iPriceWithCurrency,
                                    string iSupplierCarGroupId, bool iIsHideAltModels, string iAdultsNum,
                                    string iKidsNum, string iSuitcasesNum, string iHandbagsNum,
                                    string iGroupName, string iIncludedinRate, string iExtrasDetails,
                                    string iImportantInformation, string iInformative, string iHandlingFee,
                                    string iPriceCatalogId, string iSupplierPricecatalogueId, string iCurrencyId,
                                    string iSubContractId)
    {
        int id = 0;
        string html = string.Format(
       @"<div class='row carCube'> 
            <div class='col-lg-12 carCubeHeader'>
                <div class='col-lg-3 car_name'>{0} | {9}</div>
                <div class='col-lg-6'></div>
                <div class='col-lg-3 more_group_cars {4}'>
                    <label class='pointer' onclick='searchAltModels({3})'>Alternative Models</label>
                </div>
            </div>
            <div class='col-lg-12 carCubeDetails'>
                <div class='col-lg-3'>
                    <a href='./Images/{1}' target='_blank'><img src='./Images/{1}' class='car_image' /></a>
                    <span class='car_icons'>
                        <i class='fas fa-male' title='Recommended Adult'></i>
                        <span>{5}</span>
                        <i class='fas fa-child' title='Recommended Kids'></i>
                        <span>{6}</span>
                        <i class='fas fa-suitcase-rolling' title='Big Bags'></i>
                        <span>{7}</span>
                        <i class='fas fa-briefcase' title='Small Bags'></i>
                        <span>{8}</span>
                    </span>
                </div>
                <div class='col-lg-6'>
                    <div class='includedConditions'>{10}</div>
                    <span class='pointer spnExpd' onclick='showMore(this);'>Show More</span>
                </div>                
            </div>
            <div class='col-lg-12 conditions_circles'>
                <i class='fas fa-info-circle pointer importantInfo' onclick='showConditions({14}{15}{14}, {14}Importantinformation{14});'>Rental terms and excess amounts</i>
                <i class='fas fa-info-circle pointer extras' onclick='showConditions({14}{15}{14}, {14}Extras{14});'>Extras (to be paid locally)</i>
                <i class='fas fa-info-circle pointer informative' onclick='showConditions({14}{15}{14}, {14}Informative{14});'>Important Information</i>
            </div>
        </div>
        <div id='{15}_divConditions' class='hide'> 
            <div id='{15}_Extras' class='conditions hide'>{11}</div>
            <div id='{15}_Importantinformation' class='conditions hide'>{12}</div>
            <div id='{15}_Informative' class='conditions hide'>{13}</div>
        </div>",
           /*{0}-{2}*/  iCarName, iImageName, iPriceWithCurrency,
           /*{3}-{5}*/  iSupplierCarGroupId, (iIsHideAltModels ? "hide" : ""), iAdultsNum,
           /*{6}-{8}*/  iKidsNum, iSuitcasesNum, iHandbagsNum,
           /*{9}-{11}*/ iGroupName, iIncludedinRate, iExtrasDetails,
           /*{12}-{14}*/ iImportantInformation, iInformative, "\"",
           /*{15}-{17}*/ iCarName.Replace(" ", "_"), iHandlingFee, iPriceCatalogId,
           /*{18}-{20}*/ iSupplierPricecatalogueId, iCurrencyId, iSubContractId,
           /*{21}-{23}*/ iGroupName, id);

        return html;
    }

    
    
     
    public static string GetCarGroupIdByName(string iGroupName)
    {
        string query = string.Empty;
        string carGroupId = string.Empty;

        try
        {
            query = "SELECT id FROM dbo.CAR_GROUPS WHERE name = '" + iGroupName + "'";
            carGroupId = DAL_SQL.RunSql(query);
        }
        catch (Exception e)
        {
            Logger.Log("Utils.GetCarGroupIdByName.\nQuery:" + query + "\nExecption Message: " + e.Message);
        }
        return carGroupId;
    }



}