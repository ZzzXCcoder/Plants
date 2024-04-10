using Microsoft.EntityFrameworkCore;
using Plants.Configurations;
using Plants.Models;
using WebApplication1.Models;


namespace WebApplication1.Context
{
    public class ApplicationDbContext : DbContext
    {
       
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Account_and_plant> Accounts_and_plants { get; set; }
        public DbSet<Plant> Plants {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Account_and_plant_configuration());
            modelBuilder.ApplyConfiguration(new Account_configurationcs());
            modelBuilder.ApplyConfiguration(new Plant_configurations());
            base.OnModelCreating(modelBuilder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
    }
}
