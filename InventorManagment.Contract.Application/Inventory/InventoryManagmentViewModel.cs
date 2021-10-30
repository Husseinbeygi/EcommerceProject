namespace InventorManagment.Contract.Application.Inventory
{
    public class InventoryManagmentViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public long CurrentCount { get; set; }
        
    }

}
