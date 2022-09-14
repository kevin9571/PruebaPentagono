using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Modelos
{
    public class Paciente : Util
    {
        public string nombre;
        public string apellido;
        public string fecha_nacimiento;
        public int peso;
        public float estatura;

        SqlServer sqlServer = new SqlServer();



        public DataTable Show()
        {
            string query = "SELECT * FROM paciente";
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
            string query = $"insert into paciente(nombre,apellido,fecha_nacimiento,peso,estatura) " +
                            $"values('{this.nombre}','{this.apellido}','{this.fecha_nacimiento}',{this.peso},{this.estatura})";
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