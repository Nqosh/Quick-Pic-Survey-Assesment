﻿using System.Web;
using System.Web.Mvc;

namespace QuickPic_Survey_Spa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
