using Catalog.ApplicationService.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.ApplicationService.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts();

        Task<ProductDTO> GetProductById(string id);

        Task<List<ProductDTO>> GetProductsByName(string name);

        Task<List<ProductDTO>> GetProductsByCategory(string category);

        Task<ProductDTO> CreateProduct(ProductOperationDTO product);

        Task<bool> UpdateProduct(ProductOperationDTO product);

        Task<bool> DeleteProduct(string id);
    }
}
