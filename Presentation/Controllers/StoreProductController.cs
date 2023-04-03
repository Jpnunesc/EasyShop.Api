using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Store;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class StoreProductController : BaseController
    {
        private readonly IStoreProductService _service;
        public StoreProductController(IStoreProductService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StoreProductInsertInput product)
        {
            return Ok(await _service.SaveAsync(product));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] StoreProductUpdateInput product)
        {
            return Ok(await _service.UpdateAsync(product));
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
            return Ok(await _service.GetByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] StoreProductFilter productFilter)
        {
            return Ok(await _service.GetListAsync(productFilter));
        }
    }
}
