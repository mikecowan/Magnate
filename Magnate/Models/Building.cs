using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class Building
    {
        public int buildingType { get; set; }
        public int buildingRank { get; set; }
        public int buildingNum { get; set; }
        public int tenantCapacity { get; set; }
        public int tenantCount { get; set; }
        public int population { get; set; }
        public Modifier AdjacencyMod { get; set; }
        public Modifier SelfMod { get; set; }
        public List<Tenant2> Tenants { get; set; }

        public Building()
        {
            Tenants = new List<Tenant2>();
        }
    }
}
