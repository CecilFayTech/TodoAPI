using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models.Databases
{
    public class ToDoCategory
    {
    
        [Key]
        public int Id { get; set; }

        [MaxLength (50)]
        public string? CategoryName { get; set; }

        //public ICollection<ToDo> ToDos { get; set; }
    }
}
