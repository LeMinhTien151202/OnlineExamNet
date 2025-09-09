using ExamOnline.Exceptions;
using ExamOnline.Interfaces.ICategory;
using ExamOnline.Interfaces.IQuestion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/questions")]
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
                throw new NotFoundException($"Question {id} not found");
            }
            return Ok(question);
        }
        [HttpPost]
        //[Authorize(Roles = "teacher")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                throw new BadRequestException("Question cannot be null");
            }
            var createdQuestion = await _questionService.CreateQuestionAsync(questionDTO);
            return Ok(createdQuestion);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "teacher")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionDTO questionDTO)
        {
            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, questionDTO);
            if (updatedQuestion == null)
            {
                throw new NotFoundException($"Question {id} not found");
            }
            return Ok(updatedQuestion);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _questionService.DeleteQuestionAsync(id);
            if (!result)
            {
                throw new NotFoundException($"Question {id} not found");
            }
            return NoContent();
        }
    }
}
