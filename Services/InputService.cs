    /// <summary>
    /// This class contains the methods of the Input object for use with the database.
    /// </summary>
using webapi.Models;
namespace webapi.Services;

public class InputService : IInputService
{
    InventoryContext context;

    public InputService(InventoryContext dbcontext)
    {
        context = dbcontext;
    }
    
    public IEnumerable<Input> Get()
    {
        return context.Input;
    }

    public async Task Save(Input input)
    {
        context.Add(input);
    }

}

public interface IInputService
{
    IEnumerable<Input> Get();
    Task Save(Input input);

}