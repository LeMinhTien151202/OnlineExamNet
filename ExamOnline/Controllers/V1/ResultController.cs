using ExamOnline.Exceptions;
using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/results")]
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
                throw new NotFoundException($"Result {id} not found");
            }
            return Ok(result);
        }
        [HttpPost]
        //[Authorize(Roles = "user")]
        public async Task<IActionResult> CreateResult([FromBody] ResultDTO resultDTO)
        {
            var createdResult = await _resultService.CreateResultAsync(resultDTO);
            return Ok(createdResult);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateResult(int id, [FromBody] ResultDTO resultDTO)
        {
            var updatedResult = await _resultService.UpdateResultAsync(id, resultDTO);
            if (updatedResult == null)
            {
                throw new NotFoundException($"Result {id} not found");
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
                throw new NotFoundException($"Result {id} not found");
            }
            return NoContent();
        }
    }
}
