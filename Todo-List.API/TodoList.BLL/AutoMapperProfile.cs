using AutoMapper;
using TodoList.BLL.Models;
using TodoList.DAL.Entity;

namespace TodoList.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Goal, GoalModel>().ReverseMap();
        }
    }
}
