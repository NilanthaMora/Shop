using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeRepository _repo;
        public PaymentTypeController(IPaymentTypeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetPaymentType")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetPaymentTypes());
        }
        [HttpGet]
        [Route("GetPaymentTypeByID/{Id}")]
        public async Task<IActionResult> GetPaymentTypeById(int Id)
        {
            return Ok(await _repo.GetPaymentTypeByID(Id));
        }
        [HttpPost]
        [Route("AddPaymentType")]
        public async Task<IActionResult> Post(PaymentType sto)
        {
            var result = await _repo.InsertPaymentType(sto);
            if (result.PaymentTypeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdatePaymentType")]
        public async Task<IActionResult> Put(PaymentType sto)
        {
            await _repo.UpdatePaymentType(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeletePaymentType")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _repo.DeletePaymentType(id);
            return Ok("Deleted Successfully");
        }
    }
}
