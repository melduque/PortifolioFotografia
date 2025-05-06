using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace PortifolioFotografia.Models {
    public class Fotografia {
        [BsonElement("_id")]
        [BsonGuidRepresentation(GuidRepresentation.Standard)] 
        public Guid idFotografia { get; set; }

        public String nomeFotografo { get; set; }
        public string imagemBase64 { get; set; }

        public String descricaoFotografia {  get; set; }

        public DateOnly data {  get; set; }  
    }
}
