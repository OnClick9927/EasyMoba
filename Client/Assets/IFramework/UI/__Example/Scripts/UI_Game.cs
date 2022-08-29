/*********************************************************************************
 *Author:         爱吃水蜜桃
 *Version:        1.0
 *UnityVersion:   2018.4.24f1
 *Date:           2021-06-27
 *Description:    Description
 *History:        2021-06-27--
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using IFramework;
using IFramework.UI.MVVM;
using IFramework.UI.MVC;
using UnityEngine;
namespace IFramework.UI.Example
{
    public class UIAsset : UI.UIAsset
    {
        public override bool LoadItemAsync(string path, LoadItemAsyncOperation op)
        {
            return true;
        }

        public override UIPanel LoadPanel(string name)
        {
            return null;

        }

        public override bool LoadPanelAsync(string name, LoadPanelAsyncOperation op)
        {
            LoadAsync(op);
            return true;
        }
        private async void LoadAsync(LoadPanelAsyncOperation op)
        {
            await System.Threading.Tasks.Task.Delay(1000);
            var ui = Resources.Load<GameObject>(op.panelName).GetComponent<UIPanel>();
            op.SetValue(ui);
        }

        public override void ReleaseItemAsset(string releaseAsset)
        {
            throw new NotImplementedException();
        }
    }
    public class UI_Game : Game
    {
        public UIModule module;
        public override void Init()
        {
            module = modules.GetModule<UIModule>("Example");
            module.SetAsset(new UIAsset());
            module.SetGroups(new MixedGroups(new IGroups[] { new MvcGroups(new Dictionary<string, Type>[]{
            MVCMap.map
            }), new MvvmGroups(new Dictionary<string, Tuple<Type, Type, Type>>[] {
            UIMap_MVVM.map
            }) }));
            module.CreateCanvas();
        }


        public override void Startup()
        {
            module.Show(MVCMap.Panel02);
            module.Show(UIMap_MVVM.Panel01);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                module.Show(UIMap_MVVM.Panel01);
                module.Hide(MVCMap.Panel02);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                module.Hide(UIMap_MVVM.Panel01);
                module.Show(MVCMap.Panel02);
            }
        }

        public void ReleaseItemAsset(string releaseAsset)
        {
        }

        public void DestoryPanel(GameObject call)
        {
        }
    }
}
