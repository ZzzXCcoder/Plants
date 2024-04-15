using Plants.Models;

namespace Plants.Interfaces.auth
{
    public interface IPlantsRepository
    {
        public Task Add(Plant plant);
        public Task<IEnumerable<Plant>> GetAllPlants(HttpContext context);

        public  Task<IResult> DeleteAccount(Guid id, HttpContext context);
    }

}
