namespace TodoAPI.Models.DTO
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string ToDoName { get; set; }
        public bool IsComplete { get; set; }
        public int ToDoCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

