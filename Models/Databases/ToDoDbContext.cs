
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TodoAPI.Models.Databases
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) 
        {
          
        }
        public Microsoft.EntityFrameworkCore.DbSet<ToDo> ToDos { get;set; }
        public Microsoft.EntityFrameworkCore.DbSet<ToDoCategory> ToDosCategories { get;set; }
    }
}
