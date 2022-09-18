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
    public class IFrameworkHotfixAssetSceneAssetWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Hotfix.Asset.SceneAsset);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 2, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadScene", _m_LoadScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadSceneAsync", _m_LoadSceneAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAwaiter", _m_GetAwaiter);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "path", _g_get_path);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "progress", _g_get_progress);
            
			
			
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
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2) && translator.Assignable<IFramework.Hotfix.Asset.Bundle>(L, 3) && translator.Assignable<System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset>>(L, 4) && translator.Assignable<IFramework.Hotfix.Asset.SceneAssetLoadArgs>(L, 5))
				{
					bool _async = LuaAPI.lua_toboolean(L, 2);
					IFramework.Hotfix.Asset.Bundle _bundle = (IFramework.Hotfix.Asset.Bundle)translator.GetObject(L, 3, typeof(IFramework.Hotfix.Asset.Bundle));
					System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset> _dps = (System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<IFramework.Hotfix.Asset.Asset>));
					IFramework.Hotfix.Asset.SceneAssetLoadArgs _loadArgs;translator.Get(L, 5, out _loadArgs);
					
					IFramework.Hotfix.Asset.SceneAsset gen_ret = new IFramework.Hotfix.Asset.SceneAsset(_async, _bundle, _dps, _loadArgs);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Asset.SceneAsset constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Asset.SceneAsset gen_to_be_invoked = (IFramework.Hotfix.Asset.SceneAsset)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.SceneManagement.LoadSceneMode>(L, 2)) 
                {
                    UnityEngine.SceneManagement.LoadSceneMode _mode;translator.Get(L, 2, out _mode);
                    
                    gen_to_be_invoked.LoadScene( _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.SceneManagement.LoadSceneParameters>(L, 2)) 
                {
                    UnityEngine.SceneManagement.LoadSceneParameters _parameters;translator.Get(L, 2, out _parameters);
                    
                        UnityEngine.SceneManagement.Scene gen_ret = gen_to_be_invoked.LoadScene( _parameters );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Asset.SceneAsset.LoadScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSceneAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Asset.SceneAsset gen_to_be_invoked = (IFramework.Hotfix.Asset.SceneAsset)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.SceneManagement.LoadSceneParameters>(L, 2)) 
                {
                    UnityEngine.SceneManagement.LoadSceneParameters _parameters;translator.Get(L, 2, out _parameters);
                    
                        UnityEngine.AsyncOperation gen_ret = gen_to_be_invoked.LoadSceneAsync( _parameters );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.SceneManagement.LoadSceneMode>(L, 2)) 
                {
                    UnityEngine.SceneManagement.LoadSceneMode _mode;translator.Get(L, 2, out _mode);
                    
                        UnityEngine.AsyncOperation gen_ret = gen_to_be_invoked.LoadSceneAsync( _mode );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Asset.SceneAsset.LoadSceneAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAwaiter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Asset.SceneAsset gen_to_be_invoked = (IFramework.Hotfix.Asset.SceneAsset)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        IFramework.IAwaiter<IFramework.Hotfix.Asset.SceneAsset> gen_ret = gen_to_be_invoked.GetAwaiter(  );
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
			
                IFramework.Hotfix.Asset.SceneAsset gen_to_be_invoked = (IFramework.Hotfix.Asset.SceneAsset)translator.FastGetCSObj(L, 1);
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
			
                IFramework.Hotfix.Asset.SceneAsset gen_to_be_invoked = (IFramework.Hotfix.Asset.SceneAsset)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.progress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
