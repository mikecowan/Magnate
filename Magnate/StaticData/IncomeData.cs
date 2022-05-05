using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.StaticData
{
    public static class IncomeData
    {
        private static Dictionary<int, int> Incomes = new Dictionary<int, int>()
        {
            { 1, 300 },
            { 2, 100 },
            { 3, 300 },
            { 4, 500 },
            { 5, 300 },
            { 6, 300 },
            { 7, 300 },
            { 8, 500 },
            { 9, 800 },
            { 10, 700 },
            { 11, 800 },
            { 12, 1200 },
            { 13, 600 },
            { 14, 500 },
            { 15, 700 },
            { 16, 800 }
        };

        private static int[,] TenantIncomes = new int[,]
        {
            { 1, 0, 300 },
            { 1, 1, 100 },
            { 1, 2, 300 },
            { 1, 3, 500 },
            { 2, 0, 300 },
            { 2, 1, 300 },
            { 2, 2, 300 },
            { 2, 3, 500 },
            { 3, 0, 800 },
            { 3, 1, 700 },
            { 3, 2, 800 },
            { 3, 3, 1200 },
            { 4, 0, 600 },
            { 4, 1, 500 },
            { 4, 2, 700 },
            { 4, 3, 800 },
        };

        public static int GetCorrectIncome(int buildingtype, int subtype)
        {
            int map = 4 * (buildingtype - 1) + subtype + 1;
            return Incomes[map];
        }

        public static int GetTenantIncome(int buildingtype, int subtype)
        {
            return TenantIncomes[buildingtype, subtype];
        }

    }
}
