using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domin;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAggregation
{
    public interface IProductRepository : IRepository<long,Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel command);

    }
}
