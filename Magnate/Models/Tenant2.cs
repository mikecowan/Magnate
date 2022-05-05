using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class Tenant2
    {
        public int type { get; set; }
        public int subtype { get; set; }
        public int income { get; set; }

        public Modifier AdjacencyMod { get; set; }
        
        public Tenant2()
        {
            AdjacencyMod = new Modifier();
        }
    }
}
