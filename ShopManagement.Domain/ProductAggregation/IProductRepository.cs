using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domin;

namespace ShopManagement.Domain.ProductAggregation
{
    public interface IProductRepository : IRepository<long,Product>
    {
    }
}
