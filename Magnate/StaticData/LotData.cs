using Magnate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.StaticData
{
    public class LotData
    {
        private Dictionary<int, List<Lot>> lots;

        public LotData()
        {
            lots = new Dictionary<int, List<Lot>>()
            {
                { 1, new List<Lot>()    // Container Port     A r+; F y+g-; I y+g-
                    {
                        new Lot(0) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(27) } },
                        new Lot(1) { },
                        new Lot(2) { },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(25), ModifierData.GetModifier(26) } },
                        new Lot(6) { },
                        new Lot(7) { },
                        new Lot(8) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(25), ModifierData.GetModifier(26) } }
                    }
                },
                { 2, new List<Lot>()    // Halestown          F g+; G y+
                    {
                        new Lot(0) { },
                        new Lot(1) { },
                        new Lot(2) { },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(18) } },
                        new Lot(6) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(31) } },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 3, new List<Lot>()    // Lyndal             A g+; F g+
                    {
                        new Lot(0) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(18) } },
                        new Lot(1) { },
                        new Lot(2) { },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(22) } },
                        new Lot(6) { },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 4, new List<Lot>()    // Matthews Yard      C b+; D g+
                    {
                        new Lot(0) { },
                        new Lot(1) { },
                        new Lot(2) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(30) } },
                        new Lot(3) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(18) } },
                        new Lot(4) { },
                        new Lot(5) { },
                        new Lot(6) { },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 5, new List<Lot>()    // Morrell Grove      B g+r+; G g+
                    {
                        new Lot(0) { },
                        new Lot(1) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(21) } },
                        new Lot(2) { },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { },
                        new Lot(6) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(18) } },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 6, new List<Lot>()    // Municipal Airport  C b+g-; F b+g-; G y+r+
                    {
                        new Lot(0) { },
                        new Lot(1) { },
                        new Lot(2) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(23), ModifierData.GetModifier(24) } },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(23), ModifierData.GetModifier(24) } },
                        new Lot(6) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(28) } },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 7, new List<Lot>()    // Nature Reserve     B g+y-; C g+y-; F g+y-
                    {
                        new Lot(0) { },
                        new Lot(1) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(19), ModifierData.GetModifier(20) } },
                        new Lot(2) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(19), ModifierData.GetModifier(20) } },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(19), ModifierData.GetModifier(20) } },
                        new Lot(6) { },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 8, new List<Lot>()    // Radziewiczwich     A g+; H b+y+
                    {
                        new Lot(0) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(18) } },
                        new Lot(1) { },
                        new Lot(2) { },
                        new Lot(3) { },
                        new Lot(4) { },
                        new Lot(5) { },
                        new Lot(6) { },
                        new Lot(7) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(29) } },
                        new Lot(8) { }
                    }
                },
                { 9, new List<Lot>()    // Ridgeway           C g+; D r+;
                    {
                        new Lot(0) { },
                        new Lot(1) { },
                        new Lot(2) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(18) } },
                        new Lot(3) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(27) } },
                        new Lot(4) { },
                        new Lot(5) { },
                        new Lot(6) { },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
                { 10, new List<Lot>()   // Train Station      D g+b+; E g+b+
                    {
                        new Lot(0) { },
                        new Lot(1) { },
                        new Lot(2) { },
                        new Lot(3) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(17) } },
                        new Lot(4) { AdjacencyMods = new List<Modifier>() { ModifierData.GetModifier(17) } },
                        new Lot(5) { },
                        new Lot(6) { },
                        new Lot(7) { },
                        new Lot(8) { }
                    }
                },
            };
        }

        public List<Lot> GetLotData(int blockDataId)
        {
            return lots[blockDataId];
        }

    }
}
