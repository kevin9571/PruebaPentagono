using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Write("<h3>Ocurrio un error en: " + HttpContext.Current.Session["url"] + "</h3>");
        HttpContext.Current.Response.Write("<h3>" + HttpContext.Current.Session["error"] + "</h3>");
    }
}