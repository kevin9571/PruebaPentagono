using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Modelos
{
    public class Historial : Util
    {
        public int id_cita_medica;
        public string diagnostico;

        SqlServer sqlServer = new SqlServer();

        public DataTable Show()
        {
            SqlServer sqlServer = new SqlServer();
            string query = "SELECT * FROM historial";
            try
            {
                return sqlServer.Select(query);
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
            return null;
        }

        public bool Save()
        {
            string query = $"insert into historial(id_cita_medica,diagnostico) values({this.id_cita_medica},'{this.diagnostico}');";
            try
            {
                return sqlServer.Ejecutar(query);
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
            return false;
        }



    }
}