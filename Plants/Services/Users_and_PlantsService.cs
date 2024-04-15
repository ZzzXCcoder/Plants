using Plants.Interfaces.auth;
using Plants.Repositories;

namespace Plants.Services
{
    public class Users_and_PlantsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPlantsRepository _plantsRepository;
        private readonly IUser_and_PlantsRepository _user_and_plantsRepository;

        public Users_and_PlantsService(IUserRepository userRepository, IPlantsRepository plantRepository, IUser_and_PlantsRepository user_And_PlantsRepository )
        {
            _userRepository = userRepository;
            _plantsRepository = plantRepository;
            _user_and_plantsRepository = user_And_PlantsRepository;
        }
        internal async Task Add(Guid plantId, Guid userId, HttpContext context)
        {
            _user_and_plantsRepository.Add( plantId, userId, context );
        }

        internal Task<TimeSpan> SetWateringTime(Guid plantId, Guid userId, HttpContext context, DateTime dateTime)
        {
            return _user_and_plantsRepository.SetWateringTime(plantId, userId, context, dateTime);
        }
    }
}
