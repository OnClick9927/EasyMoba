/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework;
using IFramework.Hotfix.Asset;
using IFramework.Hotfix.Lua;
using IFramework.UI;
using UnityEngine;

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
        public override void ReleaseItemAsset(string releaseAsset)
        {

        }
        public override UIPanel LoadPanel(string name)
        {
            return null;
        }
        private async void Load(LoadPanelAsyncOperation op, string path)
        {
            var asset = await Assets.LoadAssetAsync(path);
            var panel = asset.GetAsset<UIPanel>();
            op.SetValue(panel);
        }
        public override bool LoadPanelAsync(string name, LoadPanelAsyncOperation op)
        {
            var find = collect.datas.Find(x => x.name == op.panelName);
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
            }
            else
            {
                Debug.LogError("重新生成路径文件");
            }
            return false;
        }


        public override void DestoryPanel(GameObject gameObject)
        {
            var find = collect.datas.Find(x => x.name == gameObject.name);
            if (find != null)
            {
                Assets.Destory(gameObject);
            }
            else
            {
                base.DestoryPanel(gameObject);
            }
        }
        public override Canvas GetCanvas()
        {
            return canvas;
        }
    }
}
