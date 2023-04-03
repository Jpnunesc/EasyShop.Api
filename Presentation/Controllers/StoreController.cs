using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : BaseController
    {
        private IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StoreInsertInput store)
        {
                return Ok(await _service.SaveAsync(store));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] StoreUpdateInput store)
        {
            return Ok(await _service.UpdateAsync(store));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] StoreFilter storeFilter)
        {
            var idUserStores = IdsUserStoresSession();
            if (idUserStores != null)
            {
                storeFilter.ListIdStore = idUserStores.ToList();
            }
            return Ok(await _service.GetListAsync(storeFilter));
        }
    }
}
