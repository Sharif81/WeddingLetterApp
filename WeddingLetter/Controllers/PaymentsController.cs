using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingLetter.Models;
using WeddingLetter.Repository;

namespace WeddingLetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsController(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }


        //Get All - API

        [HttpGet("")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentsRepository.GetAllPaymentsAsync();
            return Ok(payments);
        }

        //Get API by ID

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById([FromRoute] int id)
        {
            var payment = await _paymentsRepository.GetPaymentByIdAsync(id);
            if(payment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(payment);
            }
        }


        //ADD Payment API
        [HttpPost("Add-Payments")]
        public async Task<IActionResult> AddNewPayment([FromBody] PaymentsModel paymentsModel)
        {
            var id = await _paymentsRepository.AddPaymentsAsync(paymentsModel);
            return CreatedAtAction(nameof(GetPaymentById), new { id = id, Controller = "Payments" }, id);
        }

        //Update Payment - API
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentsModel paymentsModel, [FromRoute] int id)
        {
            await _paymentsRepository.UpdatePaymentsAsync(id, paymentsModel);
            return Ok("Updated");
        }


        //Update Payment Partial - API
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePaymentPartial([FromBody] JsonPatchDocument paymentModel, [FromRoute] int id)
        {
            await _paymentsRepository.UpdatePaymentsAsyncByPartial(id, paymentModel);
            return Ok("Partial Updated");
        }


        //Delete Venue - API
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentById(int id)
        {
            var payment = await _paymentsRepository.DeletePaymentByIdAsync(id);
            if (payment)
            {
                return Ok(new { message = "Deleted" });
            }
            else
            {
                return NotFound(new { message = "Payments Not Found" });
            }
        }


    }
}
