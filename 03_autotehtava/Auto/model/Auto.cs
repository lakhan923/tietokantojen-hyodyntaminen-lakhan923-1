using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Autokauppa.model
{
    public class Auto
    {
        public int ID { get; set; }
        public decimal Hinta { get; set; }
        public DateTime RekisteriPaivamaara { get; set; }
        public decimal MoottorinTilavuus { get; set; }
        public int Mittarilukema { get; set; }
        public int MerkkiID { get; set; }
        public int MalliID { get; set; }
        public int VariID { get; set; }
        public int PolttoaineID { get; set; }
    }
}
