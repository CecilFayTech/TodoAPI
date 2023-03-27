using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models.Databases
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ToDoName { get; set; }        
        public bool? IsComplete { get; set; }
      
        public int ToDoCategoryId { get; set; }      
        public ToDoCategory? ToDoCategory { get; set; }
    }
}
