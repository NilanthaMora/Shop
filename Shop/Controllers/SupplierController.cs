using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _repo;
        public SupplierController(ISupplierRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetSupplier")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetSupplieres());
        }
        [HttpGet]
        [Route("GetSupplierByID/{Id}")]
        public async Task<IActionResult> GetSupplierById(int Id) 
        {
            return Ok(await _repo.GetSupplierByID(Id));
        }
        [HttpPost]
        [Route("AddSupplier")]
        public async Task<IActionResult> Post(ShopSupplier sto)
        {
            var result = await _repo.InsertSupplier(sto);
            if (result.SupplierId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateSupplier")]
        public async Task<IActionResult> Put(ShopSupplier sto)
        {
            await _repo.UpdateSupplier(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteSupplier")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _repo.DeleteSupplier(id);
            return Ok("Deleted Successfully");
        }
    }
}
