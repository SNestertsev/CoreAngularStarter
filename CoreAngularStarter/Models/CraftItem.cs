using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngularStarter.Models
{
    public class CraftItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Available { get; set; }

        public ICollection<CategoryItem> Categories { get; set; }
    }
}
