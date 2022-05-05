using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Magnate.Models;
using Magnate.Domain;

namespace Magnate.Controllers
{
    public class HomeController : Controller
    {
        private MagnateViewModel vm = new MagnateViewModel();

        //public IActionResult Index()
        //{
        //    vm.Blocks = new List<Block>();
        //    vm.Blocks.Add(new Block()
        //    {
        //        id = 0,
        //        Tenants = new List<Tenant>()
        //        {
        //            new Tenant() { type = 1, count = 6 },
        //            new Tenant() { type = 2, count = 4 },
        //            new Tenant() { type = 3, count = 6},
        //            new Tenant() { type = 4, count = 6 }
        //        },
        //        Dice = new List<Dice>()
        //        {
        //            new Dice() { type = 1, count = 0 },
        //            new Dice() { type = 2, count = 0 },
        //            new Dice() { type = 3, count = 0 },
        //            new Dice() { type = 4, count = 0 }
        //        }
        //    });

        //    for (int i = 1; i <= 6; i++)
        //    {
        //        vm.Blocks.Add(new Block()
        //        {
        //            id = i,
        //            Tenants = new List<Tenant>()
        //            {
        //                new Tenant() { type = 1, count = 0 },
        //                new Tenant() { type = 2, count = 0 },
        //                new Tenant() { type = 3, count = 0 },
        //                new Tenant() { type = 4, count = 0 }
        //            },
        //            Dice = new List<Dice>()
        //            {
        //                new Dice() { type = 1, count = 4 },
        //                new Dice() { type = 2, count = 6 },
        //                new Dice() { type = 3, count = 6 },
        //                new Dice() { type = 4, count = 6 }
        //            }
        //        });
        //    }

        //    return View(vm);
        //}

        //public IActionResult AddTenant(List<Block> Blocks, int blockNumber, int tenantType)
        //{
        //    vm.Blocks = Blocks;


        //    return View(vm);
        //}


        //public IActionResult AddTenant(List<Block> Blocks, int blockNumber, int tenantType)
        //{
        //    var selfBlock = Blocks.Find(x => x.id == blockNumber);
        //    selfBlock.Tenants.Find(x => x.type == tenantType).AddTenant();
        //    Mgmt mgmt = new Mgmt(Blocks);

        //    vm.Blocks = mgmt.ComputeDice();

        //    vm.Blocks[0].Dice = new List<Dice>()
        //    {
        //        new Dice() { type = 1, count = 0 },
        //        new Dice() { type = 2, count = 0 },
        //        new Dice() { type = 3, count = 0 },
        //        new Dice() { type = 4, count = 0 }
        //    };

        //    vm.selectedBlockNumber = blockNumber;
        //    vm.selectedTenantType = tenantType;

        //    var neighborAindex = blockNumber == 1 ? 6 : blockNumber - 1;
        //    var neighborBindex = blockNumber == 6 ? 1 : blockNumber + 1;

        //    var neighborA = Blocks.Find(x => x.id == neighborAindex);
        //    var neighborB = Blocks.Find(x => x.id == neighborBindex);

        //    if (tenantType == 1)
        //    {
        //        selfBlock.Tenants.Find(x => x.type == 2).affected = true;
        //        neighborA.Tenants.Find(x => x.type == 2).affected = true;
        //        neighborB.Tenants.Find(x => x.type == 2).affected = true;

        //        selfBlock.Tenants.Find(x => x.type == 3).affected = true;
        //        neighborA.Tenants.Find(x => x.type == 3).affected = true;
        //        neighborB.Tenants.Find(x => x.type == 3).affected = true;

        //        selfBlock.Tenants.Find(x => x.type == 4).affected = true;
        //        neighborA.Tenants.Find(x => x.type == 4).affected = true;
        //        neighborB.Tenants.Find(x => x.type == 4).affected = true;
        //    }
        //    else if (tenantType == 2 || tenantType == 3)
        //    {
        //        selfBlock.Tenants.Find(x => x.type == 1).affected = true;
        //        neighborA.Tenants.Find(x => x.type == 1).affected = true;
        //        neighborB.Tenants.Find(x => x.type == 1).affected = true;
        //    }
        //    else if (tenantType == 4)
        //    {
        //        selfBlock.Tenants.Find(x => x.type == 1).affected = true;
        //        neighborA.Tenants.Find(x => x.type == 1).affected = true;
        //        neighborB.Tenants.Find(x => x.type == 1).affected = true;

        //        selfBlock.Tenants.Find(x => x.type == 4).affected = true;
        //        neighborA.Tenants.Find(x => x.type == 4).affected = true;
        //        neighborB.Tenants.Find(x => x.type == 4).affected = true;
        //    }

        //    return PartialView("_CityView", vm);
        //    //return vm.Blocks[1].Tenants[1].count;
        //}


        [HttpPost]
        public int SimpleClick(int input)
        {
            return input + 1;
        }

        public int PostBlock(TestClass block)
        {
            return 6;
        }

        public int PostList(List<TestClass> Test)
        {
            return 4;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
