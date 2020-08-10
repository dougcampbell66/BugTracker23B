using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker23.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        #region Parent/Child
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        #endregion
        #region Actual Properties

        //The property of the ticket that was changed (Status, Type, Attachment, etc.
        public string Property { get; set; } //"TicketType"
        public string OldValue { get; set; } //"UI Defect"
        public string NewValue { get; set; } //"Hardware Defect"
        public DateTime Updated { get; set; }
        #endregion
    }
}