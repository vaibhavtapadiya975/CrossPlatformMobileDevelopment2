using Microsoft.AspNetCore.Mvc;
using QuestionAPI.Interfaces;
using QuestionAPI.Model;
using QuestionAPI.Services;

namespace QuestionAPI.Controllers
{
    public enum ErrorCode
    {
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }

    #region snippetDI
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController()
        {
            _questionService = new QuestionService(); ;
        }
        #endregion

        #region snippet
        [HttpGet]
        public IActionResult List()
        {
            var t = _questionService.GetAllQuestions().Result;
            Console.WriteLine(t);
            return Ok(t);
        }
        #endregion

        #region snippetCreate
        [HttpPost]
        public IActionResult Create([FromBody] Question item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                _questionService.AddQuestion(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
            return Ok(item);
        }
        #endregion

        #region snippetEdit
        [HttpPut]
        public IActionResult Edit([FromBody] Question item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                var existingItem = _questionService.GetQuestionAsync(item.ID);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _questionService.UpdateQuestion(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return NoContent();
        }
        #endregion

        /*#region snippetDelete
        [HttpDelete("{id}")]
        /*public IActionResult Delete(string id)
        {
            try
            {
                var item = _questionService.GetQuestionAsync(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _questionService.DeleteQuestion(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
        #endregion _questionRepository;*/
    }
       
}
