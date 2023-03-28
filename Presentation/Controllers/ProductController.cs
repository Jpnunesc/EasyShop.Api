using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.Store;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Customer.Controllers;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductInsertInput product)
        {
            return Ok(await _service.SaveAsync(product));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateInput product)
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
        public async Task<IActionResult> GetList([FromQuery] ProductFilter productFilter)
        {
            return Ok(await _service.GetListAsync(productFilter));
        }
    }
}
