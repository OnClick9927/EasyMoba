#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class IFrameworkHotfixLuaXLuaModuleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Hotfix.Lua.XLuaModule);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 2, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Subscribe", _m_Subscribe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnSubscribe", _m_UnSubscribe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NewTable", _m_NewTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddLoader", _m_AddLoader);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadString", _m_LoadString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoString", _m_DoString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTable", _m_GetTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FullGc", _m_FullGc);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "gtable", _g_get_gtable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gcInterval", _g_get_gcInterval);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "gcInterval", _s_set_gcInterval);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 0);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "available", _g_get_available);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					IFramework.Hotfix.Lua.XLuaModule gen_ret = new IFramework.Hotfix.Lua.XLuaModule();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Lua.XLuaModule constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Subscribe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Hotfix.Lua.IXLuaDisposable _dispose = (IFramework.Hotfix.Lua.IXLuaDisposable)translator.GetObject(L, 2, typeof(IFramework.Hotfix.Lua.IXLuaDisposable));
                    
                    gen_to_be_invoked.Subscribe( _dispose );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnSubscribe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Hotfix.Lua.IXLuaDisposable _dispose = (IFramework.Hotfix.Lua.IXLuaDisposable)translator.GetObject(L, 2, typeof(IFramework.Hotfix.Lua.IXLuaDisposable));
                    
                    gen_to_be_invoked.UnSubscribe( _dispose );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        XLua.LuaTable gen_ret = gen_to_be_invoked.NewTable(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddLoader(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    IFramework.Hotfix.Lua.IXLuaLoader _loader = (IFramework.Hotfix.Lua.IXLuaLoader)translator.GetObject(L, 2, typeof(IFramework.Hotfix.Lua.IXLuaLoader));
                    
                    gen_to_be_invoked.AddLoader( _loader );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)) 
                {
                    string _chunk = LuaAPI.lua_tostring(L, 2);
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    XLua.LuaTable _env = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    
                        XLua.LuaFunction gen_ret = gen_to_be_invoked.LoadString( _chunk, _chunkName, _env );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _chunk = LuaAPI.lua_tostring(L, 2);
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    
                        XLua.LuaFunction gen_ret = gen_to_be_invoked.LoadString( _chunk, _chunkName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _chunk = LuaAPI.lua_tostring(L, 2);
                    
                        XLua.LuaFunction gen_ret = gen_to_be_invoked.LoadString( _chunk );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Lua.XLuaModule.LoadString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)) 
                {
                    byte[] _chunk = LuaAPI.lua_tobytes(L, 2);
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    XLua.LuaTable _env = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    
                        object[] gen_ret = gen_to_be_invoked.DoString( _chunk, _chunkName, _env );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _chunk = LuaAPI.lua_tobytes(L, 2);
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    
                        object[] gen_ret = gen_to_be_invoked.DoString( _chunk, _chunkName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _chunk = LuaAPI.lua_tobytes(L, 2);
                    
                        object[] gen_ret = gen_to_be_invoked.DoString( _chunk );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TTABLE)) 
                {
                    string _chunk = LuaAPI.lua_tostring(L, 2);
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    XLua.LuaTable _env = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    
                        object[] gen_ret = gen_to_be_invoked.DoString( _chunk, _chunkName, _env );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _chunk = LuaAPI.lua_tostring(L, 2);
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    
                        object[] gen_ret = gen_to_be_invoked.DoString( _chunk, _chunkName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _chunk = LuaAPI.lua_tostring(L, 2);
                    
                        object[] gen_ret = gen_to_be_invoked.DoString( _chunk );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Lua.XLuaModule.DoString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.TextAsset>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.TextAsset _luaScript = (UnityEngine.TextAsset)translator.GetObject(L, 2, typeof(UnityEngine.TextAsset));
                    string _chunkName = LuaAPI.lua_tostring(L, 3);
                    
                        XLua.LuaTable gen_ret = gen_to_be_invoked.GetTable( _luaScript, _chunkName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.TextAsset>(L, 2)) 
                {
                    UnityEngine.TextAsset _luaScript = (UnityEngine.TextAsset)translator.GetObject(L, 2, typeof(UnityEngine.TextAsset));
                    
                        XLua.LuaTable gen_ret = gen_to_be_invoked.GetTable( _luaScript );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Lua.XLuaModule.GetTable!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FullGc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FullGc(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gtable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.gtable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_available(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, IFramework.Hotfix.Lua.XLuaModule.available);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gcInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.gcInterval);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gcInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Hotfix.Lua.XLuaModule gen_to_be_invoked = (IFramework.Hotfix.Lua.XLuaModule)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gcInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
