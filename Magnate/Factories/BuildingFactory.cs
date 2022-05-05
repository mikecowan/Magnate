using Magnate.Domain;
using Magnate.Models;
using Magnate.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Factories
{
    public static class BuildingFactory
    {
        public static Building BuildBuilding(int buildingnum)
        {
            Building b = new Building();

            b.buildingNum = buildingnum;
            b.tenantCount = 0;
            b.population = 0;

            b.buildingType = Maps.BuildingType(buildingnum);
            b.buildingRank = Maps.BuildingSubtype(buildingnum);

            b.Tenants = new List<Tenant2>();
            b.tenantCapacity = CapacityData.GetBuildingCapacity(buildingnum);

            b.AdjacencyMod = ModifierFactory.GetBuildingAdjacencyModifier(buildingnum);
            b.SelfMod = ModifierFactory.GetBuildingSelfModifier(buildingnum);

            return b;
        }

        public static Building BuildStartingBuilding(int buildingnum)
        {
            Building b = BuildBuilding(buildingnum);

            var tenant = TenantFactory.BuildTenant(Maps.BuildingType(buildingnum), 0);
            b.tenantCapacity = CapacityData.GetBuildingCapacity(buildingnum);

            if (buildingnum == 2)
                b.tenantCapacity = 3;

            for (int i = 0; i < b.tenantCapacity; i++)
            {
                b.Tenants.Add(tenant);
            }

            return b;
        }

    }
}
