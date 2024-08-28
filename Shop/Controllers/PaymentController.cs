using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repo;
        public PaymentController(IPaymentRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetPayment")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetPayments());
        }
        [HttpGet]
        [Route("GetPaymentByID/{Id}")]
        public async Task<IActionResult> GetPaymentById(string Id)
        {
            return Ok(await _repo.GetPaymentByID(Id));
        }
        [HttpPost]
        [Route("AddPayment")]
        public async Task<IActionResult> Post(Payment sto)
        {
            var result = await _repo.InsertPayment(sto);
            if (result.PaymentId == "")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdatePayment")]
        public async Task<IActionResult> Put(Payment sto)
        {
            await _repo.UpdatePayment(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeletePayment")]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _repo.DeletePayment(id);
            return Ok("Deleted Successfully");
        }
    }
}
