    /// <summary>
    /// This class contains the methods of the Catgorie object for use with the database.
    /// </summary>
using webapi.Models;
namespace webapi.Services;

public class CategorieService : ICategorieService
{
    InventoryContext context;

    public CategorieService(InventoryContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Categorie> Get()
    {
        return context.Categorie;
    }

    public Categorie Get(Guid id)
    {
        return context.Categorie.Find(id);
    }

    public async Task Save(Categorie categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categorie categoria)
    {
        var currentCategorie = context.Categorie.Find(id);

        if (currentCategorie != null)
        {
            currentCategorie.name = categoria.name;
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategorieService
{
    IEnumerable<Categorie> Get();
    Task Save(Categorie categoria);

    Task Update(Guid id, Categorie categoria);
    Categorie Get(Guid id);

}