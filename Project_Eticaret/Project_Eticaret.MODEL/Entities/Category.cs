using Project_Eticaret.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Entities
{
    public class Category : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // 1 kategorinin birden falza alt kategorisi olabilir.
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
