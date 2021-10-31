using System.Collections.Generic;
using InventorManagment.Contract.Application.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        public InventoryManagmentSearchModel SearchModel;
        public List<InventoryManagmentViewModel> inventoryManagmentViewModel;
        private readonly IInventoryManagmentApplication _inventoryManagmentApplication;
        private readonly IProductApplication _productApplication;
        public SelectList _SearchwithProductList;
        public string _ProductName;
        public IndexModel(IInventoryManagmentApplication inventoryManagmentApplication, IProductApplication productApplication)
        {

            _inventoryManagmentApplication = inventoryManagmentApplication;
            _productApplication = productApplication;
        }


        public void OnGet(InventoryManagmentSearchModel searchModel)
        {

            _SearchwithProductList = new SelectList(_productApplication.GetProducts(), "Id", "Name");

            inventoryManagmentViewModel = _inventoryManagmentApplication.Search(searchModel);

        }

        public IActionResult OnGetCreate()
        {
            var cmd = new CreateInventory();
            cmd.products = _productApplication.GetProducts();
            return Partial("./Create", cmd);
        }
        public JsonResult OnPostCreate(CreateInventory inventory)
        {
            var result = _inventoryManagmentApplication.Create(inventory);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var _editProduct = _inventoryManagmentApplication.GetDetails(id);
            _editProduct.products = _productApplication.GetProducts();
            return Partial("./Edit", _editProduct);
        }
        public JsonResult OnPostEdit(EditInventory inventory)
        {
            var result = _inventoryManagmentApplication.Edit(inventory);
            return new JsonResult(result);
        }

        // Increase
        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory () {
                InventoryId = id
            };
            return Partial("./Increase", command);
        }
        public JsonResult OnPostIncrease(IncreaseInventory inventory)
        {
            var result = _inventoryManagmentApplication.Increase(inventory);
            return new JsonResult(result);
        }

        // Decrease

        public IActionResult OnGetDecrease(long id)
        {
            var command = new DecreaseInventory() {
                InvenoryId = id,
                
            };
            return Partial("./Decrease", command);
        }
        public JsonResult OnPostDecrease(DecreaseInventory inventory)
        {
            var result = _inventoryManagmentApplication.Decrease(inventory);
            return new JsonResult(result);
        }


        public IActionResult OnGetInventoryOprations(long id)
        {
            var command = _inventoryManagmentApplication.InventoryOprations(id);
            return Partial("./InventoryOprations", command);
        }
    }
}
