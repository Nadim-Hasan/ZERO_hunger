﻿using System.Web;
using System.Web.Mvc;

namespace ZERO_hunger
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
