using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;
        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllResults()
        {
            var results = await _resultService.GetAllResultsAsync();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResultById(int id)
        {
            var result = await _resultService.GetResultByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Roles = "user")]
        public async Task<IActionResult> CreateResult([FromBody] ResultDTO resultDTO)
        {
            if (resultDTO == null)
            {
                return BadRequest("Result cannot be null.");
            }
            var createdResult = await _resultService.CreateResultAsync(resultDTO);
            return Ok(createdResult);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateResult(int id, [FromBody] ResultDTO resultDTO)
        {
            if (resultDTO == null)
            {
                return BadRequest("Result ID mismatch or null result.");
            }
            var updatedResult = await _resultService.UpdateResultAsync(id, resultDTO);
            if (updatedResult == null)
            {
                return NotFound();
            }
            return Ok(updatedResult);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            var result = await _resultService.DeleteResultAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
