using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker23.Controllers
{
    public class TicketStatusController : Controller
    {
        // GET: TicketStatus
        public ActionResult Index()
        {
            return View();
        }
    }
}