using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Modelos
{
    public class CitaMedica : Util
    {
        public int id;
        public int id_paciente;
        public int id_medico;
        public string fecha_hora;

        SqlServer sqlServer = new SqlServer();

        public DataTable Show()
        {
            string query = "SELECT c.id , " +
                               "id_paciente , " +
                               "CONCAT(p.nombre, ' ', p.apellido) paciente , " +
                               "id_medico , " +
                               "CONCAT(m.nombre, ' ', m.apellido) medico , " +
                               "e.nombre especialidad, " +
                               "fecha_hora " +
                        "FROM cita_medica c " +
                        "INNER JOIN paciente p ON c.id_paciente = p.id " +
                        "INNER JOIN medico m ON c.id_medico = m.id " +
                        "INNER JOIN especialidad e ON m.id_especialidad = e.id " +
                        "WHERE terminada = 0 " +
                        "order by fecha_hora asc";
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

        public DataTable FindMedicoPaciente()
        {
            string query = $"Select * from cita_medica where id_paciente={this.id_paciente} and id_medico={this.id_medico};";
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
            string query = $"insert into cita_medica(id_paciente,id_medico,fecha_hora) values({this.id_paciente},{this.id_medico},'{this.fecha_hora}')";
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


        public bool Terminar()
        {
            string query = $"update cita_medica set terminada=1 where id={id}";
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