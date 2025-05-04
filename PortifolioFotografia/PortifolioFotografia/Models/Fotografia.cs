using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace PortifolioFotografia.Models {
    public class Fotografia {
        [BsonElement("_id")]
        public Guid idFotografia { get; set; }

        public String nomeFotografo { get; set; }
        
        public String descricaoFotografia {  get; set; }

        public DateTime data {  get; set; }  
    }
}
