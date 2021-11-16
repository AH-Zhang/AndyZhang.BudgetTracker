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
    public class IncomeController : ControllerBase
    {
        private readonly IUserService _userService;

        public IncomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIcomes()
        {
            var incomes = await _userService.GetAllIncomes();

            if (incomes == null)
            {
                return NotFound("No Incomes Found");
            }

            return Ok(incomes);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserIncomes([FromQuery] int userId)
        {
            var income = await _userService.GetAllUserIncomes(userId);

            if (income == null)
            {
                return NotFound($"No Income for user {userId} Found");
            }

            return Ok(income);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateIncome([FromBody] IncomeRequestModel income)
        {
            await _userService.AddIncome(income);

            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteIncome([FromQuery] int id)
        {
            await _userService.DeleteIncome(id);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateIncome([FromBody] IncomeRequestModel income, [FromQuery] int id)
        {
            await _userService.UpdateIncome(income, id);

            return Ok();
        }
    }
}
