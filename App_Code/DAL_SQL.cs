using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_SQL
{
    private static string connStr = String.Empty;
    public static string ConnStr
    {
        get
        {
			string agencyId = "";
			//if (HttpContext.Current.Request.Cookies["Agency2000"] != null)
            //{
			//	//Logger.Log("1agencyId = ");
            //    if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["Agency2000"]["AgencyID"]))
            //    {
			//		//Logger.Log("2agencyId = ");
            //        agencyId = HttpContext.Current.Request.Cookies["Agency2000"]["AgencyID"];
			//		//Logger.Log("3agencyId = " + agencyId);
            //    }
            //}
			
            if (connStr == String.Empty)
            {
                //connStr = ConfigurationManager.AppSettings.Get("connectionString");
                connStr = ConfigurationManager.AppSettings.Get("CurrentAgencyDBConnStr");
            }
            return connStr;
        }
        set
        {
            if (value != null && value != "")
            {
                connStr = value;
            }
        }
    }

    //C'tor
	public DAL_SQL()
	{
	
	}

    public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
    {
        SqlCommand command = new SqlCommand();
        ConnStr = connectionString;
        DataSet ds = new DataSet();

        using (var connection = new SqlConnection(ConnStr))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (commandParameters != null || command.CommandType == CommandType.StoredProcedure)
            {
                AttachParameters(command, commandParameters);
            }

            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(command);
            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.                                            
            command.Parameters.Clear();
        }

        //return the dataset
        return ds;
    }

    private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
    {
        if (command.CommandType != CommandType.StoredProcedure ||
            (command.CommandType == CommandType.StoredProcedure && commandParameters != null))
        {
            foreach (SqlParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }

                command.Parameters.Add(p);
            }
        }
    }

    public static string RunSql(string sql)
    {
        if (sql.Length <= 0)
            return "";

        string commandText = sql;

        SqlCommand command = new SqlCommand();
        //ConnStr = ConfigurationManager.AppSettings["CurrentAgencyDBConnStr"]; //connectionString;
        DataSet ds = new DataSet();

        using (var connection = new SqlConnection(ConnStr))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;

            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(command);

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.                                            
            command.Parameters.Clear();
        }

        try // to return value
        {
            return ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        catch (Exception ex) // no value
        {
			if (!ex.Message.Contains("There is no row at position 0."))
			{
				Logger.Log(ex.Message);
			}
            return "";
        }
    }
    public static bool RunSqlbool(string sql)
    {
        if (sql.Length <= 0)
            return false;

        string commandText = sql;

        SqlCommand command = new SqlCommand();

        // ConnStr = ConfigurationManager.AppSettings["CurrentAgencyDBConnStr"]; //connectionString;
        using (var connection = new SqlConnection(ConnStr))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;

            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.                                            
            command.Parameters.Clear();
        }

        try // to return value
        {
            return true;
        }
        catch (Exception ex) // no value
        {
            Logger.Log(ex.Message);
            return false;
        }
    }

    public static DataSet RunSqlDataSet(string sql)
    {
        if (sql.Length <= 0)
            return null;

        string commandText = sql;

        SqlCommand command = new SqlCommand();
        //ConnStr = ConfigurationManager.AppSettings["CurrentAgencyDBConnStr"]; //connectionString;
        DataSet ds = new DataSet();

        using (var connection = new SqlConnection(ConnStr))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;

            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(command);

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.                                            
            command.Parameters.Clear();
        }

        return ds;
    }

    public static string GetRecord(string TableName, string SelectField, string Key, string SearchField)
    {
        if (TableName.Length <= 0 || SelectField.Length <= 0 || Key.Length <= 0 || SearchField.Length <= 0)
            return "";

        string commandText = " select " + SelectField + " from " + TableName + " where " + SearchField + " = " + Key + " ";

        SqlCommand command = new SqlCommand();
        //ConnStr = ConfigurationManager.AppSettings["CurrentAgencyDBConnStr"]; //connectionString;
        DataSet ds = new DataSet();

        using (var connection = new SqlConnection(ConnStr))
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;

            //create the DataAdapter & DataSet
            SqlDataAdapter da = new SqlDataAdapter(command);

            //fill the DataSet using default values for DataTable names, etc.
            da.Fill(ds);

            // detach the SqlParameters from the command object, so they can be used again.                                            
            command.Parameters.Clear();
        }

        try // to return value
        {
            return ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        catch (Exception ex) // no value
        {
            Logger.Log(ex.Message);
            return "";
        }
    }
}

public sealed class SqlDalParam
{
    private SqlDalParam() { }

    public static SqlParameter formatParam(string pname, SqlDbType ptype, object pvalue)
    {
        SqlParameter sparam = new SqlParameter(pname, ptype);
        sparam.Value = pvalue;
        sparam.Direction = ParameterDirection.Input;
        return sparam;
    }

    public static SqlParameter formatParam(string pname, SqlDbType ptype, int psize, object pvalue)
    {
        return formatParam(pname, ptype, psize, pvalue, ParameterDirection.Input);
    }

    public static SqlParameter formatParam(string pname, SqlDbType ptype, int psize, object pvalue, ParameterDirection pdir)
    {
        SqlParameter sparam = new SqlParameter(pname, ptype, psize);
        sparam.Value = pvalue;
        sparam.Direction = pdir;
        return sparam;
    }
}