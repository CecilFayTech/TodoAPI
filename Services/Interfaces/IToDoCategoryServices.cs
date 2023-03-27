using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTO;

namespace TodoAPI.Services.Interfaces
{
    public interface IToDoCategoryServices
    {
        ToDoAction CreateToDoCategory(ToDoCategory todoCategory);
        Task<ToDoCategoryDTO> GetOneToDoCategory(int id);
        Task<List<ToDoCategoryDTO>> GetToDoCategories();
        ToDoAction UpdateToDoCategory(ToDoCategory todoCategory);
        ToDoAction DeleteToDoCategory(int id);       
    }
}
