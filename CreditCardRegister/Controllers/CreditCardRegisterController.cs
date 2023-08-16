using AutoMapper;
using CreditCardRegister.API.Auth;
using CreditCardRegister.API.Data;
using CreditCardRegister.API.Entity;
using CreditCardRegister.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Text;

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
        public async Task<IActionResult> RegisterCreditCard([FromBody] CreditCardInputModel request)
        {
            if (request == null)
                return BadRequest();

            var registerCreditCard = _mapper.Map<CreditCard>(request);

            _context.CreditCard.Add(registerCreditCard);
            _context.SaveChanges();
            return Ok(registerCreditCard.CreditCardNumber);
        }  



        [HttpPost("registerBatchCreditCard")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterBatchCreditCard([FromForm] ICollection<IFormFile> batchRegister)
        {

            if (batchRegister == null || batchRegister.Count == 0)
                    return BadRequest();

            List<byte[]> data = new();
            var result = new StringBuilder();
            var registerCreditCard = new RegisterCreditCard();
            var listCreditCards = new List<CreditCard>();
            var creditCard = new CreditCard();
            try
            {
                foreach (var txtFile in batchRegister)
                {
                    if (txtFile.Length > 0)
                    {
                        using (var reader = new StreamReader(txtFile.OpenReadStream()))
                        {
                            while (reader.Peek() >= 0)
                            {
                                result.AppendLine(reader.ReadLine());
                            }

                            var listResult = result.ToString().Replace("\r","").Split('\n').ToList();

                            for (int i = 0; i < listResult.Count(); i++)
                            {
                                if (i == 0)
                                {
                                    registerCreditCard.IdArchive = listResult[i].ToString().Substring(37, 8);
                                    registerCreditCard.BatchName = listResult[i].ToString().Substring(0, 20);
                                    registerCreditCard.BatchDate = listResult[i].ToString().Substring(29, 8);
                                    registerCreditCard.BatchAmount = listResult[i].ToString().Substring(46, 5);
                                    registerCreditCard.CreditCards = listCreditCards;
                                }
                                else if(i<=10)
                                {
                                    creditCard.IdArchiveLine = listResult[i].ToString().Substring(0, 3);
                                    creditCard.CreditCardNumber = listResult[i].ToString().Substring(7, 15);
                                    creditCard.IsDeleted = false;
                                    listCreditCards.Add(creditCard);
                                }                                
                            }
                            registerCreditCard.CreditCards = listCreditCards;
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
            
            var registerBatchCreditCard = _mapper.Map<RegisterCreditCard>(registerCreditCard);
            _context.BatchCreditCard.Add(registerBatchCreditCard);
            

            var creditCardList = _mapper.Map<List<CreditCard>>(registerBatchCreditCard.CreditCards);
            foreach (var item in creditCardList)
            {
                _context.CreditCard.Add(item);
            }

            _context.SaveChanges();

            return  Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateCreditCard(Guid id, CreditCardInputModel request)
        {
            var updateCreditCard = _context.CreditCard.SingleOrDefault(d => d.Id == id);

            if (updateCreditCard == null)
                return NotFound();

            updateCreditCard.Update(request.CreditCardNumber);

            _context.CreditCard.Update(updateCreditCard);
            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteCreditCard(Guid id)
        {
            var deleteCreditCard = _context.CreditCard.SingleOrDefault(d => d.Id == id);

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
            var getCreditCard = _context.CreditCard.SingleOrDefault(d => d.CreditCardNumber == creditCardNumber);

            if (getCreditCard == null)
                return NotFound();

            var viewModel = _mapper.Map<CreditCardViewModel>(getCreditCard);

            return Ok(viewModel);
        }
    }
}
