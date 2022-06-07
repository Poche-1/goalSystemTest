    /// <summary>
    /// This class contains the methods of the Product object for use with the database.
    /// </summary>
using webapi.Models;
namespace webapi.Services;

public class ProductService : IProductService
{
    InventoryContext context;


    public ProductService(InventoryContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Product> Get(string supplier)
    {
        return context.Product.Where(c => c.idSupplier == supplier).ToArray();
    }

    public IEnumerable<Product> Get()
    {
        return context.Product;
    }

    public async Task Save(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task Update(string id, Guid index, Product product)
    {
        var currentProduct = context.Product.Find(id);

        if (currentProduct != null && currentProduct.idSupplier == index.ToString())
        {

            currentProduct.name = product.name;
            currentProduct.detail = product.detail;
            currentProduct.state = product.state;
            await context.SaveChangesAsync();
        }
    }

}

public interface IProductService
{
    IEnumerable<Product> Get();
    IEnumerable<Product> Get(string supplier);
    Task Save(Product product);
    Task Update(string id, Guid index, Product product);

}