﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker23.Controllers
{
    public class TicketCommentController : Controller
    {
        // GET: TicketComment
        public ActionResult Index()
        {
            return View();
        }
    }
}