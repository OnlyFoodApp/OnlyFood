using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlyFoodApp.Controllers
{
    [Route("/api/v1/[controller]")]
    //[Authorize(Roles = "Admin")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
