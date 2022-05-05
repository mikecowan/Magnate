using Magnate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.StaticData
{
    public class BlockData
    {
        private string blockName { get; set; }
        private int id { get; set; }
        private int arrowDirection { get; set; } // left, down, right
        private List<Lot> UnbuyableLots { get; set; }

        private Dictionary<int, Block2> blocks;

        public BlockData()
        {
            LotData lotData = new LotData();

            blocks = new Dictionary<int, Block2>()
            {
                { 1, new Block2() { arrowDirection = 3, name = "Container Port", Lots = lotData.GetLotData(1) } },
                { 2, new Block2() { arrowDirection = 2, name = "Halestown", Lots = lotData.GetLotData(2) } },
                { 3, new Block2() { arrowDirection = 1, name = "Lyndal", Lots = lotData.GetLotData(3) } },
                { 4, new Block2() { arrowDirection = 2, name = "Matthews Yard", Lots = lotData.GetLotData(4) } },
                { 5, new Block2() { arrowDirection = 2, name = "Morrell Grove", Lots = lotData.GetLotData(5) } },
                { 6, new Block2() { arrowDirection = 3, name = "Municipal Airport", Lots = lotData.GetLotData(6) } },
                { 7, new Block2() { arrowDirection = 3, name = "Nature Reserve", Lots = lotData.GetLotData(7) } },
                { 8, new Block2() { arrowDirection = 2, name = "Radziewiczwich", Lots = lotData.GetLotData(8) } },
                { 9, new Block2() { arrowDirection = 3, name = "Ridgeway", Lots = lotData.GetLotData(9) } },
                { 10, new Block2() { arrowDirection = 1, name = "Train Station", Lots = lotData.GetLotData(10) } },
            };
        }

        public Dictionary<int, Block2> GetAllBlockData()
        {
            return blocks;
        }

        public Block2 GetBlockData(int id)
        {
            return blocks[id];
        }
    }
}
