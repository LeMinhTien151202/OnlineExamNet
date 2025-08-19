using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examService.GetAllExamsAsync();
            return Ok(exams);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var category = await _examService.GetExamByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] ExamDTO examDTO)
        {
            if (examDTO == null)
            {
                return BadRequest("exam cannot be null.");
            }
            var createdExam = await _examService.CreateExamAsync(examDTO);
            return CreatedAtAction(nameof(GetExamById), createdExam);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] ExamDTO examDTO)
        {
            if (examDTO == null)
            {
                return BadRequest("exam ID mismatch or null exam.");
            }
            var updatedExam = await _examService.UpdateExamAsync(id, examDTO);
            if (updatedExam == null)
            {
                return NotFound();
            }
            return Ok(updatedExam);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _examService.DeleteExamAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
