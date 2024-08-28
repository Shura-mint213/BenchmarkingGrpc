using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum CompressionMethod
    {
        GZip = 0,
        Brotli = 1,
        DeflateStream = 2,
    }
}
