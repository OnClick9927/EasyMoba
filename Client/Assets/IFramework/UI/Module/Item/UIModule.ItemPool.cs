/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
namespace IFramework.UI
{
    public partial class UIModule
    {
        public class ItemPool : UIAsyncOperation,IDisposable
        {
            protected Queue<UIItem> pool => new Queue<UIItem>();
            public int count => pool.Count;
            public virtual UIItem Get()
            {
                UIItem val;
                if (pool.Count > 0)
                {
                    val = pool.Dequeue();
                }
                else
                {
                    val = CreateNew();
                    OnCreate(val);
                }

                OnGet(val);
                return val;
            }

            private void OnCreate(UIItem val)
            {
                
            }

            public void Set(object obj)
            {
                if (obj is UIItem)
                {
                    Set((UIItem)obj);
                }
            }

            public virtual bool Set(UIItem t)
            {
                if (!pool.Contains(t))
                {
                    if (OnSet(t))
                    {
                        pool.Enqueue(t);
                    }

                    return true;
                }

                return false;
            }
            public void Clear()
            {
                while (pool.Count > 0)
                {
                    var val = pool.Dequeue();
                    OnClear(val);
                    (val as IDisposable)?.Dispose();
                }
            }


            public void Clear(int count)
            {
                count = ((count <= pool.Count) ? (pool.Count - count) : 0);
                while (pool.Count > count)
                {
                    var t = pool.Dequeue();
                    OnClear(t);
                }
            }

            private UIModule module;

            public GameObject prefab
            {
                get
                {
                    return isDone ? op.value : null;
                }
            }
            public string path { get { return op.path; } }
            private LoadItemAsyncOperation op;
            public void SetPrefab(LoadItemAsyncOperation op)
            {
                this.op = op;
            }
            protected UIItem CreateNew()
            {
                return new UIItem(this);
            }
            protected void OnGet(UIItem t)
            {
            }
            protected bool OnSet(UIItem t)
            {
                var parent = module.GetLayerRectTransform(item_layer);
                t.gameObject.transform.SetParent(parent, false);
                return true;
            }
            protected void OnClear(UIItem t)
            {
                GameObject.Destroy(t.gameObject);
            }

            public void Dispose()
            {
                Clear();
            }

            public ItemPool(LoadItemAsyncOperation op, UIModule module)
            {
                this.op = op;
                this.module = module;
                Wait(op);
            }
            private async void Wait(LoadItemAsyncOperation op)
            {
                await op;
                base.Compelete();

            }
        }

    }


}
