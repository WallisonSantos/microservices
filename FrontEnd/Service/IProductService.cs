
#nullable disable

using Microservices.FrontEnd.Models;

namespace Microservices.FrontEnd.Service;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> FindAllProducts();
    Task<ProductModel> FindProductById(long id);
    Task<ProductModel> CreateProduct(ProductModel productModel);
    Task<ProductModel> UpdateProduct(ProductModel productModel);
    Task<bool> DeleteProductById(long id);
}