using Butter.Entities;
using Butter.Models;
using Butter.Repositories.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Butter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Injection de dépendance

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        } 

        #endregion

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserModel> result = _userRepository.Get();

            if (result.Count() == 0)
                return NoContent();


            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            UserModel result = _userRepository.GetById(id);

            if (result is null)
                return NoContent();


            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add([FromBody] UserModel user)
        {

            _userRepository.Add(user);

            return CreatedAtAction("Add", user);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_userRepository.Delete(id))
            {
                return BadRequest();
            };

            return NoContent();
        }


        [HttpPatch("Update")]
        public IActionResult Update([FromBody] UserModel user)
        {
       
            if (user is not null)
            {

                _userRepository.Update(user);

                return Ok(user);
            }
            return BadRequest();

        }
    }
}
