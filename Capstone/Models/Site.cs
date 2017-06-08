using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Site
    {
        public int SiteID { get; set; }
        public int CampgroundID { get; set; }
        public int SiteNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public bool Accessible { get; set; }
        public int MaxRVLength { get; set; }
        public bool Utilities { get; set; }

        public override string ToString()
        {
            return ("Site ID: " + SiteID.ToString().PadRight(10) + "Campground ID: " + CampgroundID.ToString().PadRight(10) + "Site #: " + SiteNumber.ToString().PadRight(10) + "Max Occupancy: " + MaxOccupancy.ToString().PadRight(10) + "Accessible: " +  Accessible.ToString().PadRight(10) + "Max RV Length: " + MaxRVLength.ToString().PadRight(10) + "Utilities: " + Utilities.ToString());
        }
    }
}
