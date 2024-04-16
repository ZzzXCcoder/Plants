namespace Plants.Interfaces.auth
{
    public interface IUser_and_PlantsRepository
    {
        public Task<IResult> Add(Guid plantId, Guid userId, HttpContext context);
        public Task<DateTime> SetWateringTime(Guid plantId, Guid userId, HttpContext context, DateTime dateTime);

        public Task<double> CalculateTimeToNextWatering(Guid plantId, Guid userId, HttpContext context);
        public  Task<double> AddToProgress(Guid plantId, Guid userId, HttpContext context);
        public Task<IResult> SetWateringInterval(Guid plant, Guid id, HttpContext context, double wateringIntervalInHours);
    }
}
