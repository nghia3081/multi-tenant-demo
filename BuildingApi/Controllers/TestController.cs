using BuildingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SuperOwnerModels;

namespace BuildingApi.Controllers
{
    [ApiController]
    [Route("api/{projectPermalink}/{buildingPermalink}")]
    public class TestController : BaseController
    {
        readonly SuperOwnerContext superOwnerContext;
        public TestController(SuperOwnerContext superOwnerContext)
        {
        }
        [HttpGet]
        public IActionResult Test()
        {
            var a = this.HttpContext.RequestServices.GetService<BuildingContext>();
            return Ok(a.Statuses.FirstOrDefault());
        }
    }
}
