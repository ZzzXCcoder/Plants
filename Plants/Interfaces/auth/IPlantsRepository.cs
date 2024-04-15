using Plants.Models;

namespace Plants.Interfaces.auth
{
    public interface IPlantsRepository
    {
        public Task Add(Plant plant);
    }
}
