using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models.Databases;
using TodoAPI.Models.DTO;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/ToDoController")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly IToDoServices _toDoServices;

        public ToDoController(IToDoServices toDoServices)
        {
            _toDoServices = toDoServices;
        }

        [HttpGet]
        [Route("GetAllToDos")]
        public  async Task<ActionResult<IEnumerable<ToDoDTO>>> GetAllToDos()
        {
            var todos = await  _toDoServices.GetAllToDos();
            if (todos == null)
            {
                return NotFound("No entries available");
            }
            return  Ok(todos);
        }

        [HttpGet]
        [Route("GetOneToDo")]
        public async Task<ActionResult> GetOneToDo(int id)
        {
            var todos = await _toDoServices.GetOneToDo(id);
            if (todos == null)
            {
                return NotFound("Entry does not exist");
            }
            return Ok(todos);
        }

        [HttpPost]
        [Route("CreateAToDo")]
        public ActionResult CreateToDos(ToDo todo)
        {
            var todos = _toDoServices.CreateToDos(todo);
            if (todos.IsSuccessful == true)
            {
                return CreatedAtAction(("GetAllToDos"), todo.Id, todo);
            }
            return BadRequest(todos.Message);
        }

        [HttpDelete]
        [Route("DeleteToDo")]
        public  ActionResult DeleteToDo(int id)
        {
            var todos =  _toDoServices.DeleteToDo(id);
            if (todos.IsSuccessful == false)
            {
                return BadRequest(todos.Message);
            }
            return Ok(todos.Message);
        }

        [HttpPut]
        [Route("UpdateToDo")]
        public ActionResult UpdateToDo(ToDo todo)
        {           
            var todos = _toDoServices.UpdateToDo( todo);
            if (todos.IsSuccessful == false)
            {
                return BadRequest(todos.Message);
            }
            todos.IsSuccessful = true;           
            return Ok(todos.Message);
        }
    }
}

