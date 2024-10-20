using EcommerceAPI.DTO;
using EcommerceAPI.Model;

namespace EcommerceAPI.Converter
{
    public static class ProductConverter
    {
        public static Product Product(ProductDTO productDTO)
        {
            return new Product
            { 
                Id = productDTO.Id, 
                Name = productDTO.Name,
                Price = productDTO.Price,
                ImageUrl =productDTO.ImageUrl,
                Description = productDTO.Description,
                CategoryId =productDTO.CategoryId 
            };
        }
    }
}
