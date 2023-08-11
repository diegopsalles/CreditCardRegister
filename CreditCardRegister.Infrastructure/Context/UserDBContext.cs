using CreditCardRegister.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardRegister.Infrastructure.Context
{
    internal class UserDBContext : DbContext
    {
        protected UserDBContext()
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options)
        {
        }


        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("name=CreditCardRegister");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.InstanceId });

                entity.ToTable("CreditCard");
            });

        }
    }
}
