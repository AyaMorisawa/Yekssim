using System.Collections.Generic;
using System.Threading.Tasks;
using Yekssim.Internal;

namespace Yekssim
{
    public class MisskeyAuth
    {
        private string applicationSecret;

        public MisskeyAuth(string applicationSecret)
        {
            this.applicationSecret = applicationSecret;
        }

        internal async Task<dynamic> RequestWithAppSecret(string endpoint)
        {
            return await this.RequestWithAppSecret(endpoint, new Dictionary<string, string> { });
        }

        internal async Task<dynamic> RequestWithAppSecret(string endpoint, Dictionary<string, string> parameters)
        {
            parameters.Add("app_secret", this.applicationSecret);
            return await MisskeyRequest.HttpPost(endpoint, parameters);
        }

        public async Task<MisskeySession> Authorize()
        {
            var response = await this.RequestWithAppSecret("auth/session/generate");
            string token = response.token.Value;
            return new MisskeySession(this, token);
        }

    }
}
