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
using IFramework.Hotfix.Asset;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class IFrameworkHotfixAssetAssetWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Hotfix.Asset.Asset);
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
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2) && translator.Assignable<IFramework.Hotfix.Asset.Bundle>(L, 3) && translator.Assignable<System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset>>(L, 4) && translator.Assignable<IFramework.Hotfix.Asset.AssetLoadArgs>(L, 5))
				{
					bool _async = LuaAPI.lua_toboolean(L, 2);
					IFramework.Hotfix.Asset.Bundle _bundle = (IFramework.Hotfix.Asset.Bundle)translator.GetObject(L, 3, typeof(IFramework.Hotfix.Asset.Bundle));
					System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset> _dps = (System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset>));
					IFramework.Hotfix.Asset.AssetLoadArgs _loadArgs;translator.Get(L, 5, out _loadArgs);
					
					IFramework.Hotfix.Asset.Asset gen_ret = new IFramework.Hotfix.Asset.Asset(_async, _bundle, _dps, _loadArgs);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Asset.Asset constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAwaiter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Asset.Asset gen_to_be_invoked = (IFramework.Hotfix.Asset.Asset)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        IFramework.IAwaiter<IFramework.Hotfix.Asset.Asset> gen_ret = gen_to_be_invoked.GetAwaiter(  );
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
			
                IFramework.Hotfix.Asset.Asset gen_to_be_invoked = (IFramework.Hotfix.Asset.Asset)translator.FastGetCSObj(L, 1);
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
			
                IFramework.Hotfix.Asset.Asset gen_to_be_invoked = (IFramework.Hotfix.Asset.Asset)translator.FastGetCSObj(L, 1);
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
			
                IFramework.Hotfix.Asset.Asset gen_to_be_invoked = (IFramework.Hotfix.Asset.Asset)translator.FastGetCSObj(L, 1);
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
			
                IFramework.Hotfix.Asset.Asset gen_to_be_invoked = (IFramework.Hotfix.Asset.Asset)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bundle = (IFramework.Hotfix.Asset.Bundle)translator.GetObject(L, 2, typeof(IFramework.Hotfix.Asset.Bundle));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
