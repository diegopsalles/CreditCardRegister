using AutoMapper;
using CreditCardRegister.API.Auth;
using CreditCardRegister.API.Data;
using CreditCardRegister.API.Entity;
using CreditCardRegister.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardRegister.API.Controllers
{
    [Route("creditCard")]
    [ApiController]
    public class CreditCardRegisterController : ControllerBase
    {
        private readonly CreditCardContext _context;
        private readonly IMapper _mapper;

        public CreditCardRegisterController(CreditCardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("registerCreditCard")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> RegisterCreditCard([FromBody] RegisterCreditCardInputModel request)
        {
            
            var devEvent = _mapper.Map<RegisterCreditCard>(request);

            _context.RegisterCreditCards.Add(devEvent);
            _context.SaveChanges();
            return Ok(request);
        }



        [HttpPost("registerBatchCreditCard")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> RegisterBatchCreditCard([FromForm] ICollection<IFormFile> batchRegister)
        {

            if (batchRegister == null || batchRegister.Count == 0)
                    return BadRequest();

            List<byte[]> data = new();

            foreach (var txtFile in batchRegister)
            {
                if(txtFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await txtFile.CopyToAsync(stream);
                        data.Add(stream.ToArray());

                    }
                    
                }
                _mapper.Map<RegisterBatchCreditCard>(txtFile);
            }
            return  Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateCreditCard(Guid id, CreditCardInputModel request)
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteCreditCard(Guid id)
        {

            return Ok();
        }

        [HttpGet("getAllCreditCard")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("getByIdCreditCard")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> GetById([FromQuery] long creditCardNumber)
        {
            return Ok();
        }
    }
}
