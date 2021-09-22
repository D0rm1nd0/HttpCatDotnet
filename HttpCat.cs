using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpCat
{
    public class HttpCat
    {
        public void DownloadImage(string fileName)
        {
            string url = $"http://http.cat/{fileName}";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string pathWithFile = Path.Combine(path, @"Images\", fileName);
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(new Uri(url), pathWithFile);
                    Console.WriteLine($"{pathWithFile} baixado");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                // OR 
                //client.DownloadFileAsync(new Uri(url), path);
            }
        }

        public void DownloadAllHttpCodes()
        {
            for (int i = 99; i< 500; i++)
            {
                DownloadImage($"{i}.jpg");    
            }
        }

        public async Task<bool> DownloadImageAsync(string fileName)
        {
            string url = $"http://http.cat/{fileName}";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string pathWithFile = Path.Combine(path, @"Images\", fileName);
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }
            using (WebClient client = new WebClient())
            {
                try
                {
                    await client.DownloadFileTaskAsync(new Uri(url), pathWithFile);
                    Console.WriteLine($"{pathWithFile} baixado");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public async Task<bool> DownloadAllHttpCodesAsync()
        {
            var series = Enumerable.Range(100, 500);
            List<Task> listOfTasks = new();
            foreach(var i in series)
            {
                listOfTasks.Add(DownloadImageAsync($"{i}.jpg"));
            }
            await Task.WhenAll(listOfTasks);
            return true;
        }
    }
}
