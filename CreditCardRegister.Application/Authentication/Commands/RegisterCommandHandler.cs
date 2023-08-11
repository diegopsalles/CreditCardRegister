using CreditCardRegister.Application.Authentication.Common;
using CreditCardRegister.Application.Common.Interfaces.Authentication;
using CreditCardRegister.Application.Common.Interfaces.Persistance;
using CreditCardRegister.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CreditCardRegister.Application.Authentication.Commands
{
    internal class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
         public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            //validate the user does not exists
            if (await _userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Domain.Common.Errors.Errors.User.DuplicateEmail;
            }


            //create user(geberate unique ID) and persist to database
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            //create jwt Token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    
    
    }
}
