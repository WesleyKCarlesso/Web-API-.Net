using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUser()
        {
            var users = _userRepository.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetById(int id)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }

        [HttpPost]
        public ActionResult<UserModel> Add([FromBody] UserModel userModel)
        {
            var user = _userRepository.Add(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<UserModel> Update([FromBody] UserModel userModel, int id)
        {
            var user = _userRepository.Update(userModel, id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<UserModel> Delete(int id)
        {
            var deleted = _userRepository.Delete(id);

            if (deleted)
            {
                return Ok(deleted);
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }
    }
}
