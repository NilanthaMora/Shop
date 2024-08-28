using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class QuantityTypeController : ControllerBase
    {
        private readonly IQuantityTypeRepository _repo;
        public QuantityTypeController(IQuantityTypeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetQuantityType")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetQuantityTypes());
        }
        [HttpGet]
        [Route("GetQuantityTypeByID/{Id}")]
        public async Task<IActionResult> GetQuantityTypeById(int Id)
        {
            return Ok(await _repo.GetQuantityTypeByID(Id));
        }
        [HttpPost]
        [Route("AddQuantityType")]
        public async Task<IActionResult> Post(QuantityType sto)
        {
            var result = await _repo.InsertQuantityType(sto);
            if (result.QuantityTypeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateQuantityType")]
        public async Task<IActionResult> Put(QuantityType sto)
        {
            await _repo.UpdateQuantityType(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteQuantityType")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _repo.DeleteQuantityType(id);
            return Ok("Deleted Successfully");
        }
    }
}
