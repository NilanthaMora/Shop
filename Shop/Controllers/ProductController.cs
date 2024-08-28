using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetShopProducts());
        }
        [HttpGet]
        [Route("GetProductByID/{Id}")]
        public async Task<IActionResult> GetProductById(string Id)
        {
            return Ok(await _repo.GetShopProductByID(Id));
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post(ShopProduct sto)
        {
            var result = await _repo.InsertShopProduct(sto);
            if (result.ProductId == "")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put(ShopProduct sto)
        {
            await _repo.UpdateShopProduct(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteProduct")]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _repo.DeleteShopProduct(id);
            return Ok("Deleted Successfully");
        }
    }
}
