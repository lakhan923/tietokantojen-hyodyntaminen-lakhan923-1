using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Autokauppa.model
{
    public class Malli
    {
        public int ID { get; set; }
        public string Nimi { get; set; }
        public int MerkkiID { get; set; }
    }
}
