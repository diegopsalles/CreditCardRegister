namespace CreditCardRegister.API.Model
{
    public class RegisterBatchCreditCardRequest
    {
        public string BatchName { get; set; }
        public DateOnly BatchDate { get; set; }
        public string BatchId { get; set; }
        public int BatchAmount { get; set; }
        public List<CreditCard> CreditCards { get; set; }

    }
}
