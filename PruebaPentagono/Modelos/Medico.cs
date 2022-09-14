using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Modelos
{
    public class Medico : Util
    {
        public int id;
        public string nombre;
        public string apellido;
        public int id_especialidad;

        SqlServer sqlServer = new SqlServer();

        public DataTable Show()
        {
            string query = "SELECT * FROM medico";
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

        public DataTable FindByEspecialidad()
        {
            string query = $"SELECT id,nombre,apellido,id_especialidad " +
                           $"FROM medico " +
                           $"where id_especialidad={id_especialidad} ";
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
            string query = $"insert into medico(nombre,apellido,id_especialidad) " +
                            $"values('{this.nombre}','{this.apellido}',{this.id_especialidad});";
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