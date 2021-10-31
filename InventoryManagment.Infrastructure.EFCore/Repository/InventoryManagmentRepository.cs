using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infastructure;
using InventorManagment.Contract.Application.Inventory;
using InventoryManagment.Domain.InventoryAggregation;
using ShopManagment.Infrastructure.EfCore;

namespace InventoryManagment.Infrastructure.EFCore.Repository
{

    public class InventoryManagmentRepository : RepositoryBase<long, Inventory>, IInventoryManagmentRepository
    {

        private readonly ShopContext _shopContext;
        private readonly InventoryContext _context;

        public InventoryManagmentRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }
        public Inventory GetBy(long id)
        {
            return _context.Inventories.Find(id);
        }

        public EditInventory GetDetails(long id)
        {
            return _context.Inventories.Select(x => new EditInventory {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOprationViewModel> GetInventoryOprations(long id)
        {
            var _inventory = _context.Inventories.FirstOrDefault(x => x.Id == id);
           return _inventory.InventoryOperations.Select( x => new InventoryOprationViewModel { 
            Count = x.Count,
            CurrentCount = x.CurrentCount,
            Description = x.Description,
            Id = x.Id,
            OperationDate = x.OperationDate.ToFarsi(),
            OperationType = x.OperationType,
            OperatorId = x.OperatorId,
            OrderId = x.OrderId
            
            }).ToList();
        }

        public List<InventoryManagmentViewModel> Search(InventoryManagmentSearchModel command)
        {
            var _product = _shopContext.products.Select(x => new { x.Id , x.Name}).ToList();
            var query = _context.Inventories.Select(x => new InventoryManagmentViewModel {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CurrentCount = x.CalculateCurrentCount(),
                IsInStock = x.IsInStock
            });
                
            
                
            if (command.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == command.ProductId);
            }
            if (command.IsInStock)
            {
                query = query.Where(x => x.IsInStock == true);
            } else
            {
                query = query.Where(x => x.IsInStock == false);
            }
                

            var searchquery =  query.OrderByDescending( x=>x.Id).ToList();
            searchquery.ForEach(x => {
                x.ProductName = _product.FirstOrDefault(c => c.Id == x.ProductId)?.Name;
                x.IsInStock = x.CurrentCount > 0 ? true : false;
            });// 
            return searchquery;

        }
    }
}
