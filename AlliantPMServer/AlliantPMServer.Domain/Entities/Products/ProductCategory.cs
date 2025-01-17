using AlliantPMServer.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantPMServer.Domain.Entities.Products
{
    public class ProductCategory : CoreEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
