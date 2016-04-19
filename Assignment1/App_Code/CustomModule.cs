using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Assignment1.App_Code
{
    public class CustomModule : IHttpModule
    {
        public CustomModule()
        {
        }

        public String ModuleName
        {
            get { return "HelloWorldModule"; }
        }

        // In the Init function, register for HttpApplication 
        // events by adding your handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
            application.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source,
             EventArgs e)
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            string ipAddress = context.Request.UserHostAddress;

            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<h1><font color=red>" +
                    "HelloWorldModule: Beginning of Request" +
                    "</font></h1><hr>");
               // context.Response.Write("ipaddress" + ipAddress); 
            }

            //checking for valid ipaddress
            if (IsValidIpAddress(ipAddress))
            {
                //returning 403 status code
                context.Response.StatusCode = 403;  // (Forbidden)
            }
           

        }

        //function for checking valid ip address
        private bool IsValidIpAddress(string ipaddress)
        {
            //checking valid ip address
            //return (ipaddress == "208.59.145.195");
            return (ipaddress == "192.168.1.90");
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<hr><h1><font color=red>" +
                    "HelloWorldModule: End of Request</font></h1>");
            }
        }

        private static bool ModuleEnabled()
        {
            bool appSetting;
            if (!bool.TryParse(ConfigurationManager.AppSettings["UseCustomModule"],
                               out appSetting))
                appSetting = false;

            return appSetting;
        }

        public void Dispose() { }
    }

}