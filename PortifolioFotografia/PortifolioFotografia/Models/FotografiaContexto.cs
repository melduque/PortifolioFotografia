using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PortifolioFotografia.Config;

namespace PortifolioFotografia.Models {
    public class FotografiaContexto {

        private readonly IMongoDatabase _mongoDatabase;

        public FotografiaContexto(IOptions<ConfigDB> opcoes) {
            Console.WriteLine(opcoes.Value.ConnectionString);
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);


            if(mongoClient != null) {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<Fotografia> Fotografias { 
            get{
                return _mongoDatabase.GetCollection<Fotografia>("Fotografia"); 
            }
        }
    }
}
