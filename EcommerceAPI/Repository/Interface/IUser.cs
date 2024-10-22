using EcommerceAPI.DTO;
using EcommerceAPI.Model;

namespace EcommerceAPI.Repository.Interface
{
    public interface IUser<UserT> where UserT : class
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Add(User entity);
        Task<User> Login(LoginDTO loginDTO);
        void Update(User entity);
        void Delete(User entity);
        Task Save();
    }
}
