using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker23.Helpers;

namespace BugTracker23.Controllers
{
    public class MorrisChartsController : Controller
    {
        // GET: A List of MorrisCharts Data

        //public JsonResult GetTicketPriorityData()
        //{
        //    var data = new List<MorrisChartVM>





        //}
        public ActionResult Index()
        {
            return View();
        }
    }
}