using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class RegisterCreditCard
    {
        public void Update(string batchName, string batchDate, string batchAmount, List<CreditCard> creditCards)
        {
            BatchName = batchName;
            BatchDate = batchDate;
            BatchAmount = batchAmount;
        }
        [Key]
        public Guid BatchId { get; set; }
        public string IdArchive { get; set; }
        public string BatchName { get; set; }
        public string BatchDate { get; set; }
        public string BatchAmount { get; set; }
        public  List<CreditCard> CreditCardsIds { get; set; }
        public RegisterCreditCard()
        {
            BatchId = Guid.NewGuid();
            IdArchive = string.Empty;
            BatchName = string.Empty;
            BatchDate = string.Empty;
            BatchAmount = string.Empty;
            CreditCardsIds = new List<CreditCard>();
        }

    }
}
