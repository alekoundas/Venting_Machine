using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Venting_Machine.Repository
{
    public class DataBase
    {
        public static SqlConnection dbConnectionAndInitData()
        {
            //Make And Open Connection to SQL Server
            string DB_Conn = @"Server = localhost\SQLEXPRESS; Database = master; MultipleActiveResultSets=true;Trusted_Connection = True";
            SqlConnection dbCon = new SqlConnection(DB_Conn);
            dbCon.Open();


            //Get User Data From db
            GetUserFromDB(dbCon);

            //Get Product Data From db
            GetStoreProductsFromDB(dbCon);
                    
            return dbCon;
        }

        private static void GetUserFromDB(SqlConnection dbCon)
        {
            string query = "USE VentingMachine;SELECT name,money FROM Customer WHERE(id=1);";
            SqlCommand Command = new SqlCommand(query, dbCon);
            SqlDataReader Row = Command.ExecuteReader();

            Row.Read();
            Customer.Instance.Name = (string)Row.GetValue(0);
            Customer.Instance.Money = (double)Row.GetValue(1);
        }

        private static void GetStoreProductsFromDB(SqlConnection dbCon)
        {
            string query = "USE VentingMachine;SELECT waterid,cigarid FROM StoreProduct;";
            SqlCommand Command = new SqlCommand(query, dbCon);
            SqlDataReader Row = Command.ExecuteReader();
            while (Row.Read())
            {
                //Check Whitch column is not null so input correct data
                if (!DBNull.Value.Equals(Row.GetValue(0)))
                {
                    query = "USE VentingMachine;SELECT Title,Price FROM StoreProduct  INNER JOIN Water ON StoreProduct.waterid = " + (int)Row.GetValue(0) + " AND Water.id=" + Row.GetValue(0) + " ;";
                    SqlCommand Command2 = new SqlCommand(query, dbCon);
                    SqlDataReader Row2 = Command2.ExecuteReader();
                    Row2.Read();
                    VentingMachine.Instance.ProductQueue.Enqueue(new Water(Row2.GetValue(0).ToString().Trim(), (double)Row2.GetValue(1)));
                    Row2.Close();
                }
                else if (!DBNull.Value.Equals(Row.GetValue(1)))
                {
                    query = "USE VentingMachine;SELECT Title,Price FROM StoreProduct  INNER JOIN Cigar ON StoreProduct.cigarid = " + (int)Row.GetValue(1) + " AND Cigar.id=" + Row.GetValue(1) + " ;";
                    SqlCommand Command2 = new SqlCommand(query, dbCon);
                    SqlDataReader Row2 = Command2.ExecuteReader();
                    Row2.Read();
                    VentingMachine.Instance.ProductQueue.Enqueue(new Cigar(Row2.GetValue(0).ToString().Trim(), (double)Row2.GetValue(1)));
                    Row2.Close();
                }
            }
            Row.Close();
        }
    }
}
