using Core.Сompression;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using static System.Console;

namespace Client
{
    internal class TestCompression
    {
        internal async Task StartTest()
        {

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
            var timer = new Stopwatch();

            timer.Restart();
            var bytesD = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.DeflateStream);
            timer.Stop();
            WriteLine($"DeflateStream compress: {bytesD.Length} byte  time: " +
                $"{timer.Elapsed.Milliseconds:000}.{timer.Elapsed.Microseconds:0000}.{timer.Elapsed.Nanoseconds:00000}");

            timer.Restart();
            var bytesB = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.Brotli);
            timer.Stop();
            WriteLine($"Brotli compress: {bytesB.Length} byte time: {timer.Elapsed.Milliseconds:000}.{timer.Elapsed.Microseconds:0000}.{timer.Elapsed.Nanoseconds:00000}");
            
            timer.Restart();
            var bytesGz = await dataCompression.CompressAsync(strings, Shared.Enums.CompressionMethod.GZip);
            timer.Stop();
            WriteLine($"GZip compress: {bytesGz.Length} byte  time: {timer.Elapsed.Milliseconds:000}.{timer.Elapsed.Microseconds:0000}.{timer.Elapsed.Nanoseconds:00000}");


            timer.Restart();
            var result = await dataCompression.DecompressAsync<List<string>>(bytesB, Shared.Enums.CompressionMethod.Brotli);
            timer.Stop();
            WriteLine($"Brotli decompress {JsonConvert.SerializeObject(result).ToArray().Length} byte  time: {timer.Elapsed.Milliseconds:000}.{timer.Elapsed.Microseconds:0000}.{timer.Elapsed.Nanoseconds:00000}");

            timer.Restart();
            var resultG = await dataCompression.DecompressAsync<List<string>>(bytesGz, Shared.Enums.CompressionMethod.GZip);
            timer.Stop();
            WriteLine(JsonConvert.SerializeObject(resultG).ToArray().Length);
            WriteLine($"GZip decompress {JsonConvert.SerializeObject(resultG).ToArray().Length} byte  time: {timer.Elapsed.Milliseconds:000}.{timer.Elapsed.Microseconds:0000}.{timer.Elapsed.Nanoseconds:00000}");

            timer.Restart();
            var resultD = await dataCompression.DecompressAsync<List<string>>(bytesD, Shared.Enums.CompressionMethod.DeflateStream);
            timer.Stop();
            WriteLine(JsonConvert.SerializeObject(resultD).ToArray().Length);
            WriteLine($"DeflateStream decompress {JsonConvert.SerializeObject(resultD).ToArray().Length} byte time: {timer.Elapsed.Milliseconds:000}.{timer.Elapsed.Microseconds:0000}.{timer.Elapsed.Nanoseconds:00000}");
        }        
    }
}
