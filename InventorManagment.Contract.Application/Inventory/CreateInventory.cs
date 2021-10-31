using System.Collections.Generic;
using ShopManagement.Application.Contracts.Product;

namespace InventorManagment.Contract.Application.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }

        public List<ProductViewModel> products { get; set; }
    }

}
