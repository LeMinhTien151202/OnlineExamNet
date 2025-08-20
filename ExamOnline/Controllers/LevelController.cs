using ExamOnline.Interfaces.ILevel;
using ExamOnline.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService levelService;
        public LevelController(ILevelService levelService)
        {
            this.levelService = levelService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLevel()
        {
            var levels = await levelService.GetAllLevelAsync();
            return Ok(levels);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLevelById(int id)
        {
            var level = await levelService.GetLevelByIdAsync(id);
            if (level == null)
            {
                return NotFound();
            }
            return Ok(level);
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateLevel([FromBody] LevelDTO levelDTO)
        {
            if (levelDTO == null)
            {
                return BadRequest("Level cannot be null.");
            }
            var createdLevel = await levelService.CreateLevelAsync(levelDTO);
            return Ok(createdLevel);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateLevel(int id, [FromBody] LevelDTO levelDTO)
        {
            if (levelDTO == null)
            {
                return BadRequest("Level ID mismatch or null level.");
            }
            var updatedLevel = await levelService.UpdateLevelAsync(id, levelDTO);
            if (updatedLevel == null)
            {
                return NotFound();
            }
            return Ok(updatedLevel);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            var result = await levelService.DeleteLevelAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
