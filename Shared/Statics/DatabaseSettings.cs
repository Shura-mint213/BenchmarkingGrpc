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
        /// Строка подключения к БД
        /// </summary>
        public static string? ConnectionString { get; set; }
    }
}
