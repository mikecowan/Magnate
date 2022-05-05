using Magnate.Factories;
using Magnate.Models;
using Magnate.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Domain
{
    public class Mgmt
    {
        public List<Block> Blocks;
        public List<Block2> Block2List;

        public Mgmt(List<Block> blocks)
        {
            Blocks = blocks;
        }

        public Mgmt(List<Block2> blocks)
        {
            for (int i = 1; i <= 6; i++)
            {
                var block = blocks[i];
                foreach (var item in block.Lots)
                {
                    if (item.Building == null)
                    {
                        item.Building = new Building();
                    }

                    if (item.Building.Tenants == null)
                    {
                        item.Building.Tenants = new List<Tenant2>();
                    }
                }
            }

            Block2List = blocks;
        }

        public void RotateBlocks()
        {
            for (int i = 1; i <= 6; i++)
            {
                switch (i)
                {
                    case 1:
                        // 1 L: 1
                        // 2 D: 2
                        // 3 R: 3
                        Rotate(Block2List[i], Block2List[i].arrowDirection);
                        break;
                    case 2:
                    case 3:
                        // 1 L: 2
                        // 2 D: 3
                        // 3 R: 0
                        Rotate(Block2List[i], (Block2List[i].arrowDirection + 1) % 4);
                        break;
                    case 4:
                        // 1 L: 3
                        // 2 D: 0
                        // 3 R: 1
                        Rotate(Block2List[i], (Block2List[i].arrowDirection + 2) % 4);
                        break;
                    case 5:
                    case 6:
                        // 1 L: 0
                        // 2 D: 1
                        // 3 R: 2
                        Rotate(Block2List[i], Block2List[i].arrowDirection -1);
                        break;
                }
            }
        }

        private void Rotate(Block2 block, int clicks)
        {
            if (clicks != 0)
            {
                var copyBlock = CopyBock(block);
                var rotationArray = new int[9] { 0,1,2,3,4,5,6,7,8 };
                switch (clicks)
                {
                    case 1:
                        rotationArray = new int[9] { 6, 3, 0, 7, 4, 1, 8, 5, 2 };
                        break;
                    case 2:
                        rotationArray = new int[9] { 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                        break;
                    case 3:
                        rotationArray = new int[9] { 2, 5, 8, 1, 4, 7, 0, 3, 6 };
                        break;
                }

                for (int i = 0; i < 9; i++)
                {
                    block.Lots[i] = copyBlock.Lots[rotationArray[i]];
                    block.Lots[i].id = i;
                }
            }
        }

        private Block2 CopyBock(Block2 bl)
        {
            var copy = new Block2()
            {
                id = bl.id,
                name = bl.name,
                arrowDirection = bl.arrowDirection
            };

            copy.Lots = new List<Lot>();
            foreach (var lot in bl.Lots)
            {
                var newlot = new Lot(lot.id)
                {
                    blocknum = lot.blocknum,
                    dice = lot.dice,
                    salePoints = lot.salePoints
                };

                if (lot.AdjacencyMods != null)
                {
                    newlot.AdjacencyMods = new List<Modifier>();
                    foreach (var mod in lot.AdjacencyMods)
                    {
                        newlot.AdjacencyMods.Add(mod);
                    }
                }

                copy.Lots.Add(newlot);
            }

            return copy;
        }

        public int ComputeIncome(int companynum)
        {
            var lots = Block2List.SelectMany(x => x.Lots.Where(y => y.LotOwner == companynum));
            int income = 0;

            foreach (var lot in lots)
            {
                int lotIncome = lot.Building.Tenants.Sum(x => IncomeData.GetCorrectIncome(x.type, x.subtype));

                income += lotIncome;
            }

            return income;
        }

        public List<Block> ComputeDice()
        {

            for (int i = 1; i <= 6; i++)
            {
                var selfBlock = Blocks.Find(x => x.id == i);
                selfBlock.Dice = new List<Dice>();
                // get nA and nB

                // compute dice for type 1,2,3,4
                for (int j = 1; j <= 4; j++)
                {
                    selfBlock.Dice.Add(new Dice()
                    {
                        type = j,
                        count = ComputeDice(i, j)
                    });
                }
            }

            return Blocks;
        }

        private int[] GetNeighborBlockIndices(int selfIndex)
        {
            var indices = new int[3];

            var neighborAindex = selfIndex - 1;
            var neighborBindex = selfIndex + 1;

            if (neighborAindex == 0)
                neighborAindex = 6;
            if (neighborBindex == 7)
                neighborBindex = 1;

            indices[0] = 0;
            indices[1] = neighborAindex;
            indices[2] = neighborBindex;

            return indices;
        }

        private int ComputeDice(int blocknum, int type)
        {
            var indices = GetNeighborBlockIndices(blocknum);

            if (type == 1)
            {
                var retailers = Blocks.FindAll(x => indices.Contains(x.id) || blocknum == x.id).Sum(y => y.Tenants.Find(z => z.type == 2).count);
                var offices = Blocks.FindAll(x => indices.Contains(x.id) || blocknum == x.id).Sum(y => y.Tenants.Find(z => z.type == 3).count);

                return Math.Min(retailers, offices);
            }
            else if (type == 2 || type == 3)
            {
                return Blocks.FindAll(x => indices.Contains(x.id) || blocknum == x.id).Sum(y => y.Tenants.Find(z => z.type == 1).count);
            }
            else
            {
                var residential = Blocks.FindAll(x => indices.Contains(x.id) || blocknum == x.id).Sum(y => y.Tenants.Find(z => z.type == 1).count);
                var industrial = Blocks.FindAll(x => indices.Contains(x.id) || blocknum == x.id).Sum(y => y.Tenants.Find(z => z.type == 4).count);

                return Math.Min(residential, industrial);
            }
        }

        public int ComputeDice(Lot lot, int buildingtype = 0)
        {
            var centralBlock = Block2List[0];
            var selfBlock = Block2List.Find(bl => bl.id == lot.blocknum);
            var neighbors = GetNeighborBlockIndices(selfBlock.id);
            selfBlock.LeftNeighbor = Block2List.Find(bl => bl.id == neighbors[1]);
            selfBlock.RightNeighbor = Block2List.Find(bl => bl.id == neighbors[2]);

            var buildingOnLot = Maps.BuildingType(lot.Building.buildingNum);
            if (buildingOnLot != 0)
                buildingtype = buildingOnLot;

            switch (buildingtype)
            {
                case 1:
                    var retailPopulation = Block2List.FindAll(x => neighbors.Contains(x.id) || lot.blocknum == x.id).SelectMany(x => x.Lots).Where(x => x.Building != null && Maps.BuildingType(x.Building.buildingNum) == 2).Sum(x => x.Building?.Tenants?.Count ?? 0);

                    var ret1 = Block2List.FindAll(x => neighbors.Contains(x.id) || lot.blocknum == x.id);
                    var ret2 = ret1.SelectMany(x => x.Lots);
                    var ret3 = ret2.Where(x => x.Building != null && Maps.BuildingType(x.Building.buildingNum) == 2);
                    var ret4 = ret3.Sum(x => x.Building.Tenants.Count);

                    var officePopulation = 3 * Block2List.FindAll(x => neighbors.Contains(x.id) || lot.blocknum == x.id).SelectMany(x => x.Lots).Where(x => x.Building != null && Maps.BuildingType(x.Building.buildingNum) == 3).Sum(x => x.Building?.Tenants?.Count ?? 0);
                    return Math.Min(retailPopulation, officePopulation);
                case 2:
                case 3:
                    return Block2List.FindAll(x => neighbors.Contains(x.id) || lot.blocknum == x.id).SelectMany(x => x.Lots).Where(x => x.Building != null && Maps.BuildingType(x.Building.buildingNum) == 1).Sum(x => x.Building?.Tenants?.Count ?? 0);
                case 4:
                    var residentialPopulation = Block2List.FindAll(x => neighbors.Contains(x.id) || lot.blocknum == x.id).SelectMany(x => x.Lots).Where(x => x.Building != null && Maps.BuildingType(x.Building.buildingNum) == 1).Sum(x => x.Building?.Tenants?.Count ?? 0);
                    var industrialPopulation = 3 * Block2List.FindAll(x => neighbors.Contains(x.id) || lot.blocknum == x.id).SelectMany(x => x.Lots).Where(x => !(x.blocknum == lot.blocknum && x.id == lot.id) && (x.Building != null && Maps.BuildingType(x.Building.buildingNum) == 4)).Sum(x => x.Building?.Tenants?.Count ?? 0);
                    return Math.Min(residentialPopulation, industrialPopulation);
            }

            return 0;
        }

        public int GetModifierValue(Lot lot, int blocknum)
        {
            var allModifiers = GetAllAdjacentModifiers(lot, blocknum);
            int sum = 0;

            foreach (var item in allModifiers)
            {
                if (item.affectedBuildingTypes.Contains(lot.Building.buildingType))
                {
                    sum += item.value;
                }
            }

            return sum;
        }

        public void SetAllUniqueSelfAdjacencyModifiers(Lot lot)
        {
            foreach (var tenant in lot.Building.Tenants)
            {
                if (!lot.AllUniqueAdjacenyMods.Any(x => x.id == tenant.AdjacencyMod.id))
                {
                    lot.AllUniqueAdjacenyMods.Add(tenant.AdjacencyMod);
                }
            }
            
            if (!lot.AllUniqueAdjacenyMods.Any(x => x.id == lot.Building.AdjacencyMod.id))
            {
                lot.AllUniqueAdjacenyMods.Add(lot.Building.AdjacencyMod);
            }
            
        }

        public List<Modifier> GetAllAdjacentModifiers(Lot lot, int blocknum)
        {
            var modList = new List<Modifier>();
            var adjacentLots = GetAllAdjacentLots(lot, blocknum);

            modList.Add(lot.Building.SelfMod);

            foreach (var item in adjacentLots)
            {
                if (item.AdjacencyMods != null)
                {
                    foreach (var lotmod in item.AdjacencyMods)
                    {
                        modList.Add(lotmod);
                    }
                }

                modList.Add(item.Building.AdjacencyMod);

                if (item.Building.Tenants != null)
                {
                    foreach (var tenant in item.Building.Tenants)
                    {
                        modList.Add(tenant.AdjacencyMod);
                    }
                }
            }

            modList.RemoveAll(x => x == null);
            var reducedList = modList.GroupBy(x => x.id).Select(y => y.First()).ToList();

            foreach (var item in reducedList)
            {
                var mod = ModifierData.GetModifier(item.id);
                item.affectedBuildingTypes = mod.affectedBuildingTypes;
                item.value = mod.value;
            }

            return reducedList;
        }

        public List<Lot> GetAllAdjacentLots(Lot lot, int blocknum)
        {
            var list = new List<Lot>();
            var block = Block2List.Find(bl => bl.id == blocknum);

            foreach (var item in block.Lots)
            {
                if (IsAdjacent(lot, item))
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public bool IsAdjacent(Lot A, Lot B)
        {
            return Math.Abs(ConvertLotIdToRow(A.id) - ConvertLotIdToRow(B.id)) < 2 && Math.Abs(ConvertLotIdToCol(A.id) - ConvertLotIdToCol(B.id)) < 2 && A.id != B.id;
        }

        private int ConvertLotIdToRow(int id)
        {
            return (int)Math.Floor(id / 3.0);
        }

        private int ConvertLotIdToCol(int id)
        {
            return id % 3;
        }


        public void PopulateMissingDataWithViewData()
        {
            // every lot should have a non-null building
            // every building should have a non-null tenant list
            // every non-zero tenant should have income and modifier data
            AddBuildings();
            AddEmptyTenantLists();
            AddTenantIncomeAndModifierData();
            AddLotAdjacencyModifiers();
        }

        private void AddBuildings()
        {
            for (int i = 0; i <= 6; i++)
            {
                foreach (var lot in Block2List[i].Lots)
                {
                    var newBuilding = BuildingFactory.BuildBuilding(lot.Building.buildingNum);

                    if (lot.Building.buildingNum == 0)
                    {
                        lot.Building = newBuilding;
                    }
                    else
                    {
                        lot.Building.AdjacencyMod = newBuilding.AdjacencyMod;
                        lot.Building.SelfMod = newBuilding.SelfMod;
                        lot.Building.buildingType = newBuilding.buildingType;
                        lot.Building.buildingRank = newBuilding.buildingRank;
                        lot.Building.tenantCapacity = newBuilding.tenantCapacity;
                        //lot.Building.AdjacencyMod = newBuilding.AdjacencyMod;
                    }
                }
            }
        }

        private void AddEmptyTenantLists()
        {
            for (int i = 1; i <= 6; i++)
            {
                foreach (var lot in Block2List[i].Lots.Where(x => x.Building.Tenants == null))
                {
                    lot.Building.Tenants = new List<Tenant2>();
                }
            }
        }

        private void AddTenantIncomeAndModifierData()
        {
            for (int i = 1; i <= 6; i++)
            {
                foreach (var lot in Block2List[i].Lots.Where(x => x.Building.buildingNum != 0))
                {
                    foreach (var tenant in lot.Building.Tenants)
                    {
                        tenant.income = IncomeFactory.TenantIncome(tenant.type, tenant.subtype);
                        tenant.AdjacencyMod = ModifierFactory.GetTenantAdjacencyModifier(tenant.type, tenant.subtype);
                    }
                }
            }
        }

        private void AddLotAdjacencyModifiers()
        {
            for (int i = 1; i <= 6; i++)
            {
                foreach (var lot in Block2List[i].Lots.Where(x => x.AdjacencyMods != null))
                {
                    foreach (var mod in lot.AdjacencyMods)
                    {
                        mod.affectedBuildingTypes = ModifierData.GetModifier(mod.id).affectedBuildingTypes;
                        mod.value = ModifierData.GetModifier(mod.id).value;
                    }
                }
            }
        }

        public void SetSalePoints(Block2 block)
        {
            foreach (var item in block.Lots)
            {
                var modifiervalue = 0;

                if (item.LotOwner != 0)
                {
                    modifiervalue++;
                    if (item.Building.buildingNum != 0)
                    {
                        modifiervalue += GetModifierValue(item, block.id) + 1;
                        if (item.Building.buildingType < 3)
                            modifiervalue += item.Building.Tenants.Count;
                        else
                            modifiervalue += 3 * item.Building.Tenants.Count;
                    }
                }

                item.salePoints = modifiervalue;
            }
        }

        public void SetDice(Block2 block)
        {
            foreach (var item in block.Lots)
            {
                item.dice = ComputeDice(item);

                if (item.Building.buildingNum == 0)
                {
                    item.DiceByType = new int[4];
                    for (int i = 0; i < 4; i++)
                    {
                        item.DiceByType[i] = ComputeDice(item, i + 1);
                    }
                }
            }
        }


    }
}
