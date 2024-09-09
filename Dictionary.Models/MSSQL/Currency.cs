
using System.ComponentModel.DataAnnotations;

namespace Dictionary.Models.MSSQL
{
    /// <summary>
    /// Валюты ISO 
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Страна валюты
        /// </summary>
        public string? Country { get; set; } = string.Empty;
        /// <summary>
        /// Валюта 
        /// </summary>
        public string? Name { get; set; } = string.Empty;
        /// <summary>
        /// Код
        /// </summary>
        public string? Code { get; set; } = string.Empty;
        /// <summary>
        /// Номер
        /// </summary>
        public double? Number { get; set; }
    }
}
