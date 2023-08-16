using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class CreditCard
    {
        public Guid CreditCardId { get; set; }= Guid.NewGuid();

        public string? IdArchiveLine { get; set; }
        public string CreditCardNumber{ get; set; }

        public bool? IsDeleted { get; set; }

        public RegisterCreditCard? RegisterCreditCard { get; set; }

        public Guid? RegisterCreditCardId { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Update(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
        }
    }
}
