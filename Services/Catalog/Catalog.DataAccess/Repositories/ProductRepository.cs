using Catalog.DataAccess.Context;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using MongoDB.Driver;

namespace Catalog.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Constructor
        private readonly ICatalogDBContext _context;

        public ProductRepository(ICatalogDBContext context)
        {
            _context = context;
        }
        #endregion Constructor

        //############### GetProducts ###############
        public async Task<IEnumerable<Product>> GetAll()
        {
            var ss = await _context.Products.Find(current => true).ToListAsync();
            return await _context.Products.Find(current => true).ToListAsync();
        }

        //############## GetProductsByCategory ################
        public async Task<IEnumerable<Product>> GetByCategory(string category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Category, category);
            return await _context.Products.Find(filter).ToListAsync();
        }

        //############## GetProductByName ################
        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        //############### GetProductById ###############
        public async Task<Product> GetById(string id)
        {
            return await _context.Products.Find(current => current.Id == id).FirstOrDefaultAsync();
        }

        //############## CreateProduct ################
        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        //############## UpdateProduct ################
        public async Task<bool> Update(Product product)
        {
            var result =  await _context.Products.ReplaceOneAsync(filter : current => current.Id == product.Id , replacement: product);
            return result.IsAcknowledged && result.ModifiedCount > 0;   
        }

        //############### DeleteProduct ###############
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(c => c.Id, id);
            var result = await _context.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;    
        }
    }
}
