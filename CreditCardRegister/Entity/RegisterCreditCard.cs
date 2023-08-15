using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Entity
{
    public class RegisterCreditCard
    {
        public void Update(string batchName, DateTime batchDate, int batchAmount, List<CreditCard> creditCards)
        {
            BatchName = batchName;
            BatchDate = batchDate;
            BatchAmount = batchAmount;
        }

        public Guid BatchId { get; set; }= Guid.NewGuid();
        public string BatchName { get; set; }
        public DateTime BatchDate { get; set; }
        public int BatchAmount { get; set; }
        public  List<CreditCard> CreditCards { get; set; }

    }
}
