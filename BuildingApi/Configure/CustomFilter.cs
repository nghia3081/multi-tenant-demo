using BuildingModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SuperOwnerModels;

namespace BuildingApi.Configure
{
    public class CustomFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string projectPermalink = context.RouteData.Values["projectPermalink"]?.ToString();
            string buildingPermalink = context.RouteData.Values["buildingPermalink"]?.ToString();

            SuperOwnerContext superOwnerContext = context.HttpContext.RequestServices.GetRequiredService<SuperOwnerContext>();

            var project = superOwnerContext.Projects.FirstOrDefault(x => x.Permalink == projectPermalink);
            var building = superOwnerContext.Buildings.FirstOrDefault(x => x.ProjectId == project.Id && x.Permalink == buildingPermalink);
            BuildingContext buildingContext = context.HttpContext.RequestServices.GetRequiredService<BuildingContext>();

            buildingContext.Database.SetConnectionString(building.ConnectionString);
            base.OnActionExecuting(context);
        }
    }
}
