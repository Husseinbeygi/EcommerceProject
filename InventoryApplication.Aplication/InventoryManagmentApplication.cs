using System;
using System.Collections.Generic;
using _0_Framework.Application;
using InventorManagment.Contract.Application.Inventory;
using InventoryManagment.Domain.InventoryAggregation;

namespace InventoryApplication.Aplication
{
    public class InventoryManagmentApplication : IInventoryManagmentApplication
    {
        private readonly IInventoryManagmentRepository _inventoryManagmentRepository;

        public InventoryManagmentApplication(IInventoryManagmentRepository inventoryManagmentRepository)
        {
            _inventoryManagmentRepository = inventoryManagmentRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            throw new NotImplementedException();

        }

        public OperationResult Decrease(DecreaseInventory command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Decrease(List<DecreaseInventory> command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditInventory command)
        {
            throw new NotImplementedException();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryManagmentRepository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            throw new NotImplementedException();
        }

        public List<InventoryManagmentViewModel> Search(InventoryManagmentSearchModel command)
        {
            return _inventoryManagmentRepository.Search(command);
        }
    }
}
