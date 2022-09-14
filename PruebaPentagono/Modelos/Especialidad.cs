using PruebaPentagono.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaPentagono.Modelos
{
    public class Especialidad
    {
        public DataTable Show()
        {
            SqlServer sqlServer = new SqlServer();
            string query = "SELECT * FROM especialidad";
            try
            {
                return sqlServer.Select(query);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Session["url"] = HttpContext.Current.Request.Url.AbsoluteUri;
                HttpContext.Current.Session["error"] = ex.Message;
                HttpContext.Current.Response.Redirect("error.aspx", true);
            }
            return null;
        }
    }
}