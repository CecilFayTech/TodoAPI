using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models.Databases;
using TodoAPI.Models.Domain;
using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository
{
    public class ToDoCategoryRepository : IToDoCategory
    {
        private readonly ToDoDbContext _context;
        private readonly IMapper _mapper;

        public ToDoCategoryRepository(ToDoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ToDoAction CreateToDoCategory(ToDoCategory todoCategory)
        {
            ToDoAction doAction = new ToDoAction();
            {
                try
                {
                    _context.Add(todoCategory);
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

        public ToDoAction DeleteToDoCategory(int id)
        {
            ToDoAction doAction = new ToDoAction();

            try
            {
                var toDoCategory = _context.ToDosCategories.Find(id);
                if (toDoCategory == null)
                {
                    doAction.IsSuccessful = false;
                    doAction.Message = "ID Not Found";
                    return doAction;
                }
                _context.ToDosCategories.Remove(toDoCategory);
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

        public async Task<List<ToDoCategory>> GetToDoCategories()
        {
            try
            {
                var result = await _context.ToDosCategories.ToListAsync();
                return _mapper.Map<List<ToDoCategory>>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IAsyncEnumerable<ToDoCategory>> GetOneToDoCategory(int id) 
        {
            try
            {
                var toDoDb = await _context.ToDosCategories.FindAsync(id);

                if (toDoDb == null)
                {
                    return null;
                }
                return (IAsyncEnumerable<ToDoCategory>)toDoDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ToDoAction UpdateToDoCategory(ToDoCategory todoCategory)
        {
            ToDoAction doAction = new ToDoAction();
            {
                try
                {
                    _context.Update(todoCategory);
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
    }
}
