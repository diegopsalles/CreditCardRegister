using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class CreditCard
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CreditCardNumber { get; set; }
    }
}
