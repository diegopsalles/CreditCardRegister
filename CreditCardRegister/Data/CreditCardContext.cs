using CreditCardRegister.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace CreditCardRegister.API.Data
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options) : base(options)
        {
        }


        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<RegisterCreditCard> BatchCreditCard { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCard");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.CreditCardNumber).HasColumnName("CreditCardNumber");
            });
            modelBuilder.Entity<RegisterCreditCard>(entity =>
            {

                entity.ToTable("RegisterBatchCreditCard");
                entity.HasKey(x => x.BatchId);
                entity.Property(x => x.BatchName);
                entity.Property(x => x.BatchDate);
                entity.Property(x => x.BatchAmount);
                entity.HasMany(x => x.CreditCards).WithOne().HasForeignKey(x => x.Id);

            });
        }
        
    }
}
