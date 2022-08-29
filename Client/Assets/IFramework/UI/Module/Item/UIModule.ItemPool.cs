/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using UnityEngine;
namespace IFramework.UI
{
    public partial class UIModule
    {
        public class ItemPool : ObjectPool<UIItem>
        {
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
            public bool isDone { get { return op.isDone; } }
            public void SetPrefab(LoadItemAsyncOperation op)
            {
                this.op = op;
            }
            protected override UIItem CreateNew(IEventArgs arg)
            {
                return new UIItem(this);
            }
            protected override void OnGet(UIItem t, IEventArgs arg)
            {
            }
            protected override bool OnSet(UIItem t, IEventArgs arg)
            {
                var parent = module.GetLayerParent(UILayer.Items);
                t.gameObject.transform.SetParent(parent, false);
                return base.OnSet(t, arg);
            }
            protected override void OnClear(UIItem t, IEventArgs arg)
            {
                GameObject.Destroy(t.gameObject);
            }
          
            public ItemPool(LoadItemAsyncOperation op, UIModule module)
            {
                this.op = op;
                this.module = module;

            }
        }

    }


}
