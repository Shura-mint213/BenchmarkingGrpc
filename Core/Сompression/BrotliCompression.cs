using Newtonsoft.Json;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Сompression
{
    internal class BrotliCompression : IDataCompression
    {
        public async Task<byte[]> CompressAsync(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            byte[] bytes = Encoding.UTF8.GetBytes(value);

            using (var memoryStream = new MemoryStream())
            {
                using (Stream gZipStream =
                    new BrotliStream(memoryStream, CompressionLevel.Optimal))
                {
                    await gZipStream.WriteAsync(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public async Task<T?> Decompress<T>(byte[] value)
        {
            if (value is null || value.Length == 0)
                throw new ArgumentNullException(nameof(value));

            using (var memoryStream = new MemoryStream(value))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var decompressStream =
                        new BrotliStream(memoryStream, CompressionMode.Decompress))
                    {
                        await decompressStream.CopyToAsync(outStream);
                    }

                    string json = Encoding.UTF8.GetString(outStream.ToArray());

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
        }
    }
}
