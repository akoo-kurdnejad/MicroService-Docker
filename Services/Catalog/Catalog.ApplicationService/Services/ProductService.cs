using AutoMapper;
using Catalog.ApplicationService.DTOs;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        #region Constructro
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        #endregion Constructro

        //**************** GetProducts ********************
        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            var result = _mapper.Map<List<ProductDTO>>(products); 
            return result;
        }

        //****************** GetProductById ******************
        public async Task<ProductDTO> GetProductById(string id)
        {
            var product = await _productRepository.GetById(id);
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }

        //**************** GetProductByName ********************
        public async Task<List<ProductDTO>> GetProductsByName(string name)
        {
            var products = await _productRepository.GetByName(name);
            var result = _mapper.Map<List<ProductDTO>>(products);
            return result;
        }

        //***************** GetProductsByCategory *******************
        public async Task<List<ProductDTO>> GetProductsByCategory(string category)
        {
            var products = await _productRepository.GetByCategory(category);
            var result = _mapper.Map<List<ProductDTO>>(products);
            return result;
        }

        //***************** CreateProduct *******************
        public async Task<ProductDTO> CreateProduct(ProductOperationDTO request)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.Create(product);
            var result = await this.GetProductById(product.Id);
            return result;
        }

        //**************** UpdateProduct ********************
        public async Task<bool> UpdateProduct(ProductOperationDTO request)
        {
            var product = _mapper.Map<Product>(request);
            var result = await _productRepository.Update(product);  
            return result;
        }

        //****************** DeleteProduct ******************
        public async Task<bool> DeleteProduct(string id)
        {
            var result = await _productRepository.Delete(id);
            return result;
        }
    }
}
