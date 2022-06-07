    /// <summary>
    /// This class contains all the services exposed to the user to validate the connection with the server.
    /// </summary>
using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

[ApiController]
[Route("api/goalSystem")]
public class MainController : ControllerBase
{
    IMainService mainService;

    public MainController(IMainService m_Service)
    {
        mainService = m_Service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(mainService.Get());
    }

}