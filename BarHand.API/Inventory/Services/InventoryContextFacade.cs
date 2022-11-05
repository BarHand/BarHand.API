using BarHand.API.Inventory.Interfaces.Internal;

namespace BarHand.API.Inventory.Services;

public class InventoryContextFacade: IInventoryContextFacade
{
    private readonly ProductService _productService;

    public InventoryContextFacade(ProductService productService)
    {
        _productService = productService;
    }

    public int TotalProducts()
    {
        return _productService.ListAsync().Result.Count();
    }
}