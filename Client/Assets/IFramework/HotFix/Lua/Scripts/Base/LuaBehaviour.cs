/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.341
 *UnityVersion:   2019.4.22f1c1
 *Date:           2021-08-26
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace IFramework.Hotfix.Lua
{
    [LuaCallCSharp, Serializable]
    public class LuaField
    {
        public string name;
        public UnityEngine.Object obj;
    }
    [LuaCallCSharp]
    public class LuaBehaviour : MonoBehaviour, IXLuaDisposable
    {
        public static string staticPara="";
        public static bool useStatic = false;

        private bool disposed = false;
        private bool initialized = false;
        public object self;
        public string requireParam;

        private static XLuaModule module;

        private string param
        {
            get
            {
                return useStatic ? staticPara : requireParam;
            }
        }
        private LuaTable meta, env, _fields;
        private LuaTable _luaTable;
        private Action<LuaTable> luaStart;
        private Action<LuaTable> luaUpdate;
        private Action<LuaTable> luaOnDestroy;
        private Action<LuaTable> luaOnEnable;
        private Action<LuaTable> luaOnDisable;
        private Action<LuaTable> luaAwake;
        private Action<LuaTable> OnInitialize;

        public List<LuaField> fields = new List<LuaField>();
        public LuaTable luaTable { get { return _luaTable; } } 
        private Dictionary<string, LuaFunction> functions = new Dictionary<string, LuaFunction>();
        protected virtual void GetLuaFunctions()
        {
            _luaTable.Get("Awake", out luaAwake);
            _luaTable.Get("Start", out luaStart);
            _luaTable.Get("Update", out luaUpdate);
            _luaTable.Get("OnDestroy", out luaOnDestroy);
            _luaTable.Get("OnEnable", out luaOnEnable);
            _luaTable.Get("OnDisable", out luaOnDisable);
            _luaTable.Get("OnInitialize", out OnInitialize);
        }
        protected virtual void DisposeLuaFunctions()
        {
            if (disposed) return;
            disposed = true;
            foreach (var item in functions.Values)
            {
                item.Dispose();
            }
            luaAwake = null;
            luaOnDisable = null;
            luaOnEnable = null;
            luaOnDestroy = null;
            luaUpdate = null;
            luaStart = null;
            OnInitialize = null;
            _luaTable?.Dispose();
            env?.Dispose();
            meta?.Dispose();
            _fields?.Dispose();
            self = null;
            module.UnSubscribe(this);
        }
        


        public LuaFunction GetFunction(string name)
        {
            if (_luaTable == null) return null;
            if (!functions.ContainsKey(name))
            {
                var func = _luaTable.Get<LuaFunction>(name);
                if (func != null)
                {
                    functions.Add(name, func);
                }
                else
                {
                    Log.E("No Function With " + name);
                    return null;
                }
            }
            return functions[name];
        }
        public object[] CallFunction(string name, params object[] args)
        {
            var func = GetFunction(name);
            return func.Call(args);
        }
        public object[] CallFunction(string name, object[] args, Type[] returnTypes)
        {
            var func = GetFunction(name);
            return func.Call(args, returnTypes);
        }
        public void Initialize()
        {
            if (initialized) return;
            if (module==null)
                module = Launcher.modules.GetModule<XLuaModule>();
            if (string.IsNullOrEmpty(param)) return;
            if (!XLuaModule.available) return;
            initialized = true;
            module.Subscribe(this);
            env = module.NewTable();
            meta = module.NewTable();
            meta.Set("__index", module.gtable);
            env.SetMetaTable(meta);
            env.Set("target", this);
            _fields = module.NewTable();
            foreach (var item in this.fields)
            {
                _fields.Set(item.name, item.obj);
            }
            env.Set("fields", _fields);
            _luaTable = module.DoString($"local cls = require('{param}') " + " return cls(target,fields) ", name, env)[0] as LuaTable;
            GetLuaFunctions();
            if (OnInitialize!=null)
			{
                OnInitialize(_luaTable);
            }
        }

        protected virtual void Awake()
        {
            Initialize();
            if (luaAwake != null)
            {
                luaAwake(_luaTable);
            }
        }
        protected virtual void Start()
        {
            if (luaStart != null)
            {
                luaStart(_luaTable);
            }
        }
        protected virtual void OnEnable()
        {
            if (luaOnEnable != null)
            {
                luaOnEnable(_luaTable);
            }
        }
        protected virtual void Update()
        {
            if (luaUpdate != null)
            {
                luaUpdate(_luaTable);
            }

        }
        protected virtual void OnDisable()
        {
            if (luaOnDisable != null)
            {
                luaOnDisable(_luaTable);
            }
        }
        protected virtual void OnDestroy()
        {
            if (luaOnDestroy != null)
            {
                luaOnDestroy(_luaTable);
            }
            DisposeLuaFunctions();
        }

        public void LuaDispose()
        {
            DisposeLuaFunctions();
        }
    }
}
