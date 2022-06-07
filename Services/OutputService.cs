    /// <summary>
    /// This class contains the methods of the Input object for use with the database.
    /// </summary>
using webapi.Models;
namespace webapi.Services;

public class OutputService : IOutputService
{
    InventoryContext context;

    public OutputService(InventoryContext dbcontext)
    {
        context = dbcontext;
    }
    
    public IEnumerable<Output> Get()
    {
        return context.Output;
    }

    public InventoryContext GetContext()
    {
        return context;
    }

    public async Task Save(Output output)
    { 
        context.Output.Add(output);
    }

}

public interface IOutputService
{
    IEnumerable<Output> Get();
    InventoryContext GetContext();
    Task Save(Output output);

}