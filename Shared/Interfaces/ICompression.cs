using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ICompression
    {
        /// <summary>
        /// Сжимает строку с помощью заданного типа сжатия.
        /// </summary>
        /// <param name="value">Строка для сжатия.</param>
        /// <param name="compressionType">Тип сжатия.</param>
        /// <returns>Сжатые данные в виде массива байт.</returns>
        Task<byte[]> CompressAsync<T>(T value, CompressionMethod compressionType);
        /// <summary>
        /// Сжимает строку с помощью заданного типа сжатия.
        /// </summary>
        /// <param name="value">Массив байт для сжатия.</param>
        /// <param name="compressionType">Тип сжатия.</param>
        /// <returns>Сжатые данные в виде массива байт.</returns>
        Task<byte[]> CompressAsync(byte[] value, CompressionMethod compressionType);
        /// <summary>
        /// Декомпрессирует сжатые данные и десериализует их в объект заданного метода.
        /// </summary>
        /// <typeparam name="T">Тип объекта для десериализации.</typeparam>
        /// <param name="compressedData">Сжатые данные в виде массива байт.</param>
        /// <param name="compressionMethod">Метод сжатия.</param>
        /// <returns>Десериализованный объект типа T.</returns>
        Task<T?> DecompressAsync<T>(byte[] compressedData, CompressionMethod compressionMethod);
    }
}
