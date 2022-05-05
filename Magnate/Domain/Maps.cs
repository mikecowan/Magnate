using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Domain
{
    public static class Maps
    {
        public static int BuildingNum(int buildingtype, int subtype)
        {
            if (buildingtype == 0)
                return 0;
            if (buildingtype == 1)
                return subtype;
            else
                return 2 * buildingtype + subtype - 1;
        }

        public static int BuildingType(int buildingnum)
        {
            if (buildingnum == 0)
                return 0;
            else if (buildingnum < 4)
                return 1;
            else
                return (int)Math.Floor(.5 * buildingnum);
        }

        public static int BuildingSubtype(int buildingnum)
        {
            if (buildingnum < 4)
                return buildingnum;
            else
                return (buildingnum % 2) + 1;
        }

        public static int BuildingTypeFromTenantNum(int tenantnum)
        {
            return (int) Math.Ceiling(.25 * tenantnum);
        }

        public static int BuildingSubtypeFromTenantNum(int tenantnum)
        {
            return (tenantnum - 1) % 4;
        }

    }
}
