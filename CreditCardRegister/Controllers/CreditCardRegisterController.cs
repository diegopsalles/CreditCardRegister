using CreditCardRegister.API.Auth;
using CreditCardRegister.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardRegister.API.Controllers
{
    [Route("creditCard")]   
    public class CreditCardRegisterController : ControllerBase
    {

        [HttpPost("registerCreditCard")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> RegisterCreditCard(RegisterCreditCardRequest request)
        {

            return Ok(request);
        }



        [HttpPost("registerBatchCreditCard")]
        [Authorize(Roles = UserRoles.Admin)]
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
            }
            return  Ok();
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
