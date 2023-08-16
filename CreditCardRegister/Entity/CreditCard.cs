using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class CreditCard
    {
        public CreditCard()
        {
        }

        public void Update(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string IdArchiveLine { get; set; }
        public RegisterCreditCard BatchId { get; set; }
        public string CreditCardNumber { get; set; }
        public bool? IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
