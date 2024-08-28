using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO.Pipes;

namespace Core.Сompression
{
    internal class GZipCompression : IDataCompression
    {
        /// <inheritdoc/>
        public async Task<byte[]> CompressAsync(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            byte[] bytes = Encoding.UTF8.GetBytes(value);

            using (var memoryStream = new MemoryStream())
            {
                using (var gZipStream =
                    new GZipStream(memoryStream, CompressionLevel.Optimal))
                {
                    await gZipStream.WriteAsync(bytes, 0, bytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        /// <inheritdoc/>
        public async Task<T?> Decompress<T>(byte[] value)
        {
            if (value is null || value.Length == 0)
                throw new ArgumentNullException(nameof(value));

            using (var memoryStream = new MemoryStream(value))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var decompressStream = 
                        new GZipStream(memoryStream, CompressionMode.Decompress))
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
