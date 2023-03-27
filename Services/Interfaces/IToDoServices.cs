using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTO;

namespace TodoAPI.Services.Interfaces
{
    public interface IToDoServices
    {
        ToDoAction CreateToDos(ToDo todo);
        Task<ToDoDTO> GetOneToDo(int id);
        Task<List<ToDoDTO>> GetAllToDos();
        ToDoAction UpdateToDo(ToDo todo);
        ToDoAction DeleteToDo(int id);
    }
}
