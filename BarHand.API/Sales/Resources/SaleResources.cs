using BarHand.API.Suppliers.Resources;
using BarHand.API.Store.Resources;
using BarHand.API.Inventory.Resources;
namespace BarHand.API.Sales.Resources;


public class SaleResource{
    public int Id {get; set;}
    public long IdStore {get; set;}
    public long IdProduct {get; set;}
    public bool Available {get;set;}
    public decimal Stars {get;set;}
    public InventoryResource Product {get;set}
    public StoreResource Store {get;set;}
}