using BugTracker23.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace BugTracker23.ViewModels
{
    public class MyTicketVM
    {
        public List<Ticket> AllTickets { get; set; }
        public List<Ticket> MyTickets { get; set; }
    }
}