using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repository.Interface;

namespace Shop.Controllers
{
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _repo;
        public LogController(ILogRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetShopLog")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetShopLogs());
        }
        [HttpGet]
        [Route("GetShopLogByID/{Id}")]
        public async Task<IActionResult> GetShopLogById(string Id)
        {
            return Ok(await _repo.GetShopLogByID(Id));
        }
        [HttpPost]
        [Route("AddShopLog")]
        public async Task<IActionResult> Post(ShopLog sto)
        {
            var result = await _repo.InsertShopLog(sto);
            if (result.LogId == "")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        
    }
}
