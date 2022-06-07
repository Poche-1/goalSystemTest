    /// <summary>
    /// Business logic, this class will have all the methods that have some business logic for the inventory
    /// </summary>

using webapi.Models;
namespace webapi.Services;
public class InventoryUtils : IInventoryUtils
{

    public Inventory UpdateInventory(Inventory input, IEnumerable<Input> inputs, IEnumerable<Output> outputs)
    {

        Int32 nInputs = 0;
        Int32 nOutputs = 0;
        foreach (Input ii in inputs.Where(c => c.idInventory == input.id))
        {
            nInputs = nInputs + ii.Und;
        }
        foreach (Output o in outputs.Where(c => c.idInventory == input.id))
        {
            nOutputs = nOutputs + o.Und;
        }
        input.input = nInputs;
        input.output = nOutputs;
        return input;
    }
}

public interface IInventoryUtils
{
    Inventory UpdateInventory(Inventory i, IEnumerable<Input> ip, IEnumerable<Output> ou);

}