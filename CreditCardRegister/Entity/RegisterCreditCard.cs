using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCardRegister.API.Entity
{
    public class RegisterCreditCard
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }

        public virtual CreditCard CreditCardNumber { get; set; }
    }
}
