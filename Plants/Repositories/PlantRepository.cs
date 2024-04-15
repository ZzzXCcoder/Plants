using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Plants.Interfaces.auth;
using WebApplication1.Context;
using WebApplication1.Models;

namespace Plants.Repositories
{
    public class PlantRepository : IPlantsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PlantRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Plant plant)
        {
            await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Plant>> GetAllPlants(HttpContext context)
        {
            var accounts = await _context.Plants
                .Include(a => a.plant_in_table)
                .AsNoTracking()
                .ToListAsync();
            return accounts;
        }
        public async Task<IResult> DeleteAccount(Guid id, HttpContext context)
        {
            var plant_Entity = await _context.Plants
               .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception("Account not found");

            _context.Entry(plant_Entity).State = EntityState.Detached;

            _context.Plants.Remove(plant_Entity);  // Use DbSet.Remove method directly
            await _context.SaveChangesAsync();


            return Results.Ok();
        }
    }
}
