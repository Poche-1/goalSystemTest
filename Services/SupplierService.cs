
    /// <summary>
    /// This class contains the methods of the Supplier object for use with the database.
    /// </summary>

using webapi.Models;
namespace webapi.Services;

public class SupplierService : ISupplierService
{
    InventoryContext context;

    public SupplierService(InventoryContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Supplier> Get()
    {
        return context.Supplier;
    }

    public Supplier GetId(Guid id)
    {
        return context.Supplier.Find(id);
    }

    public async Task Save(Supplier supplier)
    {
        context.Add(supplier);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Supplier supplier)
    {
        var currentSupplier = context.Supplier.Find(id);

        if (currentSupplier != null)
        {
             currentSupplier.name = supplier.name; 
             currentSupplier.description = supplier.description; 
             currentSupplier.telephone = supplier.telephone; 
             currentSupplier.state = supplier.state; 

            await context.SaveChangesAsync();
        }
    }

}

public interface ISupplierService
{
    IEnumerable<Supplier> Get();
    Supplier GetId(Guid id);
    Task Save(Supplier supplier);

    Task Update(Guid id, Supplier supplier);

}