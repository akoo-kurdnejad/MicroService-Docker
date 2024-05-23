using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summery { get; set; }
        public string Description { get; set; }
        public string ImagFile { get; set; }
        public decimal Price { get; set; }
    }
}
