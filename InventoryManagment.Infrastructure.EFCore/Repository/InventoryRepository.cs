using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using InventorManagment.Contract.Application.Inventory;
using InventoryManagment.Domain.InventoryAggregation;

namespace InventoryManagment.Infrastructure.EFCore.Repository
{
    
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {

        private readonly InventoryContext _context;

        public InventoryRepository(InventoryContext context) : base(context)
        {
            _context = context;
        }

        public OperationResult Decrease(List<DecreaseInventory> command)
        {
            throw new NotImplementedException();
        }

        public EditInventory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            throw new NotImplementedException();
        }

        public List<InventoryManagmentViewModel> Search(InventoryManagmentSearchModel command)
        {
            throw new NotImplementedException();
        }
    }
}
