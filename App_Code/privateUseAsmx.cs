using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for privateUseAsmx
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class privateUseAsmx : System.Web.Services.WebService
{

    public privateUseAsmx()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Result> SearchRoom(string name, int rowsAmount)
    {
        List<Result> rooms = new List<Result>();
        DAL_SQL.ConnStr = ConfigurationManager.AppSettings.Get("AdminDBConnStr");
        string rowsAmountQuery = rowsAmount > 0 ? " TOP(" + rowsAmount + ")" : string.Empty;
        name = name.Trim();

        string query = "SELECT " + rowsAmountQuery + " id, name_1252, name_1255, status "
            +" FROM AGENCY_ADMIN.dbo.SUPPLIERS_HOTEL_ADDS "
            + " WHERE (name_1255 LIKE @roomName OR name_1252 LIKE @roomName) AND status=1 ORDER BY name_1255";
        DataSet ds = DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.Text, query,
          SqlDalParam.formatParam("@roomName", SqlDbType.NVarChar, "%" + name + "%"));
        if (Utils.IsDataSetRowsNotEmpty(ds))
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rooms.Add(new Result()
                {
                    id = row["id"].ToString(),
                    name_1255 = row["name_1255"].ToString(),
                    name_1252 = row["name_1252"].ToString()
                });
            }
        }

        return rooms;
    }
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Result> SearchBases(string name, int rowsAmount)
    {
        List<Result> rooms = new List<Result>();
        DAL_SQL.ConnStr = ConfigurationManager.AppSettings.Get("AdminDBConnStr");
        string rowsAmountQuery = rowsAmount > 0 ? " TOP(" + rowsAmount + ")" : string.Empty;
        name = name.Trim().Replace("ALLRESULTS",string.Empty);

        string query = "SELECT " + rowsAmountQuery + " id, name_1252, name_1255 "
            + " FROM AGENCY_ADMIN.dbo.HOTEL_ON_BASE "
            + " WHERE (name_1255 LIKE @basename OR name_1252 LIKE @basename) ORDER BY name_1255";
        DataSet ds = DAL_SQL.ExecuteDataset(DAL_SQL.ConnStr, CommandType.Text, query,
          SqlDalParam.formatParam("@basename", SqlDbType.NVarChar, "%" + name + "%"));
        if (Utils.IsDataSetRowsNotEmpty(ds))
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rooms.Add(new Result()
                {
                    id = row["id"].ToString(),
                    name_1255 = row["name_1255"].ToString(),
                    name_1252 = row["name_1252"].ToString()
                });
            }
        }

        return rooms;
    }
    public class Result
    {
        public string id;
        public string name_1255;
        public string name_1252;

        public Result()
        {

        }

    }
}
