using Magnate.Factories;
using Magnate.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class MagnateViewModel
    {
        //public List<Block> Blocks { get; set; }
        public int selectedBlockNumber { get; set; }
        public int selectedTenantType { get; set; }

        public List<Block2> Block2List { get; set; }

        public int companynum { get; set; }
        public int blocknum { get; set; }
        public int lotnum { get; set; }
        public int income { get; set; }

        public int buildingnum { get; set; }
        public Tenant2 tenant { get; set; }

        public List<string> BlockNames { get; set; }
        public UserInputModel userInputViewModel { get; set; }
        public LotViewModel lotViewModel { get; set; }
        public bool InitialPageLoad { get; set; }

        public int marketvalue { get; set; }

        public MagnateViewModel()
        {
            userInputViewModel = new UserInputModel();
            lotViewModel = new LotViewModel();
            Block2List = new List<Block2>();
            InitialPageLoad = true;

            Block2List.Add(new Block2()
            {
                id = 0,
                Lots = new List<Lot>()
                {
                    new Lot(0, BuildingFactory.BuildStartingBuilding(2)),
                    new Lot(1, BuildingFactory.BuildStartingBuilding(2)),
                    new Lot(2, BuildingFactory.BuildStartingBuilding(4)),
                    new Lot(3, BuildingFactory.BuildStartingBuilding(4)),
                    new Lot(4, BuildingFactory.BuildStartingBuilding(6)),
                    new Lot(5, BuildingFactory.BuildStartingBuilding(6)),
                    new Lot(6, BuildingFactory.BuildStartingBuilding(8)),
                    new Lot(7, BuildingFactory.BuildStartingBuilding(8)),
                    new Lot(8)
                }
            });

            for (int i = 1; i <= 6; i++)
            {
                Block2List.Add(new Block2()
                {
                    id = i,
                });
            }

            //foreach (var block in Block2List)
            //{
            //    if (block.id != 0)
            //    {
            //        var leftNeighborIndex = block.id == 1 ? 6 : block.id - 1;
            //        var rightNeighborIndex = block.id == 6 ? 1 : block.id + 1;

            //        block.LeftNeighbor = Block2List.Find(x => x.id == leftNeighborIndex);
            //        block.RightNeighbor = Block2List.Find(x => x.id == rightNeighborIndex);
            //    }
            //}

            BlockNames = new List<string>();
            BlockNames.Add("Center City");
            var blockData = new BlockData();
            for (int i = 1; i <= 10; i++)
            {
                BlockNames.Add(blockData.GetBlockData(i).name);
            }
        }

        public MagnateViewModel(List<Block2> Blocks)
        {
            userInputViewModel = new UserInputModel();
            lotViewModel = new LotViewModel();
            Block2List = Blocks;
        }
    }
}
