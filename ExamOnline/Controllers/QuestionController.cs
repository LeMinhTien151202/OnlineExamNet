using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IQuestion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return BadRequest("question cannot be null.");
            }
            var createdQuestion = await _questionService.CreateQuestionAsync(questionDTO);
            return Ok(createdQuestion);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return BadRequest("Question ID mismatch or null question.");
            }
            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, questionDTO);
            if (updatedQuestion == null)
            {
                return NotFound();
            }
            return Ok(updatedQuestion);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _questionService.DeleteQuestionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
