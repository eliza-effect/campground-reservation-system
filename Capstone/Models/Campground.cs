using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Campground
    {
        public int CampgroundID { get; set; }
        public int ParkID { get; set; }
        public string Name { get; set; }
        public int OpenFrom { get; set; }
        public int OpenTo { get; set; }
        public decimal DailyFee { get; set; }


        public override string ToString()
        {
            return (CampgroundID.ToString().PadRight(10) + ParkID.ToString().PadRight(10) + Name.PadRight(10) + "Open from: " + OpenFrom.ToString().PadRight(10) + "Open to: " + OpenTo.ToString().PadRight(10) + "Daily fee: " + DailyFee.ToString());
        }
    }
}
