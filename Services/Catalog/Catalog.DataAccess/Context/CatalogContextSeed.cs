using Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.DataAccess.Context
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetSeedData());
            }
        }

        private static IEnumerable<Product> GetSeedData()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = "29c16fd953c94c2292d91235",
                    Name = "Asus Laptop",
                    Category = "Computers",
                    Description = "Asus Laptop",
                    Summery = "Offic",
                    ImagFile = "kasfbkjsadfkjsafkjffaasfsdafsdsdjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjllllaaaaaaaaaaaaaaa",
                    Price = 25000000
                },
                new Product
                {
                    Id = "29c16fd953c94c2292d91236",
                    Name = "MSI Laptop",
                    Category = "Computers",
                    Description = "MSI Laptop",
                    Summery = "Gamming",
                    ImagFile = "kasfbkjsadfkjsafkjffaasfsdafsdsdjjjjjjjjjjjjjjjjllllaaaaaaaaaaaaaaa",
                    Price = 15000000
                },
                new Product
                {
                    Id = "29c16fd953c94c2292d91237",
                    Name = "Lenovo Laptop",
                    Category = "Computers",
                    Description = "Lenovo Laptop",
                    Summery = "Personnal",
                    ImagFile = "kasfbkjsadfkjsafkjffaasfsdafsdsdjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjaaaaaaa",
                    Price = 20000000
                },
                new Product
                {
                    Id = "29c16fd953c94c2292d91238",
                    Name = "Asus PC",
                    Category = "PC",
                    Description = "Asus PC",
                    Summery = "Offic",
                    ImagFile = "kasfbkjsadfkjsafkjffaasfsdafsdsdjjjjjllllaaaaaaaaaaaaaaa",
                    Price = 30000000
                },
                new Product
                {
                    Id = "29c16fd953c94c2292d91239",
                    Name = "Captiva Laptop",
                    Category = "Computers",
                    Description = "Captiva Laptop",
                    Summery = "Working",
                    ImagFile = "kasfbkjsadfkjsafkjffaasfllaaaaaaaaaaaaaaa",
                    Price = 45000000
                },
            };
        }
    }
}
