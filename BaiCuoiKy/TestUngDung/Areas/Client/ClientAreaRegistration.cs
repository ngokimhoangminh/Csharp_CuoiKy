﻿using System.Web.Mvc;

namespace TestUngDung.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Client_default",
                "Client/{controller}/{action}/{id}",
                new { controller = "List", action = "Index", Areas="Client", id = UrlParameter.Optional }
            );
        }
    }
}