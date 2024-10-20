namespace EcommerceAPI.Repository.Interface
{
    public interface ICategory<Category> where Category : class
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Task Save();
    }
}
