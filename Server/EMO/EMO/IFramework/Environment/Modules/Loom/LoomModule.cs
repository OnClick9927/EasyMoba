using System;
using System.Collections.Generic;

namespace IFramework
{
    /// <summary>
    /// 线程反馈模块
    /// </summary>
    partial class LoomModule : UpdateModule
    {
        private Queue<DelayedTask> _delay;
        /// <summary>
        /// 在主线程跑一个方法
        /// </summary>
        /// <param name="action"></param>
        public void RunDelay(Action action)
        {
            if (action == null) return;
            lock (_delay)
            {
                _delay.Enqueue(new DelayedTask(action));
            }
        }

        protected override ModulePriority OnGetDefautPriority()
        {
            return ModulePriority.Loom;
        }
        Queue<DelayedTask> _tasks = new Queue<DelayedTask>();

        protected override void OnUpdate()
        {
            int count = 0;
            lock (_delay)
            {
                count = _delay.Count;
                if (count <= 0) return;
                for (int i = 0; i < count; i++)
                {
                    _tasks.Enqueue(_delay.Dequeue());
                }
            }
            for (int i = 0; i < count; i++)
            {
                var _task = _tasks.Dequeue();
                _task.action();
            }
        }
        protected override void OnDispose()
        {
            _delay.Clear();
            _delay = null;
        }
        protected override void Awake()
        {
            _delay = new Queue<DelayedTask>();
        }
    }
}
