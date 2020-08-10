using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker23.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        #region Parents/Children
        public int ProjectId { get; set; }
        public int TicketPriorityId { get; set; }
        public int TicketStatusId { get; set; }
        public int TicketTypeId { get; set; }
        public string SubmitterId { get; set; }
        public string DeveloperId { get; set; }
        public virtual ApplicationUser Submitter { get; set; }
        public virtual ApplicationUser Developer { get; set; }
        public virtual Project Project { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
        public ICollection<TicketAttachment> TicketAttachments { get; set; }
        public ICollection<TicketComment> TicketComments { get; set; }
        public ICollection<TicketHistory> TicketHistories { get; set; }
        public ICollection<TicketNotification> TicketNotifications { get; set; }

        #endregion

        #region Navigational Properties





        #endregion

        #region Actual Properties
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsResolved { get; set; }
        public bool IsArchived { get; set; }

        #endregion

        #region Constructor
        public Ticket()
        {
            TicketAttachments = new HashSet<TicketAttachment>();
            TicketComments = new HashSet<TicketComment>();
            TicketHistories = new HashSet<TicketHistory>();
            TicketNotifications = new HashSet<TicketNotification>();
        }
        #endregion    
    }
}