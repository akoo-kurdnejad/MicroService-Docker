using Catalog.Domain.DTOs.Configuration;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.DataAccess.Context
{
    public class CatalogDBContext : ICatalogDBContext
    {
        private readonly SiteSettings _siteSettings;
        public CatalogDBContext(IOptions<SiteSettings> option)
        {
            _siteSettings = option.Value;
            var client = new MongoClient(_siteSettings.DatabaseSettings.ConnectionString);
            var database = client.GetDatabase(_siteSettings.DatabaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(_siteSettings.DatabaseSettings.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
