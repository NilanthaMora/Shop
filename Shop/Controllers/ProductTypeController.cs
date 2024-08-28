using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _repo;
        public ProductTypeController(IProductTypeRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize]
        [Route("GetProductType")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetProductTypes());
        }
        [HttpGet]
        [Route("GetProductTypeByID/{Id}")]
        public async Task<IActionResult> GetProductTypeById(int Id)
        {
            return Ok(await _repo.GetProductTypeByID(Id));
        }
        [HttpPost]
        [Route("AddProductType")]
        public async Task<IActionResult> Post(ProductType sto)
        {
            var result = await _repo.InsertProductType(sto);
            if (result.ProductTypeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateProductType")]
        public async Task<IActionResult> Put(ProductType sto)
        {
            await _repo.UpdateProductType(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteProductType")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _repo.DeleteProductType(id);
            return Ok("Deleted Successfully");
        }
    }
}
