using System;

namespace IFramework.Net.WebSocket
{
    public class WSConnectionItem
    {
        public WSConnectionItem()
        { }

        public WSConnectionItem(string wsUrl)
        {
            string[] urlParams = wsUrl.Split(':');

            if (urlParams.Length < 3)
                throw new Exception("wsUrl is error format.for example as ws://localhost:80");

            Proto = urlParams[0];
            Domain = urlParams[1].Replace("//", "");
            Port = int.Parse(urlParams[2]);

            Host = Domain + ":" + Port;
        }

        public string Proto { get; set; } = "ws";

        public string Domain { get; set; }

        public int Port { get; set; } = 65531;

        public string Host { get; }
    }
}
