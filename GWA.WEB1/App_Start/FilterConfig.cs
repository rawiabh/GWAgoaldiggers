﻿using GWA.WEB1.App_Start;
using System.Web.Mvc;

namespace IdentitySample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleAntiforgeryTokenErrorAttribute()
            { ExceptionType = typeof(HttpAntiForgeryException) }
            );
        }
    }
}
