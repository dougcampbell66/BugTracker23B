using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace BugTracker23.ViewModels
{
    public class MorrisChartVM
    {
        public string Priority { get; set; }
        public int Count { get; set; }
    }
}