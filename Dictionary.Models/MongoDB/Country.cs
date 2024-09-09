using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dictionary.Models.MongoDB
{
    /// <summary>
    /// Страны ISO
    /// </summary>
    public class Country
    {
        /// <summary>
        /// ID записи
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Полное название
        /// </summary>
        [BsonIgnoreIfDefault]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Название на английском
        /// </summary>
        public string InEnglish { get; set; } = string.Empty;
        public string Alpha2 { get; set; } = string.Empty;
        public string Alpha3 { get; set; } = string.Empty;
        /// <summary>
        /// ISO код
        /// </summary>
        public string ISO { get; set; } = string.Empty;
        /// <summary>
        /// Часть света
        /// </summary>
        public string PartOfWorld { get; set; } = string.Empty;
        /// <summary>
        /// Место нахождение
        /// </summary>
        public string Location { get; set; } = string.Empty;
    }
}
