using Plants.Interfaces.auth;
using Plants.Repositories;

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
    }
}