using ApplicationCore.Model;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndyZhang.BudgetTracker.BudgetTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users == null)
            {
                return NotFound("No Users Found");
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> GetUser([FromQuery] int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound($"No User {id} Found");
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody]UserRequestModel user)
        {
            var res = await _userService.AddUser(user) ;
            if (res)
            {
                return Ok();
            }


            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            await _userService.DeleteUser(id);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestModel user, [FromQuery] int id)
        {
            await _userService.UpdateUser(user, id);

            return Ok();
        }
    }
}
