using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PruebaPentagono.App_Data
{
    public class Util
    {
        public string Get(string parametro)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(url);
            string retorno = HttpUtility.ParseQueryString(myUri.Query).Get(parametro);
            return (retorno != null ? retorno : "");
        }

        public string Post(string parametro)
        {
            try
            {
                string retorno = HttpContext.Current.Request.Form[parametro].ToString();
                return (retorno != null ? retorno : "");
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string DataTableToJSON(DataTable table)
        {
            string JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        public void Print(string texto)
        {
            HttpContext.Current.Response.Write(texto);
        }

        public int ToInt(string texto)
        {
            try
            {
                return int.Parse(texto.Trim(), NumberStyles.AllowParentheses | NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowLeadingSign | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
            return -1;
        }

        public float ToFloat(string texto)
        {
            try
            {
                return float.Parse(texto.Trim());
            }
            catch (Exception ex)
            {
                PrintException(ex.Message);
            }
            return -1;
        }

        public void PrintException(string Exception)
        {
            HttpContext.Current.Session["url"] = HttpContext.Current.Request.Url.AbsoluteUri;
            HttpContext.Current.Session["error"] = Exception;
            HttpContext.Current.Response.Redirect("error.aspx", true);
        }



    }
}