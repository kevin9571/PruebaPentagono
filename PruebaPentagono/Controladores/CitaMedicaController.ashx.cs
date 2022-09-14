using PruebaPentagono.Modelos;
using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Controladores
{
    public class CitaMedicaController : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Util util = new Util();
            CitaMedica citaMedica = new CitaMedica();

            DataTable dt = new DataTable();
            string Json = string.Empty;
            string opc = util.Get("opc");

            switch (opc)
            {
                case "show":
                    dt = citaMedica.Show();
                    Json = util.DataTableToJSON(dt);
                    util.Print(Json);
                    break;

                case "save":
                    citaMedica.id_paciente = util.ToInt(util.Post("id_paciente"));
                    citaMedica.id_medico = util.ToInt(util.Post("id_medico"));
                    citaMedica.fecha_hora = util.Post("fecha_hora");

                    util.Print(citaMedica.Save().ToString());
                    break;

                case "FindMedicoPaciente":
                    citaMedica.id_paciente = util.ToInt(util.Get("id_paciente"));
                    citaMedica.id_medico = util.ToInt(util.Get("id_medico"));

                    dt = citaMedica.FindMedicoPaciente();
                    Json = util.DataTableToJSON(dt);

                    util.Print(Json);
                    break;

                case "terminar":
                    citaMedica.id = util.ToInt(util.Get("id"));
                    util.Print(citaMedica.Terminar().ToString());
                    break;

                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}