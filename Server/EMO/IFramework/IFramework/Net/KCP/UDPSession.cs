//using System;
//using System.Net;
//using System.Net.Sockets;

//namespace IFramework.Net.KCP
//{
//    class UDPSession 
//    {
//        private Socket mSocket = null;
//        private KCP mKCP = null;

//        private ByteBuffer mRecvBuffer = ByteBuffer.Allocate(1024 * 32);
//        private UInt32 mNextUpdateTime = 0;

//        public bool IsConnected { get { return mSocket != null && mSocket.Connected; } }
//        public bool WriteDelay { get; set; }
//        public bool AckNoDelay { get; set; }

//        public IPEndPoint RemoteAddress { get; private set; }
//        public IPEndPoint LocalAddress { get; private set; }

//        public void Connect(string host, int port)
//        {
//            IPHostEntry hostEntry = Dns.GetHostEntry(host);
//            if (hostEntry.AddressList.Length == 0)
//            {
//                throw new Exception("Unable to resolve host: " + host);
//            }
//            var endpoint = hostEntry.AddressList[0];
//            mSocket = new Socket(endpoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
//            mSocket.Connect(endpoint, port);
//            RemoteAddress = (IPEndPoint)mSocket.RemoteEndPoint;
//            LocalAddress = (IPEndPoint)mSocket.LocalEndPoint;
//            mKCP = new KCP((uint)(new Random().Next(1, Int32.MaxValue)), null);
//            // normal:  0, 40, 2, 1
//            // fast:    0, 30, 2, 1
//            // fast2:   1, 20, 2, 1
//            // fast3:   1, 10, 2, 1
//            mKCP.NoDelay(0, 30, 2, true);
//            mKCP.stream=true;
//            mRecvBuffer.Clear();
//        }

//        public void Close()
//        {
//            if (mSocket != null)
//            {
//                mSocket.Close();
//                mSocket = null;
//                mRecvBuffer.Clear();
//            }
//        }



//        public int Send(byte[] data, int index, int length)
//        {
//            if (mSocket == null)
//                return -1;

//            var waitsnd = mKCP.waitToSend;
//            if (waitsnd < mKCP.sendWindow && waitsnd < mKCP.RmtWnd)
//            {

//                var sendBytes = 0;
//                do
//                {
//                    var n = Math.Min((int)mKCP.Mss, length - sendBytes);
//                    mKCP.Send(data, index + sendBytes, n);
//                    sendBytes += n;
//                } while (sendBytes < length);

//                waitsnd = mKCP.waitToSend;
//                if (waitsnd >= mKCP.sendWindow || waitsnd >= mKCP.RmtWnd || !WriteDelay)
//                {
//                    mKCP.Flush(false);
//                }

//                return length;
//            }

//            return 0;
//        }

//        public int Recv(byte[] data, int index, int length)
//        {
//            // 上次剩下的部分
//            if (mRecvBuffer.canRead > 0)
//            {
//                var recvBytes = Math.Min(mRecvBuffer.canRead, length);
//                Buffer.BlockCopy(mRecvBuffer.buffer, mRecvBuffer.reader, data, index, recvBytes);
//                mRecvBuffer.reader += recvBytes;
//                // 读完重置读写指针
//                if (mRecvBuffer.reader == mRecvBuffer.writer)
//                {
//                    mRecvBuffer.Clear();
//                }
//                return recvBytes;
//            }

//            if (mSocket == null)
//                return -1;

//            if (!mSocket.Poll(0, SelectMode.SelectRead))
//            {
//                return 0;
//            }

//            var rn = 0;
//            try
//            {
//                rn = mSocket.Receive(mRecvBuffer.buffer, mRecvBuffer.writer, mRecvBuffer.canWrite, SocketFlags.None);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                rn = -1;
//            }

//            if (rn <= 0)
//            {
//                return rn;
//            }
//            mRecvBuffer.writer += rn;

//            var inputN = mKCP.Input(mRecvBuffer.buffer, mRecvBuffer.reader, mRecvBuffer.canRead, true, AckNoDelay);
//            if (inputN < 0)
//            {
//                mRecvBuffer.Clear();
//                return inputN;
//            }
//            mRecvBuffer.Clear();

//            // 读完所有完整的消息
//            for (; ; )
//            {
//                var size = mKCP.PeekSize();
//                if (size <= 0) break;

//                mRecvBuffer.EnsureWritableBytes(size);

//                var n = mKCP.Recv(mRecvBuffer.buffer, mRecvBuffer.writer, size);
//                if (n > 0) mRecvBuffer.writer += n;
//            }

//            // 有数据待接收
//            if (mRecvBuffer.canRead > 0)
//            {
//                return Recv(data, index, length);
//            }

//            return 0;
//        }

//        public void Update()
//        {
//            if (mSocket == null)
//                return;

//            if (0 == mNextUpdateTime || mKCP.time >= mNextUpdateTime)
//            {
//                mKCP.Update();
//                mNextUpdateTime = mKCP.Check();
//            }
//        }

//        public void Send(byte[] buffer, int length)
//        {
//            if (mSocket != null)
//            {
//                mSocket.Send(buffer, length, SocketFlags.None);
//            }
//        }
//    }

//}
