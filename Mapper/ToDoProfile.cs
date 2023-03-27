using AutoMapper;
using TodoAPI.Models.Databases;
using TodoAPI.Models.DTO;

namespace TodoAPI.Mapper
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoDTO>();
            CreateMap<ToDoCategory, ToDoCategoryDTO>();
        }
    }
}
