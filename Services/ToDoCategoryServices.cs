using AutoMapper;
using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTO;
using TodoAPI.Repository.Interfaces;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services
{
    public class ToDoCategoryServices : IToDoCategoryServices
    {
        private readonly IToDoCategory _todoCategory;
        private readonly IMapper _mapper;

        public ToDoCategoryServices(IToDoCategory todoCategory, IMapper mapper)
        {
            _todoCategory = todoCategory;
            _mapper = mapper;
        }

        public ToDoAction CreateToDoCategory(ToDoCategory todoCategory)
        {
            var create = _todoCategory.CreateToDoCategory(todoCategory);
            return create;
        }

        public ToDoAction DeleteToDoCategory(int id)
        {
            var r = _todoCategory.DeleteToDoCategory(id);
            return r;
        }

        public async Task<List<ToDoCategoryDTO>> GetToDoCategories()
        {           
            var category = await  _todoCategory.GetToDoCategories();
            return _mapper.Map<List<ToDoCategoryDTO>>(category);
        }

        public async Task<ToDoCategoryDTO> GetOneToDoCategory(int id)
        {
            var category = await _todoCategory.GetToDoCategories();
            var d = _mapper.Map<List<ToDoCategoryDTO>>(category);
            return d.Where(x => x.Id == id).FirstOrDefault();
        }

        public ToDoAction UpdateToDoCategory(ToDoCategory todoCategory)
        {
            var update = _todoCategory.UpdateToDoCategory(todoCategory);
            return update;
        }
    }
}
