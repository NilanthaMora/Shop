using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repo;
        public CartController(ICartRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetShoppingCart")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetShoppingCarts());
        }
        [HttpGet]
        [Route("GetShoppingCartByID/{Id}")]
        public async Task<IActionResult> GetShoppingCartById(string Id)
        {
            return Ok(await _repo.GetShoppingCartByID(Id));
        }
        [HttpPost]
        [Route("AddShoppingCart")]
        public async Task<IActionResult> Post(ShoppingCart sto)
        {
            var result = await _repo.InsertShoppingCart(sto);
            if (result.CartId == "")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateShoppingCart")]
        public async Task<IActionResult> Put(ShoppingCart sto)
        {
            await _repo.UpdateShoppingCart(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteShoppingCart")]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _repo.DeleteShoppingCart(id);
            return Ok("Deleted Successfully");
        }
    }
}
