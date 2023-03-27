using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;
using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository
{
    public class ToDoRepository : ITodoRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoRepository(ToDoDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<IAsyncEnumerable<ToDo>> GetAllTodos()
        {
            try
            {
                var todos = _context.ToDos.AsAsyncEnumerable();
                return todos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ToDoAction DeleteToDo(int id)
        {
            ToDoAction doAction = new ToDoAction();

            try
            {
                var toDo = _context.ToDos.Find(id);
                if (toDo == null)
                {
                    doAction.IsSuccessful = false;
                    doAction.Message = "ID Not Found";
                    return doAction;
                }
                _context.ToDos.Remove(toDo);
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                doAction.IsSuccessful = false;
                doAction.Message = e.Message;
                return doAction;
            }
            doAction.IsSuccessful = true;
            doAction.Message = "Sucessfully Deleted";
            return doAction;
        }

        public ToDoAction UpdateToDo( ToDo todo)
         {
             ToDoAction doAction = new ToDoAction();
             {
                try
                {
                    _context.Update(todo);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                catch (Exception f)
                {
                    throw f;
                }
                 doAction.IsSuccessful = true;
                 doAction.Message = "Updated Successfully";
                 return doAction;
             }
         }
        
        public ToDoAction CreateToDos(ToDo todo)
        {
            ToDoAction doAction = new ToDoAction();
            {
                try
                {
                    _context.Add(todo);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    throw e;
                }
                catch (Exception f)
                {
                    throw f;
                }
                doAction.IsSuccessful = true;
                doAction.Message = "Created Successfully";
                return doAction;
            }
        }
        
        public async Task<IAsyncEnumerable<ToDo>> GetOneToDo(int id)
        {
            try
            {
                var toDoDb = await _context.ToDos.FindAsync(id);

                if (toDoDb == null)
                {
                    return null;
                }

                return (IAsyncEnumerable<ToDo>)toDoDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ToDoCategory>> GetToDoCategories()
        {
            try
            {
                var result =  _context.ToDosCategories.ToList<ToDoCategory>();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
