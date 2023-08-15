using AutoMapper;
using CreditCardRegister.API.Entity;
using CreditCardRegister.API.Models;

namespace CreditCardRegister.API.Mapper
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCard, CreditCardViewModel>();
            CreateMap<RegisterCreditCard, RegisterBatchCreditCardViewModel>();
            
            CreateMap<CreditCardInputModel, CreditCard>();
            CreateMap<RegisterCreditCardInputModel, RegisterCreditCard>();
        }
    }
}
