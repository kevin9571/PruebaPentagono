using PruebaPentagono.Modelos;
using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Controladores
{
    public class MedicoController : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Util util = new Util();
            Medico medico = new Medico();

            string opc = util.Get("opc");
            DataTable dt = new DataTable();
            string Json = string.Empty;

            switch (opc)
            {
                case "show":
                    dt = medico.Show();
                    Json = util.DataTableToJSON(dt);
                    util.Print(Json);
                    break;

                case "save":
                    medico.nombre = util.Post("nombre");
                    medico.apellido = util.Post("apellido");
                    medico.id_especialidad = util.ToInt(util.Post("id_especialidad"));

                    util.Print(medico.Save().ToString());
                    break;

                case "FindByEspecialidad":
                    medico.id_especialidad = util.ToInt(util.Get("id_especialidad"));
                    dt = medico.FindByEspecialidad();
                    Json = util.DataTableToJSON(dt);
                    util.Print(Json);
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