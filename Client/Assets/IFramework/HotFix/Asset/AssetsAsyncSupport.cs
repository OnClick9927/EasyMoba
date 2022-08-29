/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using static IFramework.Hotfix.Asset.Assets;
using static IFramework.Hotfix.Asset.AssetsInternal;

namespace IFramework.Hotfix.Asset
{
    public static class AssetsAsyncSupport
    {
        public struct SceneAssetAwaiter : IAwaiter<SceneAsset>, ICriticalNotifyCompletion
        {
            private SceneAsset task;
            private Queue<Action> calls;
            public SceneAssetAwaiter(SceneAsset task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public SceneAsset GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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

        public struct AssetAwaiter : IAwaiter<Asset>, ICriticalNotifyCompletion
        {
            private Asset task;
            private Queue<Action> calls;
            public AssetAwaiter(Asset task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public Asset GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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
        public struct BundleAwaiter : IAwaiter<Bundle>, ICriticalNotifyCompletion
        {
            private Bundle task;
            private Queue<Action> calls;
            public BundleAwaiter(Bundle task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public Bundle GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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
        public struct AssetBundleRequestAwaiter : IAwaiter<AssetBundleRequest>, ICriticalNotifyCompletion
        {
            private AssetBundleRequest task;
            private Queue<Action> calls;
            public AssetBundleRequestAwaiter(AssetBundleRequest task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed(AsyncOperation op)
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public AssetBundleRequest GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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
        public struct AssetBundleCreateRequestAwaiter : IAwaiter<AssetBundleCreateRequest>, ICriticalNotifyCompletion
        {
            private AssetBundleCreateRequest task;
            private Queue<Action> calls;
            public AssetBundleCreateRequestAwaiter(AssetBundleCreateRequest task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed(AsyncOperation op)
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public AssetBundleCreateRequest GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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
        public struct CheckBundleVersionOperationAwaiter : IAwaiter<CheckBundleVersionOperation>, ICriticalNotifyCompletion
        {
            private CheckBundleVersionOperation task;
            private Queue<Action> calls;
            public CheckBundleVersionOperationAwaiter(CheckBundleVersionOperation task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public CheckBundleVersionOperation GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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
        public struct DownLoadBundleOperationAwaiter : IAwaiter<DownLoadBundleOperation>, ICriticalNotifyCompletion
        {
            private DownLoadBundleOperation task;
            private Queue<Action> calls;
            public DownLoadBundleOperationAwaiter(DownLoadBundleOperation task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }
            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }
            public bool IsCompleted => task.isDone;
            public DownLoadBundleOperation GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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
        public struct LoadManifestOperationAwaiter : IAwaiter<LoadManifestOperation>, ICriticalNotifyCompletion
        {
            private LoadManifestOperation task;
            private Queue<Action> calls;
            public LoadManifestOperationAwaiter(LoadManifestOperation task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public LoadManifestOperation GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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

        public struct AssetsGroupOperationAwaiter : IAwaiter<AssetsGroupOperation>, ICriticalNotifyCompletion
        {
            private AssetsGroupOperation task;
            private Queue<Action> calls;
            public AssetsGroupOperationAwaiter(AssetsGroupOperation task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public AssetsGroupOperation GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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

        public struct InstantiateObjectOperationAwaiter : IAwaiter<InstantiateObjectOperation>, ICriticalNotifyCompletion
        {
            private InstantiateObjectOperation task;
            private Queue<Action> calls;
            public InstantiateObjectOperationAwaiter(InstantiateObjectOperation task)
            {
                if (task == null) throw new ArgumentNullException("task");
                this.task = task;
                calls = new Queue<Action>();
                this.task.completed += Task_completed;
            }

            private void Task_completed()
            {
                while (calls.Count != 0)
                {
                    calls.Dequeue()?.Invoke();
                }
            }

            public bool IsCompleted => task.isDone;

            public InstantiateObjectOperation GetResult()
            {
                if (!IsCompleted)
                    throw new Exception("The task is not finished yet");
                return task;
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

        public static IAwaiter<CheckBundleVersionOperation> GetAwaiter(this CheckBundleVersionOperation target)
        {
            return new CheckBundleVersionOperationAwaiter(target);
        }
        public static IAwaiter<DownLoadBundleOperation> GetAwaiter(this DownLoadBundleOperation target)
        {
            return new DownLoadBundleOperationAwaiter(target);
        }
        public static IAwaiter<LoadManifestOperation> GetAwaiter(this LoadManifestOperation target)
        {
            return new LoadManifestOperationAwaiter(target);
        }
        public static IAwaiter<Asset> GetAwaiter(this Asset target)
        {
            return new AssetAwaiter(target);
        }
        public static IAwaiter<SceneAsset> GetAwaiter(this SceneAsset target)
        {
            return new SceneAssetAwaiter(target);
        }

        public static IAwaiter<Bundle> GetAwaiter(this Bundle target)
        {
            return new BundleAwaiter(target);
        }
        public static IAwaiter<AssetBundleRequest> GetAwaiter(this AssetBundleRequest target)
        {
            return new AssetBundleRequestAwaiter(target);
        }
        public static IAwaiter<AssetBundleCreateRequest> GetAwaiter(this AssetBundleCreateRequest target)
        {
            return new AssetBundleCreateRequestAwaiter(target);
        }
        public static IAwaiter<AssetsGroupOperation> GetAwaiter(this AssetsGroupOperation target)
        {
            return new AssetsGroupOperationAwaiter(target);
        }
        public static IAwaiter<InstantiateObjectOperation> GetAwaiter(this InstantiateObjectOperation target)
        {
            return new InstantiateObjectOperationAwaiter(target);
        }
    }
}
