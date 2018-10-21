using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tapir.Core;

namespace Tapir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<UserDTO>> GetAll()
        {
            List<UserDTO> users = userService.GetUsers();
            return users;
        }

        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<UserDTO> GetById(int id)
        {
            UserDTO user = userService.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<UserDTO> Create(UserDTO user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserDTO newUser = userService.SaveUser(user);
            return CreatedAtRoute(routeName: "GetUser", routeValues: new { id = newUser.Id }, value: newUser);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<UserDTO> Update(int id, UserDTO user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserDTO updatedUser = userService.SaveUser(user);
            if(updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<UserDTO> Delete(int id)
        {
            UserDTO deletedUser = userService.RemoveUser(id);
            if(deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
    }
}
