using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magnate.Models
{
    public class TestClass
    {
        public string id { get; set; }
    }

    public class Block
    {
        public int id { get; set; }
        public List<Tenant> Tenants { get; set; }
        public List<Dice> Dice { get; set; }
    }

    public class BlockItem
    {
        public int type { get; set; }
        public int count { get; set; }
        public bool affected { get; set; }
    }

    public class Tenant : BlockItem
    {
        public void AddTenant()
        {
            if (type == 1 || type == 2)
                count++;
            else if (type == 3 || type == 4)
                count += 3;
        }

    }

    public class Dice : BlockItem
    {

    }

}
