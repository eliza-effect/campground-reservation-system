using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int SiteID { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreateDate { get; set; }

        public override string ToString()
        {
            return (ReservationID.ToString().PadRight(10) + "Site ID: " + SiteID.ToString().PadRight(10) + Name.PadRight(10) + "Start Date: " + FromDate.ToShortDateString().PadRight(10) + "End Date: " + ToDate.ToShortDateString().PadRight(10) + "Reservation Created: " + CreateDate.ToShortDateString());
        }
    }
}
