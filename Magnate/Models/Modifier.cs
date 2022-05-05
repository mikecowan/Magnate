using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class Modifier
    {
        public int id { get; set; }
        public List<int> affectedBuildingTypes { get; set; }
        public int value { get; set; }

        public Modifier()
        {
            id = 0;
            affectedBuildingTypes = new List<int>();
        }
    }
}
