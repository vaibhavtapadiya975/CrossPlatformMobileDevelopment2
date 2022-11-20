using Microsoft.AspNetCore.Mvc;
using QuestionAPI.Interfaces;
using QuestionAPI.Model;

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
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        #endregion

        #region snippet
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_questionRepository.All);
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
                bool itemExists = _questionRepository.DoesItemExist(item.ID);
                if (itemExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                _questionRepository.Insert(item);
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
                var existingItem = _questionRepository.Find(item.ID);
                if (existingItem == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _questionRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
            return NoContent();
        }
        #endregion

        #region snippetDelete
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var item = _questionRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _questionRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
        #endregion _questionRepository;
    }
       
}
