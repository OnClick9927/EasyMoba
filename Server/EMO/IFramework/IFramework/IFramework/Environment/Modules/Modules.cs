﻿using System;
using System.Collections.Generic;
using IFramework.Coroutine;
using IFramework.Inject;
using IFramework.Message;
using IFramework.Recorder;
using IFramework.Timer;
using IFramework.Queue;

namespace IFramework
{
    partial class Modules
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public ICoroutineModule coroutine { get { return GetModule<CoroutineModule>(); } }
        public IMessageModule message { get { return GetModule<MessageModule>(); } }
        public IStringMessageModule stringMessage { get { return GetModule<StringMessageModule>(); } }
        public IOperationRecorderModule recoder { get { return GetModule<OperationRecorderModule>(); } }

        public IInjectModule inject { get { return GetModule<InjectModule>(); } }

        public ITimerModule timer { get { return GetModule<TimerModule>(); } }

#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
    /// <summary>
    /// 模块容器
    /// </summary>
    partial class Modules : Unit, IModules, IBelongToEnvironment
    {

        private IEnvironment _env;
        /// <summary>
        /// 环境
        /// </summary>
        public IEnvironment env { get { return _env; } }

        private object _lock = new object();
        private Dictionary<Type, Dictionary<string, Module>> _dic;

        private SimplePriorityQueue<Module, int> _queue;
        private List<UpdateModule> _updateModules;

        /// <summary>
        /// 创建一个模块，创建完了自动绑定
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public Module CreateModule(Type type, string name = Module.defaultName, int priority = 0)
        {
            var mou = Module.CreatInstance(type, name, priority);
            mou.Bind(this);
            return mou;
        }
        /// <summary>
        /// 创建模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public T CreateModule<T>(string name = Module.defaultName, int priority = 0) where T : Module
        {
            return CreateModule(typeof(T), name, priority) as T;
        }


        /// <summary>
        /// 查找模块
        /// </summary>
        /// <param name="type">模块类型</param>
        /// <param name="name">模块名称</param>
        /// <returns></returns>
        public Module FindModule(Type type, string name = Module.defaultName)
        {
            if (string.IsNullOrEmpty(name))
                name = type.Name;
            if (!_dic.ContainsKey(type)) return null;
            if (!_dic[type].ContainsKey(name)) return null;
            var module = _dic[type][name];
            return module;

        }
        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public Module GetModule(Type type, string name = Module.defaultName, int priority = 0)
        {
            var tmp = FindModule(type, name);
            if (tmp == null)
            {
                tmp = CreateModule(type, name, priority);
            }
            return tmp;
        }


        /// <summary>
        /// 查找模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T FindModule<T>(string name = Module.defaultName) where T : Module
        {
            return FindModule(typeof(T), name) as T;
        }
        /// <summary>
        /// 获取模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public T GetModule<T>(string name = Module.defaultName, int priority = 0) where T : Module
        {
            return GetModule(typeof(T), name, priority) as T;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="env"></param>
        public Modules(Environment env)
        {
            this._env = env;
            _dic = new Dictionary<Type, Dictionary<string, Module>>();
            _queue = new SimplePriorityQueue<Module, int>();
            _updateModules = new List<UpdateModule>();
        }
        /// <summary>
        /// 绑定环境
        /// </summary>

        /// <summary>
        /// 释放
        /// </summary>
        protected override void OnDispose()
        {
            // using (new LockWait(ref _lock))
            {
                int count = _queue.count;
                Stack<Module> _modules = new Stack<Module>();
                for (int i = 0; i < count; i++)
                {
                    var item = _queue.Dequeue();

                    _modules.Push(item);

                }

                for (int i = 0; i < count; i++)
                {
                    var item = _modules.Pop();
                    item.Dispose();
                }
                _updateModules.Clear();
                _queue = null;
                _dic.Clear();
                _dic = null;
            }
        }
        internal void Update()
        {
            for (int i = 0; i < _updateModules.Count; i++)
            {
                _updateModules[i].Update();
            }
        }
        private void SyncUpdateList()
        {
            _updateModules.Clear();
            foreach (var item in _queue)
            {
                if (item is UpdateModule)
                {
                    _updateModules.Add(item as UpdateModule);
                }
            }
        }

        internal bool SubscribeModule(Module moudle)
        {
            lock (_lock)
            {
                Type type = moudle.GetType();
                if (!_dic.ContainsKey(type))
                    _dic.Add(type, new Dictionary<string, Module>());
                var list = _dic[type];
                if (list.ContainsKey(moudle.name))
                {
                    Log.E(string.Format("Have Bind Module | Type {0}  Name {1}", type, moudle.name));
                    return false;
                }
                else
                {
                    list.Add(moudle.name, moudle);

                    _queue.Enqueue(moudle, moudle.priority);
                    SyncUpdateList();
                    return true;
                }
            }


        }
        internal bool UnSubscribeBindModule(Module moudle)
        {
            lock (_lock)
            {
                Type type = moudle.GetType();
                if (!_dic.ContainsKey(type))
                {
                    Log.E(string.Format("01,Have Not Bind Module | Type {0}  Name {1}", type, moudle.name));
                    return false;
                }
                else
                {
                    var list = _dic[type];

                    if (!list.ContainsKey(moudle.name))
                    {
                        Log.E(string.Format("02,Have Not Bind Module | Type {0}  Name {1}", type, moudle.name));
                        return false;
                    }
                    else
                    {
                        _dic[type].Remove(moudle.name);
                        if (_queue.Contains(moudle))
                        {
                            _queue.Remove(moudle);
                            SyncUpdateList();
                        }
                        return true;
                    }
                }
            }

        }


    }

}
