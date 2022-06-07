    /// <summary>
    /// This class contains all the services exposed for the query of the provider and its products
    /// </summary>
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/inventory/supplier")]
public class SupplierController : ControllerBase
{
    IProductService productService;
    ISupplierService supplierService;
    private readonly ILogger<SupplierController> _logger;

    public SupplierController(IProductService p_service, ISupplierService s_service, ILogger<SupplierController> logger)
    {
        productService = p_service;
        supplierService = s_service;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(supplierService.Get());
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpGet]
    [Route("{index}/product")]
    public IActionResult GetProducts(string index)
    {
        try
        {
            return Ok(productService.Get(index));
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }

    }

    [HttpPut("{index}")]
    public IActionResult Put(Guid index, [FromBody] Supplier supplier)
    {
        try
        {
            supplierService.Update(index, supplier);
            return Accepted();
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }

    [HttpPut]
    [Route("{index}/product/{id}")]
    public IActionResult PutProducts(Guid index, string id, [FromBody] Product product)
    {
        try
        {
            productService.Update(id, supplierService.GetId(index).id, product);
            return Accepted();
        }
        catch (Exception e)
        {
            MessageException ex = new MessageException("Server error", "Contact with the administrator", "0");
            return StatusCode(500, ex);
        }
    }
}