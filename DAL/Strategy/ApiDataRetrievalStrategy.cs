using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoStrategy.Converters;
using System.Net.Http;

namespace RepoStrategy.Strategy
{
    public class ApiDataRetrievalStrategy<T> : IDataRetrievalStrategy<T>
    {
        private readonly HttpClient HttpClient;
        private readonly string Url;

        public ApiDataRetrievalStrategy(HttpClient httpClient, string url)
        {
            HttpClient = httpClient;
            Url = url;
        }

        public async Task<IEnumerable<T>> RetrieveData()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            IEnumerable<T> data = JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody, Converter.Settings);
            return data;
        }
    }
}
