using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class RegisterCreditCard
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }
        public CreditCard CreditCardNumber { get; set; }
    }
}
