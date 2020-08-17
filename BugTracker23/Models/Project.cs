using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker23.Models
{
    public class Project
    {
        public int Id { get; set; }
        #region Parents/Children
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        #endregion

        #region Actual Properties
        //Restrict Name length to no more than 50 characters
        public string Name { get; set; }
        //Probably not going to have a minimum character;
        public DateTime Created { get; set; }

        public bool IsArchived { get; set; }

        #endregion

        #region Constructor
        public Project()
        {
            Tickets = new HashSet<Ticket>();
            Users = new HashSet<ApplicationUser>();
        }
        #endregion
    }
}