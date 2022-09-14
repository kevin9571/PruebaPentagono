using PruebaPentagono.App_Data;
using PruebaPentagono.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Controladores
{
    public class PacienteController : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Util util = new Util();
            Paciente paciente = new Paciente();

            string opc = util.Get("opc");
            DataTable dt = new DataTable();
            string Json = string.Empty;


            switch (opc)
            {
                case "show":
                    dt = paciente.Show();
                    Json = util.DataTableToJSON(dt);
                    util.Print(Json);
                    break;

                case "save":
                    paciente.nombre = util.Post("nombre");
                    paciente.apellido = util.Post("apellido");
                    paciente.peso = util.ToInt(util.Post("peso"));
                    paciente.estatura = util.ToFloat(util.Post("estatura"));

                    util.Print(paciente.Save().ToString());
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