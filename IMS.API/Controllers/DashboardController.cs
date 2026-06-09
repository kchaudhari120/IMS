using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//namespace IMS.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DashboardController : ControllerBase
//    {
//    }
//}


namespace IMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetDashboard()
    {
        return Ok(new
        {
            Message = "JWT Authentication Working Successfully"
        });
    }
}