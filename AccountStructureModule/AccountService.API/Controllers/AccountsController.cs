using AccountService.API.Dtos;
using AccountService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PlayerRepository _playerRepository;
        public AccountsController(PlayerRepository playerRepository )
        {
               _playerRepository = playerRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto playerCreateDto)
        {
          var result= await  _playerRepository.Create(new Data.Entities.Player
            {
                FirstName = playerCreateDto.FirstName,
                UserName = playerCreateDto.UserName,
                LastName= playerCreateDto.LastName
            });
            return Created("", result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from AccountsController");
        }
    }
}
