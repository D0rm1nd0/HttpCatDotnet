using System;
using System.Threading.Tasks;

namespace HttpCat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpCat httpCat = new();
            await httpCat.DownloadAllHttpCodesAsync();
        }
    }
}
