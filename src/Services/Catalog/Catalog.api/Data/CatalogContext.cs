using Catalog.api.Entities;
using MongoDB.Driver;

namespace Catalog.api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration Configuration)
        {
            var mongoClient = new MongoClient(Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var Database = mongoClient.GetDatabase(Configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            products = Database.GetCollection<Product>(Configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(products);
        }
        public IMongoCollection<Product> products { get; }
    }
}
