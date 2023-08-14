﻿using CreditCardRegister.API.Entity;

namespace CreditCardRegister.API.Models
{
    public class CreditCardViewModel
    {
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
    }

    public class RegisterBatchCreditCardViewModel
    {
        public Guid BatchId { get; set; }
        public string BatchName { get; set; }
        public DateOnly BatchDate { get; set; }
        public int BatchAmount { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }

    public class RegisterCreditCardViewModel
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Email { get; set; }
        public CreditCard CreditCardNumber { get; set; }
    }
}