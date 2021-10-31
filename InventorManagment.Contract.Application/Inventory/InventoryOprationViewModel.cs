using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorManagment.Contract.Application.Inventory
{
    public class InventoryOprationViewModel
    {

        public long Id { get;  set; }
        public bool OperationType { get;  set; }
        public long Count { get;  set; }
        public long OperatorId { get;  set; }
        public string OperationDate { get;  set; }
        public long CurrentCount { get;  set; }
        public string Description { get;  set; }
        public long OrderId { get;  set; }

    }
}
