using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierInsertInput supplier)
        {
            return Ok(await _service.SaveAsync(supplier));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] SupplierUpdateInput supplier)
        {
            return Ok(await _service.UpdateAsync(supplier));
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
        public async Task<IActionResult> GetList([FromQuery] SupplierFilter storeFilter)
        {
            return Ok(await _service.GetListAsync(storeFilter));
        }
    }
}
