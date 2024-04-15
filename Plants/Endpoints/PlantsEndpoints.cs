using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Plants.Contract;
using Plants.Repositories;
using Plants.Services;
using System.Security.Principal;
using WebApplication1.Models;


namespace Plants.Endpoints
{
    public static class PlantsEndpoints
    {
        public static IEndpointRouteBuilder MapPlantsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/AddPlant/Plant", AddPlant);
            endpoints.MapGet("/api/GetAllPlants/Plant", GetAllPlants);
            endpoints.MapDelete("/api/GetAllPlants/Plant", DeletePlant);

            return endpoints;
        }
        private static async Task<IResult> AddPlant(HttpContext context, PlantRequestWrapper request, PlantsService plantsServices)
        {
            
            await plantsServices.Add(new Guid(), request.Plant_name, request.Plant_description, request.Plant_type, request.ImagePath);

            return Results.Ok();
        }
        private static async Task<IEnumerable<Plant>> GetAllPlants(HttpContext context, PlantsService plantsServices)
        {
           return await plantsServices.GetAllAccounts(context);
        }
        private static async Task<IResult> DeletePlant(PlantsService plantsServices, HttpContext context, Guid Id)
        {

            await plantsServices.DeleteAccount(Id, context);
            return Results.Ok();
        }
    }
}
