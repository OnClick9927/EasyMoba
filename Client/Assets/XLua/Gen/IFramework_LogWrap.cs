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
    public class IFrameworkLogWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Log);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 6, 6);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "L", _m_L_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "W", _m_W_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "E", _m_E_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Exception", _m_Exception_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "loger", _g_get_loger);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "recorder", _g_get_recorder);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enable", _g_get_enable);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enable_L", _g_get_enable_L);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enable_W", _g_get_enable_W);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enable_E", _g_get_enable_E);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "loger", _s_set_loger);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "recorder", _s_set_recorder);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enable", _s_set_enable);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enable_L", _s_set_enable_L);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enable_W", _s_set_enable_W);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enable_E", _s_set_enable_E);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					IFramework.Log gen_ret = new IFramework.Log();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Log constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_L_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object _message = translator.GetObject(L, 1, typeof(object));
                    object[] _paras = translator.GetParams<object>(L, 2);
                    
                    IFramework.Log.L( _message, _paras );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_W_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object _message = translator.GetObject(L, 1, typeof(object));
                    object[] _paras = translator.GetParams<object>(L, 2);
                    
                    IFramework.Log.W( _message, _paras );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_E_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object _message = translator.GetObject(L, 1, typeof(object));
                    object[] _paras = translator.GetParams<object>(L, 2);
                    
                    IFramework.Log.E( _message, _paras );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exception_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Exception _ex = (System.Exception)translator.GetObject(L, 1, typeof(System.Exception));
                    
                    IFramework.Log.Exception( _ex );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_loger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushAny(L, IFramework.Log.loger);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_recorder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushAny(L, IFramework.Log.recorder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enable(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, IFramework.Log.enable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enable_L(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, IFramework.Log.enable_L);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enable_W(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, IFramework.Log.enable_W);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enable_E(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, IFramework.Log.enable_E);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_loger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    IFramework.Log.loger = (IFramework.ILoger)translator.GetObject(L, 1, typeof(IFramework.ILoger));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_recorder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    IFramework.Log.recorder = (IFramework.ILogRecorder)translator.GetObject(L, 1, typeof(IFramework.ILogRecorder));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enable(RealStatePtr L)
        {
		    try {
                
			    IFramework.Log.enable = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enable_L(RealStatePtr L)
        {
		    try {
                
			    IFramework.Log.enable_L = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enable_W(RealStatePtr L)
        {
		    try {
                
			    IFramework.Log.enable_W = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enable_E(RealStatePtr L)
        {
		    try {
                
			    IFramework.Log.enable_E = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
