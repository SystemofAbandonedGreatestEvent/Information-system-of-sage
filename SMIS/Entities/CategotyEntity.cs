using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMIS.Entities
{
    class CategoryEntity
    {
        public string Id { get; private set; }
        public Dictionary<string, string> Category { get; set; }

        public CategoryEntity(string strId, Dictionary<string, string> strCategory)
        {
            this.Id = strId;
            this.Category = strCategory;
        }
    }
}
