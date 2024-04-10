using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plants.Models;
using WebApplication1.Models;

namespace Plants.Configurations
{
    public class Account_configurationcs : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder
                .HasMany(a => a.accounts_in_table)
                .WithOne(b => b.Account);
        }
    }
}