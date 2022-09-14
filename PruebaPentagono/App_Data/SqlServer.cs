using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.App_Data
{
    public class SqlServer
    {

        //private string conexion = "Data Source=192.168.40.11;Initial Catalog=DW;Persist Security Info=True;User ID=sa;Password=My47gmC; MultipleActiveResultsets=true";
        private string conexion = "server=DESKTOP-23GFTDU\\SQLEXPRESS;database=PruebaPentagono;integrated security=true";

        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        public bool isError = false;
        public string msgError = "";

        public void Set_Conexion(string host, string dbname, string dbuser, string dbpwd)
        {
            conexion = "Data Source=" + host + ";Initial Catalog=" + dbname + ";Persist Security Info=True;User ID=" + dbuser + ";Password=" + dbpwd + "; MultipleActiveResultsets=true";
        }

        private void Open()
        {
            try
            {
                isError = false;
                msgError = "";
                sqlConnection = new SqlConnection(conexion);
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                isError = true;
                msgError = ex.Message;
            }
        }

        private void Close()
        {
            sqlConnection.Close();
        }

        public DataTable Select(string query)
        {
            try
            {
                Open();
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataSet = new DataSet("data");
                sqlDataAdapter.Fill(dataSet, "data");
                return dataSet.Tables["data"];
            }
            catch (Exception ex)
            {
                isError = true;
                msgError = ex.Message;
            }
            finally
            {
                Close();
            }
            return null;
        }

        public bool Ejecutar(string query)
        {
            try
            {
                Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.CommandTimeout = 5 * 60;
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                isError = true;
                msgError = ex.Message;
            }
            finally
            {
                Close();
            }
            return false;
        }

        public bool Bulk(DataTable dt)
        {
            try
            {
                Open();
                var bul = new SqlBulkCopy(sqlConnection);
                bul.BulkCopyTimeout = 600;
                bul.DestinationTableName = dt.TableName;
                bul.WriteToServer(dt);
                return true;
            }
            catch (Exception ex)
            {
                isError = true;
                msgError = ex.Message;
            }
            finally
            {
                Close();
            }
            return false;
        }
    }
}