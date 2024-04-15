using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Plants.Interfaces.auth;
using WebApplication1.Context;

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
    }
}
