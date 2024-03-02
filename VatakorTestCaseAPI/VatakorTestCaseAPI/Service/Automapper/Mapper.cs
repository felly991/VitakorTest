using static System.Runtime.InteropServices.JavaScript.JSType;
using VatakorTestCaseAPI.Models;
using VitakorTestCaseAPI.DTOs;
using AutoMapper;

namespace VatakorTestCaseAPI.Service.Automapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserModelDTO, User>();
            CreateMap<User, UserModelDTO>();
            CreateMap<LotDTO, Lot>();
            CreateMap<Lot, LotDTO>();
            CreateMap<UserModelDTO, User>();
            CreateMap<User, UserModelDTO>();
            CreateMap<RegistrationDTO, User>();
            CreateMap<User, RegistrationDTO>();
        }
    }
}
