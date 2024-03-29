﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework;
using IFramework.Hotfix.Lua;
using IFramework.UI;
using UnityEngine;
using WooAsset;

namespace EasyMoba
{
    public class NormalUIAsset : UIAsset
    {
        private PanelPathCollect collect;
        private Canvas canvas;
        public NormalUIAsset(PanelPathCollect collect, Canvas canvas)
        {
            this.collect = collect;
            this.canvas = canvas;
        }
        public override UILayer GetPanelLayer(string path)
        {
            var find = collect.datas.Find(x => x.path == path);
            return find != null ? find.layer : base.GetPanelLayer(path);
        }
        public override int GetPanelLayerOrder(string path)
        {
            var find = collect.datas.Find(x => x.path == path);
            return find != null ? find.order : base.GetPanelLayerOrder(path);
        }
        private async void LoadItem(LoadItemAsyncOperation op, string path)
        {
            var asset = await Assets.LoadAssetAsync(path);
            var panel = asset.GetAsset<GameObject>();
            op.SetValue(panel);
        }

        public override bool LoadItemAsync(string path, LoadItemAsyncOperation op)
        {
            LoadItem(op, path);
            return true;
        }
        public override void ReleaseItemAsset(GameObject releaseAsset)
        {
            Assets.Destroy(releaseAsset);

        }
        public override UIPanel LoadPanel(string name)
        {
            return null;
        }
        private async void Load(LoadPanelAsyncOperation op, string path)
        {
            var asset = await Assets.LoadAssetAsync(path);
            var panel = asset.GetAsset<GameObject>().GetComponent<UIPanel>();
            op.SetValue(panel);
        }
        public override bool LoadPanelAsync(string name, LoadPanelAsyncOperation op)
        {
            var find = collect.datas.Find(x => x.path == op.path);
            if (find != null)
            {
                if (find.isResourcePath)
                {
                    op.SetValue(Resources.Load<UIPanel>(find.path));
                }
                else
                {
                    Load(op, find.path);
                }
                return true;
            }
            Debug.LogError("重新生成路径文件");
            return false;
        }


        public override void DestoryPanel(GameObject gameObject)
        {
            GameObject.Destroy(gameObject);
        }
        public override Canvas GetCanvas()
        {
            return canvas;
        }
    }
}
