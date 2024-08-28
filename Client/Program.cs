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

WriteLine(JsonConvert.SerializeObject(strings).ToArray().Length);

var bytesB = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.Brotli);

WriteLine(bytesB.Length);
var bytesGz = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.GZip);

WriteLine(bytesGz.Length);
var result = await dataCompression.Decompress<List<string>>(bytesB, Shared.Enums.CompressionMethod.Brotli);
WriteLine(JsonConvert.SerializeObject(result).ToArray().Length);

var resultG = await dataCompression.Decompress<List<string>>(bytesGz, Shared.Enums.CompressionMethod.GZip);
WriteLine(JsonConvert.SerializeObject(resultG).ToArray().Length);

foreach (var item in result)
{
    WriteLine(item); 
}