using Magnate.Domain;
using Magnate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Factories
{
    public static class TenantFactory
    {
        public static Tenant2 BuildTenant(int buildingtype, int subtype)
        {
            Tenant2 t = new Tenant2();

            t.type = buildingtype;
            t.subtype = subtype;
            t.income = IncomeFactory.TenantIncome(buildingtype, subtype);
            t.AdjacencyMod = ModifierFactory.GetTenantAdjacencyModifier(buildingtype, subtype);

            return t;
        }

        public static Tenant2 BuildTenant(int tenantnum)
        {
            return BuildTenant(Maps.BuildingTypeFromTenantNum(tenantnum), Maps.BuildingSubtypeFromTenantNum(tenantnum));
        }
    }
}

