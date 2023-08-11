using CreditCardRegister.Application.Authentication.Common;
using CreditCardRegister.Application.Common.Interfaces.Authentication;
using CreditCardRegister.Application.Common.Interfaces.Persistance;
using CreditCardRegister.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardRegister.Application.Authentication.Queries
{
    internal class LoginQueryHandler :
            IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJWTTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // Validate the user exists
            if (await _userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
            }

            // validate the password
            if (user.Password != request.Password)
            {
                return new[] { Domain.Common.Errors.Errors.Authentication.InvalidCredentials };
            }

            //create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
