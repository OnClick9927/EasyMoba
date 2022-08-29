using System;
using UnityEngine;

namespace IFramework.UI
{
    public interface IUIModule
    {
        Canvas canvas { get; }
        /// <summary>
        /// 层级
        /// </summary>
        /// <param name="config"></param>
        void SetLayerConfig(UILayerConfig config);
        /// <summary>
        /// 资源
        /// </summary>
        /// <param name="asset"></param>
        void SetAsset(UIAsset asset);
        /// <summary>
        /// 逻辑
        /// </summary>
        /// <param name="groups"></param>
        void SetGroups(IGroups groups);
        void CreateCanvas();

        void Hide(string name);
        void Show(string name);
        void Close(string name);

        UIItem GetItem(string path);
        void SetItem(string path, UIItem item);
        void SetItem(string path, GameObject go);
        void ClearUselessItems();
        void CloseAll();
    }
}