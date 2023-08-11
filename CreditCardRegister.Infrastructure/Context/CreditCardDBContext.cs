using CreditCardRegister.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardRegister.Infrastructure.Context
{
    public class CreditCardDBContext : DbContext
    {
        protected CreditCardDBContext()
        {
        }

        public CreditCardDBContext(DbContextOptions<CreditCardDBContext> options)
        : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("name=CreditCardRegister");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.InstanceId });

                entity.ToTable("CreditCard");
            });

        }
    }
}
