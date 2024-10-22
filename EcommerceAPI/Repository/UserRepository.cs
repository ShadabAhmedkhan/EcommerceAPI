using EcommerceAPI.DTO;
using EcommerceAPI.Model;
using EcommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class UserRepository<UserT> : IUser<UserT> where UserT : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAll() => await _dbSet.ToListAsync();
        public async Task<User> GetById(int id) => await _dbSet.FindAsync(id);
        public async Task<Model.User> Login(LoginDTO loginDTO)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.Username == loginDTO.Username && u.Password == loginDTO.Password);

        }

        public async Task Add(User entity) => await _dbSet.AddAsync(entity);
        public void Update(User entity) => _dbSet.Update(entity);
        public void Delete(User entity) => _dbSet.Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
