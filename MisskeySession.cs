using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Yekssim
{
    public class MisskeySession
    {
        private string token;
        private MisskeyAuth auth;
        public string AuthPageUri;

        internal MisskeySession(MisskeyAuth auth, string token)
        {
            this.token = token;
            this.auth = auth;
            this.AuthPageUri = "http://auth.misskey.xyz/" + token;
        }

        public void OpenAuthPageInDefaultBrowser()
        {
            Process.Start(this.AuthPageUri);
        }

        public async Task<MisskeyToken> GetToken()
        {
            var response = await auth.RequestWithAppSecret("auth/session/userkey", new Dictionary<string, string> {
                { "token", this.token }
            });
            string userKey = response.userkey.Value;
            return new MisskeyToken(userKey);
        }
    }
}
