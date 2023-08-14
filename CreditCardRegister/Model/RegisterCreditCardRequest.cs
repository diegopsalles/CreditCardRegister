using System.ComponentModel.DataAnnotations;

namespace CreditCardRegister.API.Model
{
    public class RegisterCreditCardRequest
    {
        [Required(ErrorMessage = "User Name é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data é obrigatório!")]
        public DateTime CreatedDate { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CreditCardNumber é obrigatório!")]
        public CreditCard CreditCardNumber { get; set; }
    }
}
