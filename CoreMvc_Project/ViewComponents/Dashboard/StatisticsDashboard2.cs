﻿using DataAccessLayer.ConCrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreMvc_Project.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Count();
            ViewBag.v2 = c.Messages.Count();
            ViewBag.v3 = c.Services.Count();

            return View();
        }
    }
}
