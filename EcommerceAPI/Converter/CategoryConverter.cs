using EcommerceAPI.DTO;
using EcommerceAPI.Model;

namespace EcommerceAPI.Converter
{
    public static class CategoryConverter
    {
        public static Category Category(CategoryDTO categorydto) 
        {
            return new Category
            { Id = categorydto.Id, Name = categorydto.Name };
        }
    }
}
