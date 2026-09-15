using testAPI_2.DTOs;
using testAPI_2.Models;

namespace testAPI_2.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductsById(int id);
        Product InsertProduct(ProductDto product);
        bool UpdateProduct(int id, ProductDto product);
        bool DeleteProduct(int id);

    }
}
