using EcommerceAPI.DTO;
using EcommerceAPI.Model;

namespace EcommerceAPI.Converter
{
    public static class UserConverter
    {
        public static User User(LoginDTO userDTO)
        {
            return new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password,    
            };
        }
    }
}
