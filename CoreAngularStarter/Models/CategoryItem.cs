using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngularStarter.Models
{
    public class CategoryItem
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int CraftItemID { get; set; }

        public Category Category { get; set; }
        public CraftItem CraftItem { get; set; }
    }
}
