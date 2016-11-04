using System.Collections.Generic;
using System.Threading.Tasks;
using Yekssim.Internal;

namespace Yekssim
{
    public class MisskeyToken
    {
        public string UserKey;

        public MisskeyToken(string userKey) {
            this.UserKey = userKey;
        }

        public async Task<dynamic> RequestWithUserKey(string endpoint)
        {
            return await this.Request(endpoint, new Dictionary<string, string> { });
        }

        public async Task<dynamic> Request(string endpoint, Dictionary<string, string> parameters)
        {
            parameters.Add("_userkey", this.UserKey);
            return await MisskeyRequest.HttpPost(endpoint, parameters);
        }
    }
}
