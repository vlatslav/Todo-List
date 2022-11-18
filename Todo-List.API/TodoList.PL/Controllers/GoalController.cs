using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.BLL.Interfaces;
using TodoList.BLL.Models;

namespace TodoList.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            return Ok(await _goalService.GetAllAsync());
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetConcrateGoal(int Id)
        {
            try
            {
                var result = await _goalService.GetByIdAsync(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddNewGoal([FromBody] GoalModel model)
        {
            try
            {
                await _goalService.AddAsync(model);
                return CreatedAtAction(nameof(AddNewGoal), new { Id = model.Id });

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteGoal(int Id)
        {
            try
            {
                await _goalService.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGoal([FromBody] GoalModel model)
        {
            try
            {
                await _goalService.UpdateAsync(model);
                return Ok();

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> SetDone(int id, [FromQuery] bool done = true) 
        {
            try
            {
                await _goalService.SetDone(id, done);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
