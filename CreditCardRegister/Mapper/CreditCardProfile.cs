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
            CreateMap<RegisterBatchCreditCard, RegisterBatchCreditCardViewModel>();
            CreateMap<RegisterCreditCard, RegisterCreditCardViewModel>();
            
            CreateMap<CreditCardInputModel, CreditCard>();
            CreateMap<RegisterBatchCreditCardInputModel, RegisterBatchCreditCard>();
            CreateMap<RegisterCreditCardInputModel, RegisterCreditCard>();
        }
    }
}
