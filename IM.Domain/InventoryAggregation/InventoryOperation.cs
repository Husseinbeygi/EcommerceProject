using System;

namespace InventoryManagment.Domain.InventoryAggregation
{
    public class InventoryOperation
    {
        public InventoryOperation(bool operationtype, long count, long operatorId, long currentCount, string description, long orderId, long inventoryId)
        {
            OperationType = operationtype;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
        }

        public long Id { get; private set; }
        public bool OperationType { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        public long OrderId { get; private set; }

        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

    }

}
