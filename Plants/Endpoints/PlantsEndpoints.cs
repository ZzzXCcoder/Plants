using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Plants.Contract;
using Plants.Repositories;
using Plants.Services;
using System.Security.Principal;


namespace Plants.Endpoints
{
    public static class PlantsEndpoints
    {
        public static IEndpointRouteBuilder MapPlantsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/AddPlant/Plant", AddPlant);

            return endpoints;
        }
        private static async Task<IResult> AddPlant(HttpContext context, PlantRequestWrapper request, PlantsService plantsServices)
        {
            
            await plantsServices.Add(new Guid(), request.Plant_name, request.Plant_description, request.Plant_type, request.ImagePath);

            return Results.Ok();
        }
    }
}
