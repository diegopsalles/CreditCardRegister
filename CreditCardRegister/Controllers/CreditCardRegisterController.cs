using AutoMapper;
using CreditCardRegister.API.Auth;
using CreditCardRegister.API.Data;
using CreditCardRegister.API.Entity;
using CreditCardRegister.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterCreditCard([FromBody] RegisterCreditCardInputModel request)
        {
            
            var registerBatchCreditCard = _mapper.Map<RegisterCreditCard>(request);

            _context.BatchCreditCards.Add(registerBatchCreditCard);
            _context.SaveChanges();
            return Ok(registerBatchCreditCard.BatchId);
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
                _mapper.Map<RegisterCreditCard>(txtFile);
            }
            return  Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateCreditCard(Guid id, CreditCardInputModel request)
        {
            var updateCreditCard = _context.CreditCards.SingleOrDefault(d => d.Id == id);

            if (updateCreditCard == null)
                return NotFound();

            updateCreditCard.Update(request.CreditCardNumber);

            _context.CreditCards.Update(updateCreditCard);
            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteCreditCard(Guid id)
        {
            var deleteCreditCard = _context.CreditCards.SingleOrDefault(d => d.Id == id);

            if (deleteCreditCard.IsDeleted == true)
            {
                return NotFound();
            }

            deleteCreditCard.Delete();

            _context.SaveChanges();

            return NoContent();
        }


        [HttpGet("getByIdCreditCard")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> GetById([FromQuery] string creditCardNumber)
        {
            var getCreditCard = _context.CreditCards.SingleOrDefault(d => d.CreditCardNumber == creditCardNumber);

            if (getCreditCard == null)
                return NotFound();

            var viewModel = _mapper.Map<CreditCardViewModel>(getCreditCard);

            return Ok(viewModel);
        }
    }
}
