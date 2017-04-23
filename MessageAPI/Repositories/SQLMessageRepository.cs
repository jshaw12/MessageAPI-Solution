using MessageAPI.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MessageAPI.Repositories
{
    public class SQLMessageRepository : IMessageRepository
    {
        public string GetMessage(string tableName, string columnName, string colValue)
        {
            var con = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            string value = "";
           
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from " + tableName + " where " + columnName +"="+ colValue;
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@" + columnName, colValue);
                myConnection.Open();

                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        value = (oReader[columnName] == null) ? null : oReader[columnName].ToString(); 
                    }
                }
            }

            return value;
        }

         public string GetMessage(string tableName, string columnName, int colValue)
        {
            var con = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();

            string value = "";
           
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from " + tableName + " where " + columnName +"="+ colValue;
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@" + columnName, colValue);
                myConnection.Open();

                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        value = (oReader["Message"] == null) ? null : oReader["Message"].ToString(); 
                    }
                }
            }
            return value;
        }

        public string GetMessage()
        {
            return GetMessage("Table", "Column", 1);
        }
    }
}