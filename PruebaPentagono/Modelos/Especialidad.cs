using PruebaPentagono.App_Data;
using System;
using System.Data;
using System.Web;

namespace PruebaPentagono.Modelos
{
    public class Especialidad : Util
    {
        public string nombre;
        SqlServer sqlServer = new SqlServer();

        public DataTable Show()
        {            
            string query = "SELECT * FROM especialidad";
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
            string query = $"insert into especialidad(nombre) values('{this.nombre}');";
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