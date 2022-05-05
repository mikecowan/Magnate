using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Magnate.Domain;
using Magnate.Factories;
using Magnate.Models;
using Magnate.StaticData;
using Microsoft.AspNetCore.Mvc;

namespace Magnate.Controllers
{
    public class MagnateController : Controller
    {
        public IActionResult Index()
        {
            MagnateViewModel vm = new MagnateViewModel();
            return View(vm);
        }

        public IActionResult CreateNewGame(int[] blockArray)
        {
            MagnateViewModel vm = new MagnateViewModel();
            var blockData = new BlockData();
            vm.Block2List[0].name = "Central City";

            for (int i = 1; i <= 6; i++)
            {
                vm.Block2List[i] = blockData.GetBlockData(blockArray[i - 1]);
                vm.Block2List[i].id = i;
            }

            Mgmt mgmt = new Mgmt(vm.Block2List);
            mgmt.RotateBlocks();

            return View("_City", vm);
        }

        public IActionResult Buy(UserInputModel uim, List<Block2> Blocks)
        {
            var newLot = Blocks.Find(bl => bl.id == uim.blocknum).Lots.Find(x => x.id == uim.lotnum);
            newLot.LotOwner = uim.companynum;
            newLot.salePoints = uim.salepoints;

            Mgmt mgmt = new Mgmt(Blocks);

            for (int i = 0; i < 4; i++)
            {
                newLot.DiceByType[i] = mgmt.ComputeDice(newLot, i + 1);
            }

            MagnateViewModel vm = new MagnateViewModel()
            {
                userInputViewModel = uim,
                lotnum = uim.lotnum,
                blocknum = uim.blocknum,
                marketvalue = uim.marketvalue,
                lotViewModel = new LotViewModel()
                {
                    thisBlock = Blocks.Find(bl => bl.id == uim.blocknum)
                }
            };

            // update and return _Lot so you can populate data-salepoints
            return PartialView("_Lot", vm);
        }

        public IActionResult Sell(UserInputModel uim, List<Block2> Blocks)
        {
            var newLot = Blocks.Find(bl => bl.id == uim.blocknum).Lots.Find(x => x.id == uim.lotnum);
            newLot.LotOwner = 0;
            newLot.salePoints = 0;
            newLot.Building.tenantCapacity = CapacityData.GetBuildingCapacity(uim.buildingnum);

            var mgmt = new Mgmt(Blocks);
            mgmt.PopulateMissingDataWithViewData();
            mgmt.SetAllUniqueSelfAdjacencyModifiers(newLot);

            MagnateViewModel vm = new MagnateViewModel()
            {
                userInputViewModel = uim,
                lotnum = uim.lotnum,
                blocknum = uim.blocknum,
                marketvalue = uim.marketvalue,
                lotViewModel = new LotViewModel()
                {
                    thisBlock = Blocks.Find(bl => bl.id == uim.blocknum)
                }
            };

            return PartialView("_Lot", vm);
        }

        public IActionResult AddBuilding(UserInputModel uim, List<Block2> Blocks, int blocknum)
        {
            var mgmt = new Mgmt(Blocks);
            mgmt.PopulateMissingDataWithViewData();

            var block = Blocks.Find(bl => bl.id == uim.blocknum);
            var lot = block.Lots.Find(x => x.id == uim.lotnum);
            lot.Building = BuildingFactory.BuildBuilding(uim.buildingnum);
            lot.LotOwner = uim.companynum;

            // set salepoints for each lot with an owner
            mgmt.SetSalePoints(block);
            mgmt.SetDice(block);

            foreach (var item in block.Lots)
            {
                mgmt.SetAllUniqueSelfAdjacencyModifiers(item);
            }

            // return entire block because the new building could have an adjacency bonus
            MagnateViewModel vm = new MagnateViewModel(Blocks)
            {
                //blocknum = blocknum,
                marketvalue = uim.marketvalue,
                lotViewModel = new LotViewModel()
                {
                    thisBlock = Blocks.Find(bl => bl.id == uim.blocknum)
                }
            };

            return PartialView("_Block", vm);
        }

        public IActionResult AddTenant(UserInputModel uim, List<Block2> Blocks)
        {
            var mgmt = new Mgmt(Blocks);
            mgmt.PopulateMissingDataWithViewData();

            // adding a tenant will be the most complex operation
            // 1. adjusts sale price
            //    a. because there is at least one extra "point"
            //    b. possibility of adjacency bonus for other Lots
            // 2. adjusts income
            // 3. possibly adjusts dice rolls for adjacent blocks
            var lot = Blocks.Find(bl => bl.id == uim.blocknum).Lots.Find(x => x.id == uim.lotnum);

            if (Maps.BuildingType(lot.Building.buildingNum) == Maps.BuildingTypeFromTenantNum(uim.tenantnum) && lot.Building.tenantCount < CapacityData.GetBuildingCapacity(lot.Building.buildingNum))
                lot.Building.Tenants.Add(TenantFactory.BuildTenant(uim.tenantnum));

            foreach (var block in Blocks)
            {
                mgmt.SetSalePoints(block);
                mgmt.SetDice(block);

                foreach (var item in block.Lots)
                {
                    mgmt.SetAllUniqueSelfAdjacencyModifiers(item);
                }
            }

            MagnateViewModel vm = new MagnateViewModel(Blocks)
            {
                marketvalue = uim.marketvalue
            };

            return View("_City", vm);
        }

        public IActionResult AdjustIncome(UserInputModel uim, List<Block2> Blocks)
        {
            var mgmt = new Mgmt(Blocks);
            MagnateViewModel vm = new MagnateViewModel(Blocks);

            vm.companynum = uim.companynum;
            vm.income = mgmt.ComputeIncome(uim.companynum);

            return View("_SingleCompanyIncome", vm);
        }

        public IActionResult InspectLot(UserInputModel uim, List<Block2> Blocks)
        {
            var buildingTenants = Blocks[uim.blocknum].Lots[uim.lotnum].Building.Tenants;

            if (buildingTenants != null)
            {
                foreach (var tenant in buildingTenants)
                {
                    tenant.AdjacencyMod = ModifierFactory.GetTenantAdjacencyModifier(tenant.type, tenant.subtype);
                    tenant.income = IncomeFactory.TenantIncome(tenant.type, tenant.subtype);
                }
            }
            else
            {
                buildingTenants = new List<Tenant2>();
            }

            MagnateViewModel vm = new MagnateViewModel(Blocks)
            {
                blocknum = uim.blocknum,
                lotnum = uim.lotnum
            };

            return View("_Lot", vm);
        }

    }
}

// populate each building on the block and add tenants
//      with building and tenant modifiers on the block because they aren't stored on the view
//foreach (var item in block.Lots)
//{
//    if (item.Building.buildingNum != 0)
//    {
//        item.Building = BuildingFactory.BuildBuilding(item.Building.buildingNum);
//        foreach (var tenant in item.Building.Tenants)
//        {
//            item.Building.Tenants.Add(TenantFactory.BuildTenant(tenant.type, tenant.subtype));
//        }
//    }
//    else
//    {
//        item.Building.Tenants = new List<Tenant2>();
//        if (item.AdjacencyMods != null && item.AdjacencyMods.Any())
//        {
//            foreach (var mod in item.AdjacencyMods)
//            {
//                var fullmod = ModifierData.GetModifier(mod.id);
//                mod.affectedBuildingTypes = fullmod.affectedBuildingTypes;
//                mod.value = fullmod.value;
//            }
//        }
//    }
//}
