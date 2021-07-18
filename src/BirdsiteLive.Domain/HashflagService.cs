using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BirdsiteLive.Domain
{
    public interface IHashflagService
    {
        Task ExecuteAsync();
        Dictionary<string, string> Hashflags { get; }
    }

    public class HashflagService : IHashflagService
    {
        private DateTime lastFetch = default(DateTime);

        public Dictionary<string, string> Hashflags { get; private set; }

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public HashflagService(IHttpClientFactory httpClientFactory/* , ILogger logger */)
        {
            _httpClientFactory = httpClientFactory;
            /* _logger = logger; */
        }

        public async Task ExecuteAsync()
        {
            if(DateTime.Now - lastFetch >= new TimeSpan(1, 0, 0))
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    var result = await client.GetAsync("https://hashflags.blob.core.windows.net/json/activeHashflags");
                    var content = await result.Content.ReadAsStringAsync();

                    Hashflags = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                } catch(Exception e)
                {
                    Console.WriteLine(e);
                    /* _logger.LogCritical("Error fetching hashflags: {exception}", e); */
                }
            }
        }
    }
}
