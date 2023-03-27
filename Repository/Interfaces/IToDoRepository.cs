using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;

namespace TodoAPI.Repository.Interfaces
{
    public interface ITodoRepository
    {
        Task<IAsyncEnumerable<ToDo>> GetAllTodos();
        ToDoAction DeleteToDo(int id);
        Task<IAsyncEnumerable<ToDo>> GetOneToDo(int id);
        ToDoAction UpdateToDo(ToDo todo);        
        ToDoAction CreateToDos(ToDo todo);
        Task<List<ToDoCategory>> GetToDoCategories();
    }
}