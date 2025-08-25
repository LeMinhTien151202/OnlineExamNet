using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IExam;
using ExceptionHandleDemo.Exceptions;
using Microsoft.AspNetCore.Authorization;
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
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null)
            {
                throw new NotFoundException($"Exam {id} not found");
            }
            return Ok(exam);
        }
        [HttpPost]
        //[Authorize(Roles = "teacher")]
        public async Task<IActionResult> CreateExam([FromForm] ExamDTO examDTO)
        {
            var createdExam = await _examService.CreateExamAsync(examDTO);
            return Ok(examDTO);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "teacher")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] ExamDTO examDTO)
        {
            var updatedExam = await _examService.UpdateExamAsync(id, examDTO);
            if (updatedExam == null)
            {
                throw new NotFoundException($"Exam {id} not found");
            }
            return Ok(updatedExam);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "teacher")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _examService.DeleteExamAsync(id);
            if (!result)
            {
                throw new NotFoundException($"Category {id} not found");
            }
            return NoContent();
        }
    }
}
