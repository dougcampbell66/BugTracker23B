﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker23.Models
{
    public class TicketType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}