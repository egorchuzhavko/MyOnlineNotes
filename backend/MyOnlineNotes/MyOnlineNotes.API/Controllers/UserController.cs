using Microsoft.AspNetCore.Mvc;
using MyOnlineNotes.API.Contracts;
using MyOnlineNotes.Application.Services;
using MyOnlineNotes.Core.Models;

namespace MyOnlineNotes.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService) {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers() {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(u => new UsersResponse(u.Id, u.Login, u.Password));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsersResponse>> GetUserById(Guid id) {
            var user = await _usersService.GetById(id);

            var response = new UsersResponse(user.Id, user.Login, user.Password); 

            return Ok(response);
        }

        [HttpGet("{login}")]
        public async Task<ActionResult<UsersResponse>> GetUserByLogin(string login) {
            var user = await _usersService.GetByLogin(login);

            var response = new UsersResponse(user.Id, user.Login, user.Password);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest userRequest) {
            bool loginCheck = await _usersService.CheckLogin(userRequest.login);
            if (!loginCheck)
                return BadRequest("User with that login already exists");

            var (user, error) = Users.Create(
                Guid.NewGuid(),
                userRequest.login,
                userRequest.password);

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            var userId = await _usersService.CreateUser(user);

            return Ok(userId);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Guid>> CheckUser([FromBody] UsersRequest userRequest) {
            bool userCheck = await _usersService.CheckUser(Users.Create(
                Guid.NewGuid(),
                userRequest.login,
                userRequest.password).User);

            return userCheck ? Ok(true) : BadRequest(false);
        }
    }
}
