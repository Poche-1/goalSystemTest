    /// <summary>
    /// This class contains the methods of the Inventory object for use with the database.
    /// </summary>
using webapi.Models;
namespace webapi.Services;

public class InventoryService : IInventoryService
{
    InventoryContext context;

    public InventoryService(InventoryContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Inventory> Get()
    {
        return context.Inventory;
    }
    public Inventory Get(String index)
    {
        return context.Inventory.First(c => c.id == index);
    }

    public async Task Save(Inventory inventory)
    {
        context.Add(inventory);
        await context.SaveChangesAsync();
    }

    public async Task Update(string id, Inventory inventory, InventoryContext dbcontext)
    {
        var currentInventory = context.Inventory.First(c => c.id == id);

        if (currentInventory != null)
        {
            currentInventory.costo = inventory.costo;
            currentInventory.stock = inventory.stock;
            dbcontext.SaveChanges();
        }
    }
}

public interface IInventoryService
{
    IEnumerable<Inventory> Get();
    Inventory Get(String index);
    Task Save(Inventory categoria);
    Task Update(string id, Inventory categoria, InventoryContext dbcontext);

}