using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace IFramework.Net
{
    internal class SocketBufferManager
    {
        int wTotalSize=0;
        int wCurIndex=0;
        int wBlockSize = 2048;
        LockParam lockParam = new LockParam();
        byte[] wBuffer=null;
        Queue<int> freeBufferIndexPool=null;

        /// <summary>
        /// 块缓冲区大小
        /// </summary>
        public int BlockSize { get { return wBlockSize; } }

        /// <summary>
        /// 缓冲区管理构造
        /// </summary>
        /// <param name="maxCounts"></param>
        /// <param name="blockSize"></param>
        public SocketBufferManager(int maxCounts, int blockSize)
        {
            if (blockSize < 4) blockSize = 4;
             
            this.wBlockSize = blockSize;
            this.wCurIndex = 0;
            wTotalSize = maxCounts * blockSize;
            wBuffer = new byte[wTotalSize];
            freeBufferIndexPool = new Queue<int>(maxCounts);
        }

        public void Clear()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                freeBufferIndexPool.Clear();
            }
        }

        /// <summary>
        /// 设置缓冲区
        /// </summary>
        /// <param name="agrs"></param>
        /// <returns></returns>
        public bool SetBuffer(SocketAsyncEventArgs agrs)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                if (freeBufferIndexPool.Count > 0)
                {
                    agrs.SetBuffer(this.wBuffer, this.freeBufferIndexPool.Dequeue(), wBlockSize);
                }
                else
                {
                    if ((wTotalSize - wBlockSize) < wCurIndex) return false;

                    agrs.SetBuffer(this.wBuffer, this.wCurIndex, this.wBlockSize);

                    this.wCurIndex += this.wBlockSize;
                }
                return true;
            }
        }

        /// <summary>
        /// 写入缓冲区
        /// </summary>
        /// <param name="agrs"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public bool WriteBuffer(SocketAsyncEventArgs agrs, byte[] buffer, int offset, int cnt)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                //超出缓冲区则不写入
                if (agrs.Offset + cnt > this.wBuffer.Length)
                {
                    return false;
                }

                //超出块缓冲区则不写入
                if (cnt > wBlockSize) return false;

                Buffer.BlockCopy(buffer, offset, this.wBuffer, agrs.Offset, cnt);

                agrs.SetBuffer(this.wBuffer, agrs.Offset, cnt);

                return true;
            }
        }

        /// <summary>
        /// 释放缓冲区
        /// </summary>
        /// <param name="args"></param>
        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                this.freeBufferIndexPool.Enqueue(args.Offset);
                args.SetBuffer(null, 0, 0);
            }
        }

        /// <summary>
        /// 自动按发送缓冲区的块大小分多次包
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public ArraySegment<byte>[] BufferToSegments(byte[] buffer, int offset, int size)
        {
            if (size <= wBlockSize)
                return new ArraySegment<byte>[] { new ArraySegment<byte>(buffer, offset, size) };

            int bSize = wBlockSize;
            int bCnt = size / wBlockSize;
            int bOffset = 0;
            bool isRem = false;
            if (size % wBlockSize != 0)
            {
                isRem = true;
                bCnt += 1;
            }

            ArraySegment<byte>[] segItems = new ArraySegment<byte>[bCnt];
            for (int i = 0; i < bCnt; ++i)
            {
                bOffset = i * wBlockSize;

                if (i == (bCnt - 1) && isRem)
                {
                    bSize = size - bOffset;
                }
                segItems[i] = new ArraySegment<byte>(buffer, offset + bOffset, bSize);
            }
            return segItems;
        }
    }
}