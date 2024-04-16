using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plants.Interfaces.auth;
using Plants.Models;
using System;
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
                AccountId = userId,
                
            };
            _context.Accounts_and_plants.Add(accountAndPlant);
            await _context.SaveChangesAsync();
            return Results.Ok();
        }
        public async Task<DateTime> SetWateringTime(Guid plantId, Guid userId, HttpContext context, DateTime dateTime)
        {
            var accountAndPlantEntity = await _context.Accounts_and_plants
                .FirstOrDefaultAsync(a => a.PlantId == plantId && a.AccountId == userId);
            if (accountAndPlantEntity == null)
            {
                throw new KeyNotFoundException("Связь между пользователем и растением не найдена.");
            }
            accountAndPlantEntity.watering_time = dateTime;

            await _context.SaveChangesAsync();

            return accountAndPlantEntity.watering_time;
        }
        public async Task<double> CalculateTimeToNextWatering(Guid plantId, Guid userId, HttpContext context)
        {
            var accountAndPlantEntity = await _context.Accounts_and_plants
               .FirstOrDefaultAsync(a => a.PlantId == plantId && a.AccountId == userId);
            if (accountAndPlantEntity == null)
            {
                throw new KeyNotFoundException("Связь между пользователем и растением не найдена.");
            }

            DateTime nextWateringTime = DateTime.Now.Add(TimeSpan.FromHours(accountAndPlantEntity.wateringIntervalInHours));
            double timeToNextWatering = ((nextWateringTime - DateTime.UtcNow).TotalSeconds)-10800;
            nextWateringTime = nextWateringTime.ToUniversalTime();
            accountAndPlantEntity.watering_time = nextWateringTime;
            await _context.SaveChangesAsync();

            return timeToNextWatering;
        }
        public async Task<double> AddToProgress(Guid plantId, Guid userId, HttpContext context)
        {
            var accountAndPlantEntity = await _context.Accounts_and_plants
              .FirstOrDefaultAsync(a => a.PlantId == plantId && a.AccountId == userId);
            if (accountAndPlantEntity == null)
            {
                throw new KeyNotFoundException("Связь между пользователем и растением не найдена.");
            }
            accountAndPlantEntity.watering_rate += 1;
            await _context.SaveChangesAsync();
            return accountAndPlantEntity.watering_rate;
        }
        public async Task<IResult> SetWateringInterval(Guid plant, Guid id, HttpContext context, double wateringIntervalInHours)
        {
            var accountAndPlantEntity = await _context.Accounts_and_plants
               .FirstOrDefaultAsync(a => a.PlantId == plant && a.AccountId == id);
            accountAndPlantEntity.wateringIntervalInHours = wateringIntervalInHours;
            await _context.SaveChangesAsync();
            return Results.Ok();
        }
    }
}