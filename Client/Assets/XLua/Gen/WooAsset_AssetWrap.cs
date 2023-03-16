﻿#if USE_UNI_LUA
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
using WooAsset;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class WooAssetAssetWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(WooAsset.Asset);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 3, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAwaiter", _m_GetAwaiter);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "path", _g_get_path);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "progress", _g_get_progress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bundle", _g_get_bundle);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "bundle", _s_set_bundle);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 4 && translator.Assignable<WooAsset.Bundle>(L, 2) && translator.Assignable<System.Collections.Generic.List<WooAsset.Asset>>(L, 3) && translator.Assignable<WooAsset.AssetLoadArgs>(L, 4))
				{
					WooAsset.Bundle _bundle = (WooAsset.Bundle)translator.GetObject(L, 2, typeof(WooAsset.Bundle));
					System.Collections.Generic.List<WooAsset.Asset> _dps = (System.Collections.Generic.List<WooAsset.Asset>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<WooAsset.Asset>));
					WooAsset.AssetLoadArgs _loadArgs;translator.Get(L, 4, out _loadArgs);
					
					var gen_ret = new WooAsset.Asset(_bundle, _dps, _loadArgs);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to WooAsset.Asset constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAwaiter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                WooAsset.Asset gen_to_be_invoked = (WooAsset.Asset)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetAwaiter(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_path(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WooAsset.Asset gen_to_be_invoked = (WooAsset.Asset)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.path);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_progress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WooAsset.Asset gen_to_be_invoked = (WooAsset.Asset)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.progress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bundle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WooAsset.Asset gen_to_be_invoked = (WooAsset.Asset)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bundle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bundle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                WooAsset.Asset gen_to_be_invoked = (WooAsset.Asset)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bundle = (WooAsset.Bundle)translator.GetObject(L, 2, typeof(WooAsset.Bundle));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
