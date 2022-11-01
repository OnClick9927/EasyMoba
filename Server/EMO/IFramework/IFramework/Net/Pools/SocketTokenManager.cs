using System;
using System.Collections.Generic;
using System.Threading;

namespace IFramework.Net
{
    internal class SocketTokenManager<T>
    {
        private Queue<T> collection = null;
        private LockParam lockParam = new LockParam();
        private int capacity = 4;

        public int Count
        {
            get { return collection.Count; }
        }


        public int Capacity { get { return capacity; } }

        public SocketTokenManager(int capacity = 32)
        {
            this.capacity = capacity;
            collection = new Queue<T>(capacity);
        }


        public T Get()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                if (collection.Count > 0)
                    return collection.Dequeue();
                else return default(T);
            }
        }


        public void Set(T item)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                collection.Enqueue(item);
            }
        }


        public void Clear()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                collection.Clear();
            }
        }

        public void ClearToCloseToken()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                while (collection.Count > 0)
                {
                    var token = collection.Dequeue() as SocketToken;
                    if (token != null) token.Close();
                }
            }
        }

        public void ClearToCloseArgs()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                while (collection.Count > 0)
                {
                    var token = collection.Dequeue() as System.Net.Sockets.SocketAsyncEventArgs;
                    if (token != null)
                    {
                        token.Dispose();
                    }
                }
            }
        }

        public T GetEmptyWait(Func<int, bool> fun, bool isWaitingFor = false)
        {
            int retry = 1;

            while (true)
            {
                var tArgs = Get();
                if (tArgs != null) return tArgs;
                if (isWaitingFor == false)
                {
                    if (retry > 16) break;
                    ++retry;
                }

                var isContinue = fun(retry);
                if (isContinue == false) break;

                Thread.Sleep(1000 * retry);
            }
            return default(T);
        }
    }
}