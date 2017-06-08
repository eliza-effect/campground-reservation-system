using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Park
    {
        public int ParkID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstablishDate { get; set; }
        public int Area { get; set; }
        public int Visitors { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return (ParkID.ToString().PadRight(10) + Name.PadRight(10) + Location.PadRight(10) + "Established: " + EstablishDate.ToShortDateString().PadRight(10) + "Area:" + Area.ToString().PadRight(10) + "Visitors: " + Visitors.ToString().PadRight(10) + "\n" + Description);
        }
    }
}
