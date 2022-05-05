using Magnate.Domain;
using Magnate.Models;
using Magnate.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Factories
{
    public static class ModifierFactory
    {
        //public static Modifier GetTenantAdjacencyModifier(int buildingnum)
        //{
        //    return GetTenantAdjacencyModifier(Maps.BuildingType(buildingnum), Maps.BuildingSubtype(buildingnum));
        //}

        public static Modifier GetTenantAdjacencyModifier(int buildingtype, int subtype)
        {
            switch (buildingtype)
            {
                case 1:
                    //    0: home        300
                    //    1: students    100
                    //    2: pro couple  300 +r
                    //    3: family      500 +g
                    if (subtype == 2)
                        return ModifierData.GetModifier(1);
                    else if (subtype == 3)
                        return ModifierData.GetModifier(2);
                    break;
                case 2:
                    //    retail      300 +b
                    //    conv store  300 +g +b
                    //    restaurant  300 +r
                    //    boutique    500
                    if (subtype == 0)
                        return ModifierData.GetModifier(3);
                    else if (subtype == 1)
                        return ModifierData.GetModifier(4);
                    else if (subtype == 2)
                        return ModifierData.GetModifier(5);
                    break;
                case 3:
                    //    office      800 +r +b
                    //    tech co     700 +r +b
                    //    call center 800
                    //    law firm    1200 +b
                    if (subtype == 0)
                        return ModifierData.GetModifier(6);
                    else if (subtype == 1)
                        return ModifierData.GetModifier(7);
                    else if (subtype == 3)
                        return ModifierData.GetModifier(8);
                    break;
                case 4:
                    //    industry    600 -g
                    //    warehouse   500 +y
                    //    sm factory  700 -g
                    //    chem plant  800 -g -r -b
                    if (subtype == 0)
                        return ModifierData.GetModifier(9);
                    else if (subtype == 1)
                        return ModifierData.GetModifier(10);
                    else if (subtype == 2)
                        return ModifierData.GetModifier(11);
                    else if (subtype == 3)
                        return ModifierData.GetModifier(12);
                    break;
            }

            return ModifierData.GetModifier(0);
        }

        public static Modifier GetBuildingSelfModifier(int buildingnum)
        {
            switch (buildingnum)
            {
                case 3:
                    return ModifierData.GetModifier(13);
                case 5:
                    return ModifierData.GetModifier(14);
                case 7:
                    return ModifierData.GetModifier(15);
            }

            return ModifierData.GetModifier(0);
        }

        public static Modifier GetBuildingAdjacencyModifier(int buildingnum)
        {
            if (buildingnum == 3)
            {
                return ModifierData.GetModifier(16);
            }

            return ModifierData.GetModifier(0);
        }

        public static Modifier GetLotModifier(int lottype)
        {
            return ModifierData.GetModifier(lottype);
        }

    }
}
