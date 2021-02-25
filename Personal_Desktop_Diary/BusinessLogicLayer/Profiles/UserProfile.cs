using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLibrary.Models;

namespace BusinessLogicLayer.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
