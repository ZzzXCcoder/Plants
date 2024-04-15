namespace Plants.Interfaces.auth
{
    public interface IUser_and_PlantsRepository
    {
        public Task<IResult> Add(Guid plantId, Guid userId, HttpContext context);
        public Task<TimeSpan> SetWateringTime(Guid plantId, Guid userId, HttpContext context, DateTime dateTime);
    }
}
