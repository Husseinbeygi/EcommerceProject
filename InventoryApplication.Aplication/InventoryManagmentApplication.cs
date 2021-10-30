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
            var oprationResult = new OperationResult();
            if (_inventoryManagmentRepository.Exist(x => x.ProductId == command.ProductId))
            {
                return oprationResult.Failed(Messages.FailedOpration_Duplicate);
            }
            var _inventory = new Inventory(command.ProductId, command.UnitPrice);

            _inventoryManagmentRepository.Create(_inventory);
            _inventoryManagmentRepository.SaveChanges();
            return oprationResult.Succeeded();

        }

        public OperationResult Decrease(DecreaseInventory command)
        {
            var oprationResult = new OperationResult();
            var _inventoryforedit = _inventoryManagmentRepository.Get(command.InvenoryId);
            if (_inventoryManagmentRepository == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }
            int opratorId = 1;
            _inventoryforedit.Decrease(command.Count, opratorId, command.Description, 0); // The Order ID is 0 because the decrease process is run by a staff not customer
            _inventoryManagmentRepository.SaveChanges();
            return oprationResult.Succeeded();
        }

        public OperationResult Decrease(List<DecreaseInventory> command)
        {
            var oprationResult = new OperationResult();
            if (command == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }
            int opratorId = 0;
            foreach (var item in command)
            {
                var _inventoryforedit = _inventoryManagmentRepository.Get(item.InvenoryId);

                _inventoryforedit.Decrease(item.Count, opratorId, item.Description, item.OrderId);
            }
            _inventoryManagmentRepository.SaveChanges();
            return oprationResult.Succeeded();
        }
        public OperationResult Increase(IncreaseInventory command)
        {
            var oprationResult = new OperationResult();
            var _inventoryforedit = _inventoryManagmentRepository.Get(command.InventoryId);
            if (_inventoryManagmentRepository == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }
            int opratorId = 1;
            _inventoryforedit.Increase(command.Count, opratorId, command.Descripton);
            _inventoryManagmentRepository.SaveChanges();
            return oprationResult.Succeeded();
        }
        public OperationResult Edit(EditInventory command)
        {
            var oprationResult = new OperationResult();
            var _inventoryforedit = _inventoryManagmentRepository.Get(command.Id);
            if (_inventoryManagmentRepository == null)
            {
                return oprationResult.Failed(Messages.FailedOpration_Null);
            }
            if (_inventoryManagmentRepository.Exist(x => x.ProductId == command.ProductId))
            {
                return oprationResult.Failed(Messages.FailedOpration_Duplicate);
            }
            _inventoryforedit.Edit(command.ProductId, command.UnitPrice);
            _inventoryManagmentRepository.SaveChanges();
            return oprationResult.Succeeded();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryManagmentRepository.GetDetails(id);
        }



        public List<InventoryManagmentViewModel> Search(InventoryManagmentSearchModel command)
        {
            return _inventoryManagmentRepository.Search(command);
        }
    }
}
