using CreditCardRegister.Application.Common.Interfaces.Persistance;
using CreditCardRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardRegister.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public Task<User> GetUserByEmail(string email)
        {
            var user = _users.SingleOrDefault(u => u.Email == email);
            return Task.FromResult(user);
        }
    }
}
