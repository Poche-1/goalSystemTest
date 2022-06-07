    /// <summary>
    /// This class contains all the services exposed for the inventory query
    /// </summary>
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    ICategorieService categorieService;
    IInputService inputService;
    IOutputService outputService;
    IInventoryService inventoryService;
    IInventoryUtils inventoryUtils;

    public InventoryController(ICategorieService c_service, IInputService in_service, IOutputService ou_service, IInventoryService iv_service, IInventoryUtils iv_utils)
    {
        categorieService = c_service;
        inputService = in_service;
        outputService = ou_service;
        inventoryService = iv_service;
        inventoryUtils = iv_utils;
    }

    [HttpGet]
    [Route("categorie")]
    public IActionResult GetCategories()
    {
        try
        {
            return Ok(categorieService.Get());
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }

    }


    [HttpGet]
    [Route("categorie/{index}")]
    public IActionResult GetCategories(Guid index)
    {
        try
        {
            return Ok(categorieService.Get(index));
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpGet]
    [Route("inputs")]
    public IActionResult GetInputs()
    {
        try
        {
            return Ok(inputService.Get());
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpGet]
    [Route("outputs")]
    public IActionResult GetOutputs()
    {
        try
        {
            return Ok(outputService.Get());
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(inventoryService.Get());
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpPost]
    [Route("inputs")]

    public IActionResult PostInput([FromBody] Input input)
    {
        try
        {
            inputService.Save(input);
            Inventory i = inventoryUtils.UpdateInventory(inventoryService.Get(input.idInventory), inputService.Get(), outputService.Get());
            inventoryService.Update(i.id, i, outputService.GetContext());
            return StatusCode(201);
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpPost]
    [Route("outputs")]
    public IActionResult PostOutput([FromBody] Output output)
    {
        try
        {
            outputService.Save(output);
            Inventory i = inventoryUtils.UpdateInventory(inventoryService.Get(output.idInventory), inputService.Get(), outputService.Get());
            inventoryService.Update(i.id, i, outputService.GetContext());
            return StatusCode(201);
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }

    }
}