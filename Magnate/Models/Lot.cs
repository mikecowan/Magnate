using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class Lot
    {
        public bool forsale { get; set; }
        public int id { get; set; }
        public int blocknum { get; set; }
        public Building Building { get; set; }
        public int LotOwner { get; set; }
        public int dice { get; set; }
        public int[] DiceByType { get; set; }
        public int? salePoints { get; set; }

        public List<Modifier> AdjacencyMods { get; set; }

        public List<Modifier> AllUniqueAdjacenyMods { get; set; }

        public Lot()
        {
            DiceByType = new int[4];
            Building = new Building();
            AdjacencyMods = new List<Modifier>();
            AllUniqueAdjacenyMods = new List<Modifier>();
        }

        public Lot(int id)
        {
            this.id = id;
            Building = new Building();
            DiceByType = new int[4] { 4, 6, 6, 6 };
            AdjacencyMods = new List<Modifier>();
            AllUniqueAdjacenyMods = new List<Modifier>();
        }

        public Lot(int id, Building building)
        {
            this.id = id;
            this.Building = building;
            DiceByType = new int[4] { 4, 6, 6, 6 };
            AdjacencyMods = new List<Modifier>();
            AllUniqueAdjacenyMods = new List<Modifier>();
        }
    }
}
