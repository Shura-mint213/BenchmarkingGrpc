using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    /// <summary>
    /// Интерфейс сжатия данных
    /// </summary>
    public interface IDataCompression
    {
        /// <summary>
        /// Метод сжимает данные
        /// </summary>
        /// <param name="value">Сжимаемые данные</param>
        /// <returns>Результат сжатия в виде массива байт</returns>
        public Task<byte[]> CompressAsync(string value);
        /// <summary>
        /// Метод распаковки данных
        /// </summary>
        /// <typeparam name="T">В какой тип данных распаковать</typeparam>
        /// <param name="value">Распаковываем данные</param>
        /// <returns>Результат распаковки</returns>
        public Task<T?> Decompress<T>(byte[] value);
    }
}
