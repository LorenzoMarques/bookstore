using AutoMapper;
using bookstore.Dtos.User;
using bookstore.Models;
namespace bookstore.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(); 
        }
    }
}
