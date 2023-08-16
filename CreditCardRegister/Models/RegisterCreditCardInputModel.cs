using CreditCardRegister.API.Entity;
using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Models
{
    public class RegisterCreditCardInputModel
    {
        [Required(ErrorMessage = "BatchName é obrigatório!")]
        public string BatchName { get; set; }
        public DateTime BatchDate { get; set; }
        [Required(ErrorMessage = "BatchAmount é obrigatório!")]
        public int BatchAmount { get; set; }
        [Required(ErrorMessage = "CreditCards é obrigatório!")]
        public List<CreditCardInputModel> CreditCards { get; set; }
    }

    public class CreditCardInputModel
    {
        public Guid CreditCardId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "CreditCardNumber é obrigatório!")]
        public string CreditCardNumber { get; set; }
    }
}
