using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Statics
{
    /// <summary>
    /// Настройка база данных
    /// </summary>
    public static class DatabaseSettings
    {
        /// <summary>
        /// Строка подключения к БД MSSQL
        /// </summary>
        public static string? ConnectionStringMSSQL { get; set; }
        /// <summary>
        /// Строка подключения к БД MongoDB
        /// </summary>
        public static string? ConnectionStringMongoDB { get; set; }
        /// <summary>
        /// Название базы данных
        /// </summary>
        public static string? Database { get; set; }
    }
}
