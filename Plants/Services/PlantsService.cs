using Plants.Interfaces.auth;
using Plants.Repositories;
using WebApplication1.Models;

namespace Plants.Services
{
    internal class PlantsService
    {
        private readonly IPlantsRepository _plantsRepository;
        public PlantsService(IPlantsRepository plantsRepository)
        {
            _plantsRepository = plantsRepository;
        }

        internal async Task Add(Guid guid, string plant_name, string plant_description, string plant_type, string imagePath)
        {
            var plant = new Plant(guid, plant_name, plant_description,plant_type, imagePath);
            await _plantsRepository.Add(plant);
            
        }
        public async Task<IEnumerable<Plant>> GetAllAccounts(HttpContext context)
        {
            var accounts = await _plantsRepository.GetAllPlants(context);

            var formattedAccounts = accounts.Select(a => new Plant(a.Id, a.Plant_name, a.Plant_description, a.Plant_type, a.ImagePath));

            return formattedAccounts;
        }

        internal async Task<IResult> DeleteAccount(Guid id, HttpContext context)
        {
            await _plantsRepository.DeleteAccount(id, context);
            return Results.Ok();
        }
    }
}