using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Enums;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Сompression
{
    public class DataCompression : ICompression
    {
        /// <summary>
        /// Метод определяет, какой класс сжатия вернуть из <paramref name="cm"/>.
        /// </summary>
        /// <param name="cm">Метод сжатия данных</param>
        /// <returns>Класс сжатия</returns>
        [Obsolete("Вместо создания отдельных классов следует использовать метод для получения потока для сжатия.")]
        private IDataCompression GetCompressionClass(CompressionMethod cm)
        {
            return cm switch
            {
                CompressionMethod.GZip => new GZipCompression(),
                CompressionMethod.Brotli => new BrotliCompression(),
                _ => new GZipCompression()
            };
        }

        /// <summary>
        /// Сжимает строку с помощью заданного типа сжатия.
        /// </summary>
        /// <param name="value">Строка для сжатия.</param>
        /// <param name="compressionType">Тип сжатия.</param>
        /// <returns>Сжатые данные в виде массива байт.</returns>
        public async Task<byte[]> CompressAsync<T>(T value, CompressionMethod compressionType)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            string json = JsonConvert.SerializeObject(value);

            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return await CompressAsync(bytes, compressionType);
        }

        /// <summary>
        /// Сжимает строку с помощью заданного типа сжатия.
        /// </summary>
        /// <param name="value">Массив байт для сжатия.</param>
        /// <param name="compressionType">Тип сжатия.</param>
        /// <returns>Сжатые данные в виде массива байт.</returns>
        public async Task<byte[]> CompressAsync(byte[] value, CompressionMethod compressionType)
        {
            if (value is null || value.Length == 0)
                throw new ArgumentNullException(nameof(value));

            using (var memoryStream = new MemoryStream())
            {
                using (Stream compressionStream = 
                    GetCompressionStream(memoryStream, compressionType, CompressionLevel.Optimal))
                {
                    await compressionStream.WriteAsync(value, 0, value.Length);
                }
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Декомпрессирует сжатые данные и десериализует их в объект заданного метода.
        /// </summary>
        /// <typeparam name="T">Тип объекта для десериализации.</typeparam>
        /// <param name="compressedData">Сжатые данные в виде массива байт.</param>
        /// <param name="compressionMethod">Метод сжатия.</param>
        /// <returns>Десериализованный объект типа T.</returns>
        public async Task<T?> DecompressAsync<T>(byte[] compressedData, CompressionMethod compressionMethod)
        {
            if (compressedData is null || compressedData.Length == 0)
                throw new ArgumentNullException(nameof(compressedData));

            using (var memoryStream = new MemoryStream(compressedData))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var decompressStream = GetDecompressionStream(memoryStream, compressionMethod))
                    {
                        await decompressStream.CopyToAsync(outStream);
                    }

                    string json = Encoding.UTF8.GetString(outStream.ToArray());

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
        }

        /// <summary>
        /// Создает поток декомпрессии на основе заданного метод сжатия.
        /// </summary>
        /// <param name="inputStream">Поток ввода для декомпрессии.</param>
        /// <param name="compressionMethod">Метод сжатия.</param>
        /// <returns>Поток декомпрессии.</returns>
        private Stream GetDecompressionStream(Stream inputStream,
            CompressionMethod compressionMethod)
        {
            return compressionMethod switch
            {
                CompressionMethod.GZip => new GZipStream(inputStream, CompressionMode.Decompress),
                CompressionMethod.Brotli => new BrotliStream(inputStream, CompressionMode.Decompress),
                CompressionMethod.DeflateStream => new DeflateStream(inputStream, CompressionMode.Decompress),
                _ => new GZipStream(inputStream, CompressionMode.Decompress)
            };
        }

        /// <summary>
        /// Создает поток сжатия на основе заданного метод сжатия.
        /// </summary>
        /// <param name="compressionMethod">Метод сжатия.</param>
        /// <param name="outputStream">Поток вывода для сжатого данных.</param>
        /// <param name="compressionLevel">Уровень сжатия.</param>
        /// <returns>Поток сжатия.</returns>
        private Stream GetCompressionStream(Stream outputStream,
            CompressionMethod compressionMethod,
            CompressionLevel compressionLevel) 
        {
            return compressionMethod switch
            {
                CompressionMethod.GZip => new GZipStream(outputStream, compressionLevel),
                CompressionMethod.Brotli => new BrotliStream(outputStream, compressionLevel),
                CompressionMethod.DeflateStream => new DeflateStream(outputStream, compressionLevel),
                _ => new GZipStream(outputStream, compressionLevel)
            };
        }
    }
}
