using PruebaPentagono.Modelos;
using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Controladores
{
    /// <summary>
    /// Descripción breve de EspecialidadController
    /// </summary>
    public class EspecialidadController : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Util util = new Util();
            Especialidad especialidad = new Especialidad();

            string opc = util.Get("opc");
            DataTable dt = new DataTable();
            string Json = string.Empty;

            switch (opc)
            {
                case "show":
                    dt = especialidad.Show();
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