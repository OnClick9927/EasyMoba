//using System;

//namespace IFramework.Net.KCP
//{
//    public class KcpClient
//    {
//        private Kcp _kcp = null;
//        private BufferQueue _buffer;
//        private UInt32 _time = 0;
//        public IKcpSocket socket;
//        private ISessionListener _listen;

//        public bool writeDelay;
//        public bool ackNoDelay;

//        public KcpClient(IKcpSocket client, ISessionListener listen)
//        {
//            _buffer = BufferQueue.Allocate(1024 * 32);
//            this.socket = client;
//            this._listen = listen;
//            client.onMessage += Socket_onMessage;
//        }

//        private void Socket_onMessage(byte[] buffer, int offset, int length)
//        {
//            var inputN = _kcp.Input(buffer, offset, length, true, ackNoDelay);
//            if (inputN < 0) return;
//            _buffer.Clear();
//            while (true)
//            {
//                var size = _kcp.PeekSize();
//                if (size <= 0) break;

//                _buffer.EnsureWritableBytes(size);

//                var n = _kcp.Recv(_buffer.buffer, _buffer.writer, size);
//                if (n > 0) _buffer.writer += n;
//            }

//            // 有数据待接收
//            if (_buffer.canRead > 0)
//            {
  
//                _listen.OnMessage(socket,_buffer.buffer, _buffer.reader, _buffer.canRead);
//                // 读完重置读写指针
//                if (_buffer.reader == _buffer.writer)
//                {
//                    _buffer.Clear();
//                }
//            }

//        }

//        public void Connect(string host, int port)
//        {
//            _kcp = new Kcp((uint)(new Random().Next(1, Int32.MaxValue)), socket);
//            _kcp.NoDelay(0, 30, 2, true);
//            _kcp.stream = true;
//            _buffer.Clear();
//            socket.Connect(host,port);
//        }

//        public int Send(byte[] data, int index, int length)
//        {
//            var waitsnd = _kcp.waitToSend;
//            if (waitsnd < _kcp.sendWindow && waitsnd < _kcp.RmtWnd)
//            {

//                var sendBytes = 0;
//                do
//                {
//                    var n = Math.Min((int)_kcp.Mss, length - sendBytes);
//                    _kcp.Send(data, index + sendBytes, n);
//                    sendBytes += n;
//                } while (sendBytes < length);

//                waitsnd = _kcp.waitToSend;
//                if (waitsnd >= _kcp.sendWindow || waitsnd >= _kcp.RmtWnd || !writeDelay)
//                {
//                    _kcp.Flush(false);
//                }

//                return length;
//            }

//            return 0;
//        }
//        public void Close()
//        {
//            _buffer.Clear();
//            socket.Close();
//        }
//        public void Update()
//        {
//            if (0 == _time || _kcp.time >= _time)
//            {
//                _kcp.Update();
//                _time = _kcp.Check();
//            }
//        }

//    }
//}
