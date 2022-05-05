using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class Block2
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Lot> Lots { get; set; }
        public Block2 LeftNeighbor { get; set; }
        public Block2 RightNeighbor { get; set; }
        public int arrowDirection { get; set; } // left, down, right
        
        public Block2()
        {
            Lots = new List<Lot>();
            for (int i = 0; i < 9; i++)
            {
                Lots.Add(new Lot(i));
            }
        }
    }
}
