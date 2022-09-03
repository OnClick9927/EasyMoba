namespace IFramework.Net.WebSocket
{
    internal class AcceptInfo : BaseInfo
    {
        /// <summary>
        /// 接入访问验证码
        /// </summary>
        public string SecWebSocketAccept { get; set; }
        /// <summary>
        /// 客户端来源
        /// </summary>
        public string SecWebSocketLocation { get; set; }
        /// <summary>
        /// 服务端来源
        /// </summary>
        public string SecWebSocketOrigin { get; set; }


        public override string ToString()
        {
            if (string.IsNullOrEmpty(HttpProto))
                HttpProto = "HTTP/1.1 101 Switching Protocols";

            return string.Format("{0}{1}{2}{3}",
                HttpProto + NewLine,
                "Connection" + SplitChars + Connection + NewLine,
                "Upgrade" + SplitChars + Upgrade + NewLine,
                 "Sec-WebSocket-Accept" + SplitChars + SecWebSocketAccept + NewLine + NewLine//很重要，需要两个newline
                );
        }

        public bool IsHandShaked()
        {
            return string.IsNullOrEmpty(SecWebSocketAccept) == false;
        }
    }
}
