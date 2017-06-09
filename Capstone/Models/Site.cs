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
            return (SiteNumber.ToString().PadRight(10) + MaxOccupancy.ToString().PadRight(15) + Accessible.ToString().PadRight(15) + MaxRVLength.ToString().PadRight(15) + Utilities.ToString().PadRight(10));
        }
    }
}
