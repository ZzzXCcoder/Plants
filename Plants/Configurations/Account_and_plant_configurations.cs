
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plants.Models;
using WebApplication1.Models;

namespace Plants.Configurations
{
    public class Account_and_plant_configuration : IEntityTypeConfiguration<Account_and_plant>
    {
        public void Configure(EntityTypeBuilder<Account_and_plant> builder)
        {
            builder
                .HasOne(ap => ap.Account)
                .WithMany()
                .HasForeignKey(ap => ap.AccountId);
            builder
                .HasOne(ap => ap.Plant)
                .WithMany()
                .HasForeignKey(ap => ap.PlantId);
        }
    }
}
