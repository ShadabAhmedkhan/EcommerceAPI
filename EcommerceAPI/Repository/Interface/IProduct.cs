namespace EcommerceAPI.Repository.Interface
{
    public interface IProduct<Product> where Product : class
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Task Save();
    }
}
