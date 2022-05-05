using Magnate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.StaticData
{
    public static class ModifierData
    {
        private static List<Modifier> Modifiers = new List<Modifier>()
        {
            new Modifier() { id = 0, affectedBuildingTypes = new List<int>(), value = 0 },

            // residential tenant adjacency
            new Modifier() { id = 1, affectedBuildingTypes = new List<int> { 2 }, value = 1 },
            new Modifier() { id = 2, affectedBuildingTypes = new List<int> { 1 }, value = 1 },

            // retail tenant adjacency
            new Modifier() { id = 3, affectedBuildingTypes = new List<int> { 3 }, value = 1 },
            new Modifier() { id = 4, affectedBuildingTypes = new List<int> { 1, 3 }, value = 1 },
            new Modifier() { id = 5, affectedBuildingTypes = new List<int> { 2 }, value = 1 },

            // commercial tenant adjacency
            new Modifier() { id = 6, affectedBuildingTypes = new List<int> { 2, 3 }, value = 1 },
            new Modifier() { id = 7, affectedBuildingTypes = new List<int> { 2, 3 }, value = 1 },
            new Modifier() { id = 8, affectedBuildingTypes = new List<int> { 3 }, value = 1 },

            // industrial tenant adjacency
            new Modifier() { id = 9, affectedBuildingTypes = new List<int> { 1 }, value = -1 },
            new Modifier() { id = 10, affectedBuildingTypes = new List<int> { 4 }, value = 1 },
            new Modifier() { id = 11, affectedBuildingTypes = new List<int> { 1 }, value = -1 },
            new Modifier() { id = 12, affectedBuildingTypes = new List<int> { 1, 2, 3 }, value = -1 },

            // premium building self bonuses
            new Modifier() { id = 13, affectedBuildingTypes = new List<int> { 1 }, value = 1 }, // luxury tower
            new Modifier() { id = 14, affectedBuildingTypes = new List<int> { 2 }, value = 1 }, // mall
            new Modifier() { id = 15, affectedBuildingTypes = new List<int> { 3 }, value = 1 }, // office tower

            // luxury tower adjacency
            new Modifier() { id = 16, affectedBuildingTypes = new List<int> { 2, 3 }, value = 1 },

            // printed Lot modifiers
            new Modifier() { id = 17, affectedBuildingTypes = new List<int> { 1, 3 }, value = 1 },  // train station
            new Modifier() { id = 18, affectedBuildingTypes = new List<int> { 1 }, value = 1 },     // forest
            new Modifier() { id = 19, affectedBuildingTypes = new List<int> { 1 }, value = 1 },     // nature reserve A
            new Modifier() { id = 20, affectedBuildingTypes = new List<int> { 4 }, value = -1 },    // nature reserve B
            new Modifier() { id = 21, affectedBuildingTypes = new List<int> { 1, 2 }, value = 1 },  // rec center with basketball
            new Modifier() { id = 22, affectedBuildingTypes = new List<int> { 1 }, value = 1 },     // playground
            new Modifier() { id = 23, affectedBuildingTypes = new List<int> { 1 }, value = -1 },    // airport A
            new Modifier() { id = 24, affectedBuildingTypes = new List<int> { 3 }, value = 1 },     // airport B
            new Modifier() { id = 25, affectedBuildingTypes = new List<int> { 1 }, value = -1 },    // harbor shipping center A
            new Modifier() { id = 26, affectedBuildingTypes = new List<int> { 4 }, value = 1 },     // harbor shipping center B
            new Modifier() { id = 27, affectedBuildingTypes = new List<int> { 2 }, value = 1 },     // retail parking lot
            new Modifier() { id = 28, affectedBuildingTypes = new List<int> { 2, 4 }, value = 1 },  // airport parking lot
            new Modifier() { id = 29, affectedBuildingTypes = new List<int> { 3, 4 }, value = 1 },  // highway
            new Modifier() { id = 30, affectedBuildingTypes = new List<int> { 3 }, value = 1 },     // office plaza fountain
            new Modifier() { id = 31, affectedBuildingTypes = new List<int> { 4 }, value = 1 },     // industrial parking lot
        };

        //public ModifierData()
        //{
        //    Modifiers = new List<Modifier>();

        //    // no mod
        //    Modifiers.Add(new Modifier() { id = 0, affectedBuildingTypes = new List<int>(), value = 0 });

        //    // residential tenant adjacency
        //    Modifiers.Add(new Modifier() { id = 1, affectedBuildingTypes = new List<int> { 2 }, value = 1 });
        //    Modifiers.Add(new Modifier() { id = 2, affectedBuildingTypes = new List<int> { 1 }, value = 1 });

        //    // retail tenant adjacency
        //    Modifiers.Add(new Modifier() { id = 3, affectedBuildingTypes = new List<int> { 3 }, value = 1 });
        //    Modifiers.Add(new Modifier() { id = 4, affectedBuildingTypes = new List<int> { 1, 3 }, value = 1 });
        //    Modifiers.Add(new Modifier() { id = 5, affectedBuildingTypes = new List<int> { 2 }, value = 1 });

        //    // commercial tenant adjacency
        //    Modifiers.Add(new Modifier() { id = 6, affectedBuildingTypes = new List<int> { 2, 3 }, value = 1 });
        //    Modifiers.Add(new Modifier() { id = 7, affectedBuildingTypes = new List<int> { 2, 3 }, value = 1 });
        //    Modifiers.Add(new Modifier() { id = 8, affectedBuildingTypes = new List<int> { 3 }, value = 1 });

        //    // industrial tenant adjacency
        //    Modifiers.Add(new Modifier() { id = 9, affectedBuildingTypes = new List<int> { 1 }, value = -1 });
        //    Modifiers.Add(new Modifier() { id = 10, affectedBuildingTypes = new List<int> { 4 }, value = 1 });
        //    Modifiers.Add(new Modifier() { id = 11, affectedBuildingTypes = new List<int> { 1 }, value = -1 });
        //    Modifiers.Add(new Modifier() { id = 12, affectedBuildingTypes = new List<int> { 1, 2, 3 }, value = -1 });

        //    // premium building self bonuses
        //    Modifiers.Add(new Modifier() { id = 13, affectedBuildingTypes = new List<int> { 1 }, value = 1 }); // luxury tower
        //    Modifiers.Add(new Modifier() { id = 14, affectedBuildingTypes = new List<int> { 2 }, value = 1 }); // mall
        //    Modifiers.Add(new Modifier() { id = 15, affectedBuildingTypes = new List<int> { 3 }, value = 1 }); // office tower

        //    // luxury tower adjacency
        //    Modifiers.Add(new Modifier() { id = 16, affectedBuildingTypes = new List<int> { 2, 3 }, value = 1 });
        //}

        public static Modifier GetModifier(int id)
        {
            return Modifiers.Find(x => x.id == id);
        }

    }
}
