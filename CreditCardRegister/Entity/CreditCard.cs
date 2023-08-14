using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class CreditCard
    {
        public Guid Id { get; set; }

        public string CreditCardNumber { get; set; }
    }
}
