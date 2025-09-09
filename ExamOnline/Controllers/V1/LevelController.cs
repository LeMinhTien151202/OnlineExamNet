using ExamOnline.Exceptions;
using ExamOnline.Interfaces.ILevel;
using ExamOnline.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/levels")]
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetLevelById(int id)
        {
            var level = await levelService.GetLevelByIdAsync(id);
            if (level == null)
            {
                throw new NotFoundException($"Level {id} not found");
            }
            return Ok(level);
        }
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateLevel([FromBody] LevelDTO levelDTO)
        {
            if (levelDTO == null)
            {
                throw new BadRequestException("Invalid level data");
            }
            var createdLevel = await levelService.CreateLevelAsync(levelDTO);
            return Ok(createdLevel);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateLevel(int id, [FromBody] LevelDTO levelDTO)
        {
            var updatedLevel = await levelService.UpdateLevelAsync(id, levelDTO);
            if (updatedLevel == null)
            {
                throw new NotFoundException($"Level {id} not found");
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
                throw new NotFoundException($"Level {id} not found");
            }
            return NoContent();
        }
    }
}
