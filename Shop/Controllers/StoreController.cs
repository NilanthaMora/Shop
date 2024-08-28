using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _store;
        public StoreController(IStoreRepository store)
        {
            _store = store;
        }
        [HttpGet]
        [Route("GetStore")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _store.GetStores());
        }
        [HttpGet]
        [Route("GetStoreByID/{Id}")]
        public async Task<IActionResult> GetSotreById(int Id)
        {
            return Ok(await _store.GetStoreByID(Id));
        }
        [HttpPost]
        [Route("AddStore")]
        public async Task<IActionResult> Post(Store sto)
        {
            var result = await _store.InsertStore(sto);
            if (result.StoreId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateStore")]
        public async Task<IActionResult> Put(Store sto)
        {
            await _store.UpdateStore(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteStore")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _store.DeleteStore(id);
            return Ok("Deleted Successfully");
        }
    }
}
