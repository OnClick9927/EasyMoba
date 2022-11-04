using System.Collections.Generic;
using System.Linq;

namespace IFramework.Net.Http
{
    public class HttpUri
    {
        public Dictionary<string, string> uriParams { get; private set; }

        private string uri = string.Empty;
        public HttpUri(string uri)
        {
            var s = uri.IndexOf('?');
            if (s < 0) return;

            string pString = uri.Substring(s + 1);
            var kvalues = pString.Split('&');

            uriParams = new Dictionary<string, string>(kvalues.Length);
            foreach (var value in kvalues)
            {
                var kv = value.Split('=');
                if (kv.Length <= 1) continue;

                uriParams.Add(kv[0], kv[1]);
            }
        }

        public HttpUri(string baseUri,Dictionary<string, string> keyValues)
        {
            this.uri = baseUri;
            this.uriParams = keyValues;
        }

        public string ToUriParamString()
        {
            var kvArray = uriParams.Select(x => x.Key + "=" + x.Value);

            return this.uri + "?" + string.Join("&", kvArray);
        }
    }
}
