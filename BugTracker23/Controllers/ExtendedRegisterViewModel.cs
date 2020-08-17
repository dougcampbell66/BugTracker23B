using System.Web.Mvc;

namespace BugTracker23.Controllers
{
    public class ExtendedRegisterViewModel

    {
        internal string LastName;

        public string Email { get; internal set; }
        public object Password { get; internal set; }
        public string FirstName { get; internal set; }
        public string DisplayName { get; internal set; }
    }
    
}