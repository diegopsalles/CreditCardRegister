using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class RegisterBatchCreditCard
    {
        public RegisterBatchCreditCard()
        {
           CreditCards = new List<CreditCard>();
        }

        public Guid BatchId { get; set; }
        public string BatchName { get; set; }
        public DateOnly BatchDate { get; set; }
        public int BatchAmount { get; set; }
        public List<CreditCard> CreditCards { get; set; }

    }
}
