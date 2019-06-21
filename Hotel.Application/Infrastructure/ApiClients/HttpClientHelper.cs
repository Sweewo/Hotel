using System.Net.Http;
using System.Threading.Tasks;

namespace Hotel.Application.Infrastructure.ApiClients
{
    public class HttpClientHelper
    {
        public static Task<string> ObtainData(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = client.GetAsync(url).Result)
            using (HttpContent content = res.Content)
                return content.ReadAsStringAsync();
        }
    }
}
