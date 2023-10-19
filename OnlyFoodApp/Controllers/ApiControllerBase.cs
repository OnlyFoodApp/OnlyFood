
using Microsoft.AspNetCore.Mvc;

namespace OnlyFoodApp.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
