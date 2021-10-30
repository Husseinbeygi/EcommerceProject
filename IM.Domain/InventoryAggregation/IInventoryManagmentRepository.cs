using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framework.Domin;
using InventorManagment.Contract.Application.Inventory;

namespace InventoryManagment.Domain.InventoryAggregation
{
    public interface IInventoryManagmentRepository : IRepository<long,Inventory>
    {
              
        EditInventory GetDetails(long id);
        Inventory GetBy(long id);
        List<InventoryManagmentViewModel> Search(InventoryManagmentSearchModel command);
    }
}
