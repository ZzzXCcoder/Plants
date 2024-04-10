using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plants.Models;
using WebApplication1.Models;

namespace Plants.Configurations
{
    public class Plant_configurations : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder
                .HasMany(a => a.plant_in_table)
                .WithOne(b => b.Plant);
        }
    }
}