using EcommerceAPI.Model;
using EcommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class CategoryRepository<Category> : ICategory<Category> where Category : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Category>();
        }
        public async Task<IEnumerable<Category>> GetAll() => await _dbSet.ToListAsync();
        public async Task<Category> GetById(int id) => await _dbSet.FindAsync(id);
        public async Task Add(Category entity) => await _dbSet.AddAsync(entity);
        public void Update(Category entity) => _dbSet.Update(entity);
        public void Delete(Category entity) => _dbSet.Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
