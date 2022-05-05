using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.StaticData
{
    public static class CapacityData
    {
        private static Dictionary<int, int> BuildingCapacities = new Dictionary<int, int>()
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 5 },
            { 3, 8 },
            { 4, 2 },
            { 5, 6 },
            { 6, 1 },
            { 7, 3 },
            { 8, 1 },
            { 9, 3 }
        };

        public static int GetBuildingCapacity(int buildingnum)
        {
            return BuildingCapacities[buildingnum];
        }

    }
}
