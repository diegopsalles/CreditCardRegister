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
        
    }
}
