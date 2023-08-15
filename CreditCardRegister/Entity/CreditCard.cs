using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class CreditCard
    {
        public void Update(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
        }

        public Guid Id { get; set; }= Guid.NewGuid();

        public string CreditCardNumber { get; set; }
        public bool? IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
