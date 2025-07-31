using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Model;
using Models.DTO;

namespace Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // הגדרת המרות
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Tasks, TasksDTO>().ReverseMap();
        }
    }
}
