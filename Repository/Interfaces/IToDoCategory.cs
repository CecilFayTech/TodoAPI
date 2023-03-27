using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;

namespace TodoAPI.Repository.Interfaces
{
    public interface IToDoCategory
    {
        Task<IAsyncEnumerable<ToDoCategory>> GetOneToDoCategory(int id);
        ToDoAction DeleteToDoCategory (int id);
        ToDoAction UpdateToDoCategory(ToDoCategory todoCategory);
        ToDoAction CreateToDoCategory(ToDoCategory todoCategory);
        Task<List<ToDoCategory>> GetToDoCategories();
    }
}
