using PruebaPentagono.Modelos;
using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Controladores
{
    public class HistorialController : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Util util = new Util();
            Historial historial = new Historial();

            string opc = util.Get("opc");
            DataTable dt = new DataTable();
            string Json = string.Empty;

            switch (opc)
            {
                case "show":
                    dt = historial.Show();
                    Json = util.DataTableToJSON(dt);
                    util.Print(Json);
                    break;

                case "save":
                    historial.id_cita_medica = util.ToInt(util.Get("id_cita_medica"));
                    historial.diagnostico = util.Post("diagnostico");
                    util.Print(historial.Save().ToString());
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