using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Factories
{
    public static class IncomeFactory
    {
        public static int TenantIncome(int buildingtype, int subtype)
        {
            switch (buildingtype)
            {
                default:
                case 1:
                    return GetResidentialIncome(subtype);
                case 2:
                    return GetRetailIncome(subtype);
                case 3:
                    return GetCommercialIncome(subtype);
                case 4:
                    return GetIndustrialIncome(subtype);
            }
        }

        private static int GetResidentialIncome(int subtype)
        {
            switch (subtype)
            {
                default:
                case 0:
                    return 300;
                case 1:
                    return 100;
                case 2:
                    return 300;
                case 3:
                    return 500;
            }
        }

        private static int GetRetailIncome(int subtype)
        {
            switch (subtype)
            {
                default:
                case 0:
                    return 300;
                case 1:
                    return 300;
                case 2:
                    return 300;
                case 3:
                    return 500;
            }
        }

        private static int GetCommercialIncome(int subtype)
        {
            switch (subtype)
            {
                default:
                case 0:
                    return 800;
                case 1:
                    return 700;
                case 2:
                    return 800;
                case 3:
                    return 1200;
            }
        }

        private static int GetIndustrialIncome(int subtype)
        {
            switch (subtype)
            {
                default:
                case 0:
                    return 600;
                case 1:
                    return 500;
                case 2:
                    return 700;
                case 3:
                    return 800;
            }
        }

    }
}
