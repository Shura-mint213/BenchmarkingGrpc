using Core.Сompression;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using static System.Console;



DataCompression dataCompression = new DataCompression();

List<string> strings = new List<string>()
{
    "new",
    "test 1",
    "test 2",
    "test 3",
    "test 4",
    "test 5",
    "test 6",
    "test 7"
};

WriteLine($"start data: {JsonConvert.SerializeObject(strings).ToArray().Length} byte");

var bytesB = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.Brotli);
WriteLine($"Brotli compress: {bytesB.Length} byte");

var bytesGz = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.GZip);
WriteLine($"GZip compress: {bytesGz.Length} byte");

var bytesD = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.DeflateStream);
WriteLine($"DeflateStream compress: {bytesD.Length} byte");

var result = await dataCompression.DecompressAsync<List<string>>(bytesB, Shared.Enums.CompressionMethod.Brotli);
WriteLine($"Brotli decompress {JsonConvert.SerializeObject(result).ToArray().Length} byte");

var resultG = await dataCompression.DecompressAsync<List<string>>(bytesGz, Shared.Enums.CompressionMethod.GZip);
WriteLine(JsonConvert.SerializeObject(resultG).ToArray().Length);
WriteLine($"GZip decompress {JsonConvert.SerializeObject(resultG).ToArray().Length} byte");

var resultD = await dataCompression.DecompressAsync<List<string>>(bytesD, Shared.Enums.CompressionMethod.DeflateStream);
WriteLine(JsonConvert.SerializeObject(resultD).ToArray().Length);
WriteLine($"DeflateStream decompress {JsonConvert.SerializeObject(resultD).ToArray().Length} byte");
