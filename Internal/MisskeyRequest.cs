using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Yekssim.Internal
{
    internal static class MisskeyRequest
    {
        internal static async Task<dynamic> HttpPost(string endpoint, Dictionary<string, string> parameters)
        {
            var client = new HttpClient();
            var requestUri = "https://api.misskey.xyz/" + endpoint;
            var response = await client.PostAsync(requestUri, new FormUrlEncodedContent(parameters));
            return JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
        }
    }
}
