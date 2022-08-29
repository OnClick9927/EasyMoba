/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-05-12
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace IFramework
{
    public static partial class IAwaterEx
    {
        public static IAwaiter GetAwaiter(this AsyncOperation target)
        {
            return new AsyncOperationAwaiter(target);
        }
        public static IAwaiter<UnityEngine.Object> GetAwaiter(this ResourceRequest target)
        {
            return new ResourceRequestAwaiter(target);
        }
        public struct ResourceRequestAwaiter : IAwaiter<UnityEngine.Object>, ICriticalNotifyCompletion
        {
            private ResourceRequest task;
            private Queue<Action> calls;
            public ResourceRequestAwaiter(ResourceRequest task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed(AsyncOperation obj)
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public UnityEngine.Object GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task.asset;
            }

            public void OnCompleted(Action continuation)
            {
                UnsafeOnCompleted(continuation);
            }

            public void UnsafeOnCompleted(Action continuation)
            {
                if (continuation == null)
                    throw new ArgumentNullException("continuation");

                calls.Enqueue(continuation);
            }
        }
        public struct AsyncOperationAwaiter : IAwaiter, ICriticalNotifyCompletion
        {
            private AsyncOperation task;
            private Queue<Action> calls;
            public AsyncOperationAwaiter(AsyncOperation task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed(AsyncOperation obj)
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public void GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
            }

            public void OnCompleted(Action continuation)
            {
                UnsafeOnCompleted(continuation);
            }

            public void UnsafeOnCompleted(Action continuation)
            {
                if (continuation == null)
                    throw new ArgumentNullException("continuation");

                calls.Enqueue(continuation);
            }
        }

    }
}