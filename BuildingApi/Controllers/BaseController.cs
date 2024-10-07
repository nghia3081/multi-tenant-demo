using BuildingModels;
using Microsoft.AspNetCore.Mvc;
using SuperOwnerModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BuildingApi.Configure;


namespace BuildingApi.Controllers
{
    [ApiController]
    [CustomFilter]
    public class BaseController : ControllerBase
    {
        protected string projectPermalink => this.RouteData.Values["projectPermalink"]?.ToString();
        protected string buildingPermalink => this.RouteData.Values["buildingPermalink"]?.ToString();

    }
}
