using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domin;

namespace InventoryManagment.Domain.InventoryAggregation
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public List<InventoryOperation> InventoryOperations { get; private set; }
        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            IsInStock = false;
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var IncreaseInventorySum = InventoryOperations.Where(x => x.OperationType == true).Sum(x => x.Count);
            var DecreaseInventorySum = InventoryOperations.Where(x => x.OperationType == false).Sum(x => x.Count);
            return IncreaseInventorySum - DecreaseInventorySum; 
        }

        public void Increase(long count, long operatorId, string description)
        {
            var _currentCount = CalculateCurrentCount() + count;
            var _opration = new InventoryOperation(true, count, operatorId,_currentCount, description, 0, Id);
            InventoryOperations.Add(_opration);
        }

        public void Decrease(long count, long operatorId, string description, long orderId)
        {
            var _currentCount = CalculateCurrentCount() - count;
            var _opration = new InventoryOperation(false, count, operatorId, _currentCount, description, 0, Id);
            InventoryOperations.Add(_opration);
        }

    }

}
