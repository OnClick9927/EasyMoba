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
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
namespace IFramework.UI
{
    public partial class UIModule : UpdateModule, IUIModule
    {
        public Canvas canvas { get; private set; }
        private IGroups _groups;
        private UIAsset _asset;
        private Dictionary<UILayer, List<UIPanel>> _panelOrders;
        private Dictionary<UILayer, RectTransform> _layers;
        private Dictionary<string, UILayerData> _layerSettings;
        private Queue<LoadPanelAsyncOperation> asyncLoadQueue;
        private ItemsPool _itemPool;
        private List<UIPanel> _orderHelp = new List<UIPanel>();
        private Dictionary<string, UIPanel> panels = new Dictionary<string, UIPanel>();
        protected override void Awake()
        {
            _panelOrders = new Dictionary<UILayer, List<UIPanel>>();
            _layerSettings = new Dictionary<string, UILayerData>();
            _layers = new Dictionary<UILayer, RectTransform>();
            asyncLoadQueue = new Queue<LoadPanelAsyncOperation>();
            _itemPool = new ItemsPool(this);
        }


        protected override void OnDispose()
        {
            if (_groups != null)
                _groups.Dispose();
            asyncLoadQueue.Clear();
            _layers.Clear();
            if (canvas != null)
                GameObject.Destroy(canvas.gameObject);
            _itemPool.Clear();
        }
        protected override void OnUpdate()
        {
            CheckAsyncLoad();
        }


        private RectTransform CreateLayer(string name)
        {
            GameObject go = new GameObject(name);
            RectTransform rect = go.AddComponent<RectTransform>();
            rect.SetParent(canvas.transform);
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.localPosition = Vector3.zero;
            rect.sizeDelta = Vector3.zero;
            rect.LocalIdentity();
            return rect;
        }
        private void CreateLayers()
        {
            var names = Enum.GetValues(typeof(UILayer));
            foreach (UILayer item in names)
            {
                var rect = CreateLayer(item.ToString());
                _layers.Add(item, rect);
            }
            var items = GetLayerParent(UILayer.Items);
            CanvasGroup group = items.gameObject.AddComponent<CanvasGroup>();
            group.alpha = 0f;
            group.interactable = false;
        }
        private RectTransform GetLayerParent(UILayer layer)
        {
            return _layers[layer];
        }
        private void SetOrder(UIPanel panel)
        {
            UILayer layer = GetPanelLayer(panel);
            int order = GetPanelLayerOrder(panel);
            if (!_panelOrders.ContainsKey(layer))
                _panelOrders.Add(layer, new List<UIPanel>());
            var list = _panelOrders[layer];
            _orderHelp.Clear();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                UIPanel _tmp = list[i];
                _orderHelp.Add(_tmp);
            }
            if (_orderHelp.Contains(panel)) return;
            _orderHelp.Sort((a, b) => { return GetPanelLayerOrder(a) - GetPanelLayerOrder(b); });
            int sbindex = 0;
            bool bigExist = false;
            for (int i = 0; i < _orderHelp.Count; i++)
            {
                if (GetPanelLayerOrder(_orderHelp[i]) > order)
                {
                    sbindex = _orderHelp[i].transform.GetSiblingIndex();
                    bigExist = true;
                    break;
                }
            }
            if (bigExist)
            {
                panel.transform.SetSiblingIndex(sbindex);
            }
            list.Add(panel);
        }
        private void DestroyPanel(UIPanel panel)
        {
            _panelOrders[GetPanelLayer(panel)].Remove(panel);
            _asset.DestoryPanel(panel.gameObject);
        }
        private UILayer GetPanelLayer(UIPanel panel)
        {
            if (_layerSettings.ContainsKey(panel.name))
            {
                return _layerSettings[panel.name].layer;
            }
            return UILayer.Common;
        }
        private int GetPanelLayerOrder(UIPanel panel)
        {
            if (_layerSettings.ContainsKey(panel.name))
            {
                return _layerSettings[panel.name].order;
            }
            return 0;
        }







        private void UILoadComplete(UIPanel ui, string name, Action<UIPanel> callback)
        {
            if (ui != null)
            {
                ui = UnityEngine.Object.Instantiate(ui, GetLayerParent(GetPanelLayer(ui)));
                ui.name = name;
                SetOrder(ui);
                panels.Add(name, ui);
                _groups.Subscribe(ui);
                _groups.OnLoad(name);
            }
            callback?.Invoke(ui);
        }
        private void CheckAsyncLoad()
        {
            if (asyncLoadQueue.Count == 0) return;
            while (asyncLoadQueue.Count > 0 && asyncLoadQueue.Peek().isDone)
            {
                LoadPanelAsyncOperation op = asyncLoadQueue.Dequeue();
                UILoadComplete(op.value, op.panelName, op.callback);
                op.SetToDefault();
                op.GlobalRecyle();
            }
        }
        private void OnShowCallBack(UIPanel panel)
        {
            if (panel == null) return;
            string name = panel.name;
            this._groups.OnShow(name);
        }
        private UIPanel Find(string name)
        {
            UIPanel ui;
            panels.TryGetValue(name, out ui);
            return ui;
        }
        private void Load(string name, Action<UIPanel> callback)
        {
            if (_groups == null)
                throw new Exception("Please Set IGroups First");
            if (_asset == null)
                throw new Exception("Please Set UILoader First");
            var result = _asset.LoadPanel(name);
            if (result != null)
            {
                UILoadComplete(result, name, callback);
            }
            else
            {
                LoadPanelAsyncOperation op = Framework.GlobalAllocate<LoadPanelAsyncOperation>();
                op.callback = callback;
                op.panelName = name;
                if (_asset.LoadPanelAsync(name, op))
                {
                    asyncLoadQueue.Enqueue(op);
                }
                else
                {
                    throw new Exception($"Can't load ui with Name: {name}");

                }
            }
        }

        public void ClearUselessItems()
        {
            _itemPool.ClearUseless();
        }

        public UIItem GetItem(string path)
        {
            return _itemPool.Get(path);
        }
        public void SetItem(string path, UIItem go)
        {
            _itemPool.Set(path, go);
        }
        public void SetItem(string path, GameObject go)
        {
            _itemPool.Set(path, go);
        }


        /// <summary>
        /// 创建 画布
        /// </summary>
        public void CreateCanvas()
        {
            var canvas = _asset.GetCanvas();
            if (canvas == null)
            {
                var root = new GameObject(name);
                root.AddComponent<RectTransform>();
                this.canvas = root.AddComponent<Canvas>();
                root.AddComponent<CanvasScaler>();
                root.AddComponent<GraphicRaycaster>();
                this.canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
            else
            {
                this.canvas = this.canvas;
                this.canvas.name = name;
            }
            CreateLayers();
        }

        /// <summary>
        /// 设置加载器
        /// </summary>
        /// <param name="asset"></param>
        public void SetAsset(UIAsset asset)
        {
            _asset = asset;
        }
        /// <summary>
        /// 设置ui组管理器
        /// </summary>
        /// <param name="groups"></param>
        public void SetGroups(IGroups groups)
        {
            this._groups = groups;
        }
        public void SetLayerConfig(UILayerConfig config)
        {
            foreach (var item in config.configs)
            {
                if (_layerSettings.ContainsKey(item.name))
                {
                    _layerSettings[item.name] = item;
                }
                else
                {
                    _layerSettings.Add(item.name, item);
                }
            }
        }

        /// <summary>
        /// 展示一个界面
        /// </summary>
        /// <param name="name"></param>
        public void Show(string name)
        {
            var panel = Find(name);
            if (panel == null)
                Load(name, OnShowCallBack);
            else
                OnShowCallBack(panel);
        }
        /// <summary>
        /// 藏一个界面
        /// </summary>
        /// <param name="name"></param>
        public void Hide(string name)
        {
            var panel = Find(name);
            if (panel != null)
            {
                this._groups.OnHide(name);
            }
        }
        /// <summary>
        /// 彻底关闭一个界面
        /// </summary>
        /// <param name="name"></param>
        public void Close(string name)
        {
            var panel = Find(name);

            if (panel != null)
            {
                this._groups.OnClose(name);
                _groups.UnSubscribe(panel);
                panels.Remove(name);
                DestroyPanel(panel);
            }
        }

        public void CloseAll()
        {
            var names = panels.Keys.ToArray();
            for (int i = 0; i < names.Length; i++)
            {
                Close(names[i]);
            }
        }
    }
}
