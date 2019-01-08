using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIICopy
{
    public class Item
    {
        public string name { get; set; }
        public string art { get; set; }
    }

    public class Category
    {
        public string category { get; set; }
        public List<Item> items { get; set; }
    }
}
