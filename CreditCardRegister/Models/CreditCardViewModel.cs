using CreditCardRegister.API.Entity;

namespace CreditCardRegister.API.Models
{
    public class CreditCardViewModel
    {
        public string Id { get; set; }
        public string CreditCardNumber { get; set; }

    }

    public class RegisterBatchCreditCardViewModel
    {
        public string BatchId { get; set; }
        public string BatchName { get; set; }
        public DateTime BatchDate { get; set; }
        public int BatchAmount { get; set; }
        public  List<CreditCardViewModel> CreditCards { get; set; }
    }
}
