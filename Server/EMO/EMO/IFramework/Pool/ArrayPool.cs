using System.Collections.Generic;

namespace IFramework
{
    /// <summary>
    /// ArrayPoolArg
    /// </summary>
    public struct ArrayPoolArg : IEventArgs
    {
        /// <summary>
        /// 长度
        /// </summary>
        public int length;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        public ArrayPoolArg(int length)
        {
            this.length = length;
        }
    }
    /// <summary>
    /// 数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayPool<T> : ObjectPool<T[]>
    {
        private Queue<int> _lengthqueue = new Queue<int>();
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        protected override T[] CreateNew(IEventArgs arg)
        {
            ArrayPoolArg len = (ArrayPoolArg)arg;
            return new T[len.length];
        }
        Queue<T[]> queue = new Queue<T[]>();

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public override T[] Get(IEventArgs arg = null)
        {
            ArrayPoolArg len = (ArrayPoolArg)arg;
            int length = len.length;
            lock (para)
            {
                T[] t;
                if (pool.Count > 0 && _lengthqueue.Contains(length))
                {
                    while (_lengthqueue.Peek() != length)
                    {
                        _lengthqueue.Dequeue();
                        queue.Enqueue(pool.Dequeue());
                    }
                    t = pool.Dequeue();
                    while (pool.Count != 0) queue.Enqueue(pool.Dequeue());
                    int _count = queue.Count;
                    for (int i = 0; i < _count; i++)
                    {
                        var tmp = queue.Dequeue();
                        int _len = tmp.Length;
                        _lengthqueue.Enqueue(_len);
                        pool.Enqueue(tmp);
                    }
                }
                else
                {
                    t = CreateNew(arg);
                    OnCreate(t, arg);
                }
                OnGet(t, arg);
                return t;
            }
        }

        /// <summary>
        /// 回收
        /// </summary>
        /// <param name="t"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public override bool Set(T[] t, IEventArgs arg = null)
        {
            lock (para)
            {
                if (!pool.Contains(t))
                {
                    if (OnSet(t, arg))
                    {
                        int _len = t.Length;
                        _lengthqueue.Enqueue(_len);
                        pool.Enqueue(t);
                    }
                    return true;
                }
                else
                {
                    Log.E("Set Err: Exist " + type);
                    return false;
                }
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();
            if (_lengthqueue != null)
            {
                _lengthqueue.Clear();
            }
        }
    }
}
