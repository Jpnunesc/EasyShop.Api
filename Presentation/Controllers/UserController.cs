using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.Product;
using Business.Abstractions.IO.User;
using Business.Abstractions.IO.UserStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/")]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        private ITokenService _tokenService;

        public UserController(IUserService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResult>> Authenticate([FromBody] AuthenticateInput model)
        {
            var user = await _service.AuthenticateAsync(model.Login, model.Password);

            if (user == null || string.IsNullOrEmpty(user.Nome))
                return new AuthenticationResult { Success = false, Message = "Usuário ou senha inválidos" };

            var token = _tokenService.GenerateToken(user);

            user.Senha = "";

            if(token.Any())
            {
                return Ok(new AuthenticationResult
                {
                    Success = true,
                    Message = "Seja bem-vindo!",
                    User = user,
                    Token = token
                });
            } else
            {
                return BadRequest(new AuthenticationResult { Success = false, Message = "Usuário ou senha inválidos" });
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserInsertInput user)
        {
                return Ok(await _service.SaveAsync(user));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UserUpdateInput user)
        {
            return Ok(await _service.UpdateAsync(user));
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
        public async Task<IActionResult> GetList([FromQuery] UserFilter userFilter)
        {
            return Ok(await _service.GetListAsync(userFilter));
        }
        [AllowAnonymous]
        [HttpGet("user-stores-linked-unlinked/{id}")]
        public async Task<IActionResult> GetListUserStoresLinkedUnlinked(int id)
        {
            return Ok(await _service.GetListUserStoresLinkedUnlinkedAsync(id));
        }
        [AllowAnonymous]
        [HttpPost("user-stores-linked-unlinked")]
        public async Task<IActionResult> PostListUserStoresLinkedUnlinked([FromBody] List<UserStoreInsertInput> userStoreInput)
        {
            return Ok(await _service.PostListUserStoresLinkedUnlinkedAsync(userStoreInput));
        }

        [AllowAnonymous]
        [HttpDelete("user-stores-linked-delete")]
        public async Task<IActionResult> DeleteUserStoresLinked(int id)
        {
            return Ok(await _service.DeleteUserStoresLinkedAsync(id));
        }

    }
}
