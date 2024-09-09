using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dictionary.Models.MongoDB
{
    /// <summary>
    /// Валюты ISO 
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// ID записи
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
        /// <summary>
        /// Страна валюты
        /// </summary>
        public string Country { get; set; } = string.Empty;
        /// <summary>
        /// Валюта 
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; } = string.Empty;
    }
}
