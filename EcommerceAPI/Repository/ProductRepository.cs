using EcommerceAPI.Model;
using EcommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class ProductRepository<Product> : IProduct<Product> where Product : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public async Task<IEnumerable<Product>> GetAll() => await _dbSet.ToListAsync();
        public async Task<Product> GetById(int id) => await _dbSet.FindAsync(id);
        public async Task Add(Product entity) => await _dbSet.AddAsync(entity);
        public void Update(Product entity) => _dbSet.Update(entity);
        public void Delete(Product entity) => _dbSet.Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
