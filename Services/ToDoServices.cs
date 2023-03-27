using AutoMapper;
using Microsoft.CodeAnalysis.CodeActions;
using TodoAPI.Mapper;
using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;
using TodoAPI.Models.DTO;
using TodoAPI.Repository.Interfaces;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services
{
    public class ToDoServices : IToDoServices
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public ToDoServices(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public ToDoAction CreateToDos(ToDo todo)
        {
            var create = _todoRepository.CreateToDos(todo);
            return create;
        }

        public  ToDoAction DeleteToDo(int id)
        {
            var r = _todoRepository.DeleteToDo(id);
            return r;
        }

        public async Task<List<ToDoDTO>> GetAllToDos()
        {
            var category = await _todoRepository.GetToDoCategories();
            
            var todos = await  _todoRepository.GetAllTodos();

            var mappedTodos =_mapper.Map<List<ToDoDTO>>(todos);

            return SetTodos(category, mappedTodos);
        }

        private List<ToDoDTO> SetTodos(List<ToDoCategory>? categories, List<ToDoDTO>? toDos)
        {
            foreach (var todo in toDos)
            {
                var category = categories.Where(x=>x.Id == todo.ToDoCategoryId).FirstOrDefault();

                if (category != null)
                todo.CategoryName =  category.CategoryName ;
            }
            return toDos;
        }

        public async Task<ToDoDTO> GetOneToDo(int id)
        {
            var category = await _todoRepository.GetToDoCategories();

            var todos = await _todoRepository.GetAllTodos();

            var mappedTodos = _mapper.Map<List<ToDoDTO>>(todos);
          
            var d = SetTodos(category, mappedTodos);           
            
            return d.Where(x => x.Id == id).FirstOrDefault();
        }

        public ToDoAction UpdateToDo(ToDo todo)
        {
            var update = _todoRepository.UpdateToDo(todo);
            return update;
        }
    }
}
