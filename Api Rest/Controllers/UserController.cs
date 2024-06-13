using Api_Rest.Models;
using Api_Rest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Rest.Controllers
{
    [Route("/User")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("/GetAllUser")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [Route("/GetByIdUser/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Route("/AddUser")]
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _userRepository.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [Route("/UpdateUser/{id}")]
        [HttpPut]
        public IActionResult UpdateStudentPresence(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Update(user);
            return NoContent();
        }

        [Route("/DeleteUser/{id}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);
            return NoContent();
        }

        [Route("/GetUserByCredentials")]
        [HttpPost]
        public async Task<ActionResult<User>> GetUserByCredentials([FromBody] LoginModel loginModel)
        {
            var user = await _userRepository.GetUserByCredentialsAsync(loginModel.Username, loginModel.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
