using CreditCardRegister.API.Entity;

namespace CreditCardRegister.API.Models
{
    public class RegisterBatchCreditCardInputModel
    {
        public string BatchName { get; set; }
        public DateOnly BatchDate { get; set; }
        public int BatchAmount { get; set; }
        public List<CreditCardInputModel> CreditCards { get; set; }
    }

    public class RegisterCreditCardInputModel
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }
        public CreditCardInputModel CreditCardNumber { get; set; }
    }

    public class CreditCardInputModel
    {
        public string CreditCardNumber { get; set; }
    }
}
