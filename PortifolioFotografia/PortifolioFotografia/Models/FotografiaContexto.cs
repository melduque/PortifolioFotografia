using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PortifolioFotografia.Config;

namespace PortifolioFotografia.Models {
    public class FotografiaContexto {

        private readonly IMongoDatabase _mongoDatabase;

        public FotografiaContexto() {

            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

            if(mongoClient != null) {
                _mongoDatabase = mongoClient.GetDatabase("PortifolioFotografias");
            }
        }

        public IMongoCollection<Fotografia> Fotografias { 
            get{
                return _mongoDatabase.GetCollection<Fotografia>("Fotografia"); 
            }
        }
    }
}
