using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models.Databases;
using TodoAPI.Models.DTO;
using TodoAPI.Services;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/ToDoCategoryController")]
    [ApiController]
    public class ToDoCategoryController : Controller
    {
        private readonly IToDoCategoryServices _toDoCategoryServices;

        public ToDoCategoryController(IToDoCategoryServices toDoCategoryServices)
        {
            _toDoCategoryServices = toDoCategoryServices;
        }

        [HttpGet]
        [Route("GetToDoCategories")]
        public async Task<ActionResult<IEnumerable<ToDoCategoryDTO>>> GetToDoCategories()
        {
            var todocategory = await _toDoCategoryServices.GetToDoCategories();
            if (todocategory == null)
            {
                return NotFound("No entries available");
            }
            return Ok(todocategory);
        }

        [HttpGet]
        [Route("GetOneToDoCategory")]
        public async Task<ActionResult> GetOneToDoCategory(int id)
        {
            var todoCategory = await _toDoCategoryServices.GetOneToDoCategory(id);
            if (todoCategory == null)
            {
                return NotFound("Entry does not exist");
            }
            return Ok(todoCategory);
        }

        [HttpPost]
        [Route("CreateToDoCategory")]
        public ActionResult CreateToDoCategory(ToDoCategory todoCategory) 
        {
            var todos = _toDoCategoryServices.CreateToDoCategory(todoCategory);
            if (todos.IsSuccessful == true)
            {
                return CreatedAtAction(("GetToDoCategories"), todoCategory.Id, todoCategory);                
            }
            return BadRequest(todos.Message);
        }

        [HttpDelete]
        [Route("DeleteToDoCategory")]
        public ActionResult DeleteToDo(int id)
        {
            var todoCategory = _toDoCategoryServices.DeleteToDoCategory(id);
            if (todoCategory.IsSuccessful == false)
            {
                return BadRequest(todoCategory.Message);
            }
            return Ok(todoCategory.Message);
        }

        [HttpPut]
        [Route("UpdateToDoCategory")]
        public ActionResult UpdateToDoCategory(ToDoCategory todoCategory)
        {
            var todos = _toDoCategoryServices.UpdateToDoCategory(todoCategory);
            if (todos.IsSuccessful == false)
            {
                return BadRequest(todos.Message);
            }
            todos.IsSuccessful = true;
            return Ok(todos.Message);
        }

    }
}
