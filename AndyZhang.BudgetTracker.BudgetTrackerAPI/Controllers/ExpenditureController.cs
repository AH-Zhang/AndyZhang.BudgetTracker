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
    public class ExpenditureController : ControllerBase
    {
        private readonly IUserService _userService;

        public ExpenditureController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenditure()
        {
            var incomes = await _userService.GetAllExpenditures();

            if (incomes == null)
            {
                return NotFound("No Incomes Found");
            }

            return Ok(incomes);
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserExpenditures([FromQuery] int userId)
        {
            var income = await _userService.GetAllUserExpenditures(userId);

            if (income == null)
            {
                return NotFound($"No Income for user {userId} Found");
            }

            return Ok(income);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExpenditure([FromBody] ExpenditureRequestModel expenditure)
        {
            await _userService.AddExpenditure(expenditure);

            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteExpenditure([FromQuery] int id)
        {
            await _userService.DeleteExpenditure(id);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateExpenditure([FromBody] ExpenditureRequestModel expenditure, [FromQuery] int id)
        {
            await _userService.UpdateExpenditure(expenditure, id);

            return Ok();
        }
    }
}
