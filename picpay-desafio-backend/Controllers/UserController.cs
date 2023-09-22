using Microsoft.AspNetCore.Mvc;
using picpay_desafio_backend.Data.DTOs;
using picpay_desafio_backend.Service;

namespace picpay_desafio_backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAllUser());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_userService.GetUser(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDTO createUserDTO)
        {
            _userService.CreateUser(createUserDTO);

            return Ok("Usuário criado!");
        }
    }
}
