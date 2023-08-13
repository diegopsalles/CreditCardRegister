using CreditCardRegister.Application.Authentication.Common;
using CreditCardRegister.Application.CreditCard.Commands;
using CreditCardRegister.Application.CreditCard.Common;
using CreditCardRegister.Application.CreditCard.Queries;
using CreditCardRegister.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardRegister.API.Controllers
{
    [Route("creditCard")]   
    public class CreditCardRegisterController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreditCardRegisterController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var command = _mapper.Map<CreditCardRegisterCommand>(request);
            ErrorOr<CredidCarRegisterResult> creditCardResult = await _mediator.Send(command);

            return creditCardResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpPost("batchRegister")]
        public async Task<IActionResult> BatchRegister(RegisterRequest request)
        {

            var command = _mapper.Map<CreditCardRegisterBatchCommand>(request);
            ErrorOr<CredidCarRegisterResult> creditCardResult = await _mediator.Send(command);

            return creditCardResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpGet("getAllCreditCard")]
        public async Task<IActionResult> GetAll(RegisterRequest request)
        {

            var command = _mapper.Map<GetAllCreditCard>(request);
            ErrorOr<CredidCarRegisterResult> creditCardResult = await _mediator.Send(command);

            return creditCardResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpGet("getByIdCreditCard")]
        public async Task<IActionResult> GetById(RegisterRequest request)
        {

            var command = _mapper.Map<GetCreditCardById>(request);
            ErrorOr<CredidCarRegisterResult> creditCardResult = await _mediator.Send(command);

            return creditCardResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }
    }
}
