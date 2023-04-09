using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.StoreProduct;
using Business.Abstractions.IO.Store;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Abstractions.IO.Inventory;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class InventoryController : BaseController
    {
        private readonly IInventoryService _service;
        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InventoryMovementInsertInput inventory)
        {
            return Ok(await _service.SaveAsync(inventory));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryMovementUpdateInput inventory)
        {
            return Ok(await _service.UpdateAsync(inventory));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] InventoryMovementFilter inventoryMovementFilter)
        {
            return Ok(await _service.GetListAsync(inventoryMovementFilter));
        }
    }
}
