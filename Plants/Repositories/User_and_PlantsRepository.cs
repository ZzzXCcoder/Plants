using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plants.Interfaces.auth;
using Plants.Models;
using WebApplication1.Context;

namespace Plants.Repositories
{
    public class User_and_PlantsRepository : IUser_and_PlantsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public User_and_PlantsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Add(Guid plantId, Guid userId, HttpContext context)
        {
            var accountAndPlant = new Account_and_plant
            {
                PlantId = plantId,
                AccountId= userId,

            };
            _context.Accounts_and_plants.Add(accountAndPlant);
            await _context.SaveChangesAsync();
            return Results.Ok();
        }
        public async Task<TimeSpan> SetWateringTime (Guid plantId, Guid userId, HttpContext context, DateTime dateTime)
        {
            var accountAndPlantEntity = await _context.Accounts_and_plants
                .FirstOrDefaultAsync(a => a.PlantId == plantId && a.AccountId == userId);
            if (accountAndPlantEntity == null)
            {
                throw new KeyNotFoundException("Связь между пользователем и растением не найдена.");
            }
            accountAndPlantEntity.watering_time = dateTime;
            await _context.SaveChangesAsync();

            return accountAndPlantEntity.watering_time.TimeOfDay;
        }
    }
}
