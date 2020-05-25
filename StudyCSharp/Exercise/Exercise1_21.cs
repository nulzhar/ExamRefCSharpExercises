using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudyCSharp.Exercise
{
    public class Exercise1_21 : IExercise
    {
        public int code() => 121;

        public void Execute()
        {
            Task<bool> t = Task.Run(async () =>
            {
                HttpClient httpClient = new HttpClient();
                string content = await httpClient
                    .GetStringAsync("http://www.microsoft.com")
                    .ConfigureAwait(true);
                using (FileStream sourceStream = new FileStream("temp.html",
                        FileMode.Create, FileAccess.Write, FileShare.None,
                        4096, useAsync: true))
                {
                    byte[] encodedText = Encoding.Unicode.GetBytes(content);
                    await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                        .ConfigureAwait(true);
                };
                return true;
            });

            t.Wait();
        }
    }
}
