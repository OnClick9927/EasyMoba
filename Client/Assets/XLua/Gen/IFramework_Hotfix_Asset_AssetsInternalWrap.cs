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
    public class IFrameworkHotfixAssetAssetsInternalWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Hotfix.Asset.AssetsInternal);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 21, 3, 2);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAssetListen", _m_SetAssetListen_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAllAssetPaths", _m_GetAllAssetPaths_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTagAssetPaths", _m_GetTagAssetPaths_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAssetsSetting", _m_SetAssetsSetting_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFileCheckType", _m_GetFileCheckType_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetUrlFromBundleName", _m_GetUrlFromBundleName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetVersionUrl", _m_GetVersionUrl_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetEncrypt", _m_GetEncrypt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAutoUnloadBundle", _m_GetAutoUnloadBundle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBundleLocalPath", _m_GetBundleLocalPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLocalBundles", _m_GetLocalBundles_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnloadBundles", _m_UnloadBundles_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadAssetAsync", _m_LoadAssetAsync_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadSceneAssetAsync", _m_LoadSceneAssetAsync_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Release", _m_Release_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LogError", _m_LogError_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMd5", _m_GetMd5_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFileMD5", _m_GetFileMD5_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CopyDLCFromSteam", _m_CopyDLCFromSteam_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CopyDirectory", _m_CopyDirectory_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isNormalMode", _g_get_isNormalMode);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "mode", _g_get_mode);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "localSaveDir", _g_get_localSaveDir);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "mode", _s_set_mode);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "localSaveDir", _s_set_localSaveDir);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new IFramework.Hotfix.Asset.AssetsInternal();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Asset.AssetsInternal constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAssetListen_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Hotfix.Asset.AssetsInternal.IAssetLife<IFramework.Hotfix.Asset.Asset> _asset = (IFramework.Hotfix.Asset.AssetsInternal.IAssetLife<IFramework.Hotfix.Asset.Asset>)translator.GetObject(L, 1, typeof(IFramework.Hotfix.Asset.AssetsInternal.IAssetLife<IFramework.Hotfix.Asset.Asset>));
                    IFramework.Hotfix.Asset.AssetsInternal.IAssetLife<IFramework.Hotfix.Asset.Bundle> _bundle = (IFramework.Hotfix.Asset.AssetsInternal.IAssetLife<IFramework.Hotfix.Asset.Bundle>)translator.GetObject(L, 2, typeof(IFramework.Hotfix.Asset.AssetsInternal.IAssetLife<IFramework.Hotfix.Asset.Bundle>));
                    
                    IFramework.Hotfix.Asset.AssetsInternal.SetAssetListen( _asset, _bundle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllAssetPaths_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetAllAssetPaths(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTagAssetPaths_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _tag = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetTagAssetPaths( _tag );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAssetsSetting_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Hotfix.Asset.AssetsSetting _setting = (IFramework.Hotfix.Asset.AssetsSetting)translator.GetObject(L, 1, typeof(IFramework.Hotfix.Asset.AssetsSetting));
                    
                    IFramework.Hotfix.Asset.AssetsInternal.SetAssetsSetting( _setting );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileCheckType_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetFileCheckType(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUrlFromBundleName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetUrlFromBundleName( _bundleName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVersionUrl_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetVersionUrl(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEncrypt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetEncrypt(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAutoUnloadBundle_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetAutoUnloadBundle(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBundleLocalPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetBundleLocalPath( _bundleName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalBundles_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetLocalBundles(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnloadBundles_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    IFramework.Hotfix.Asset.AssetsInternal.UnloadBundles(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAssetAsync_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.LoadAssetAsync( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSceneAssetAsync_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.LoadSceneAssetAsync( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Release_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    IFramework.Hotfix.Asset.Asset _asset = (IFramework.Hotfix.Asset.Asset)translator.GetObject(L, 1, typeof(IFramework.Hotfix.Asset.Asset));
                    
                    IFramework.Hotfix.Asset.AssetsInternal.Release( _asset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogError_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _err = LuaAPI.lua_tostring(L, 1);
                    
                    IFramework.Hotfix.Asset.AssetsInternal.LogError( _err );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMd5_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetMd5( _str );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileMD5_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.GetFileMD5( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyDLCFromSteam_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.CopyDLCFromSteam(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyDirectory_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _srcPath = LuaAPI.lua_tostring(L, 1);
                    string _destPath = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.CopyDirectory( _srcPath, _destPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isNormalMode(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, IFramework.Hotfix.Asset.AssetsInternal.isNormalMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushAny(L, IFramework.Hotfix.Asset.AssetsInternal.mode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localSaveDir(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, IFramework.Hotfix.Asset.AssetsInternal.localSaveDir);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    IFramework.Hotfix.Asset.AssetsInternal.mode = (IFramework.Hotfix.Asset.IAssetMode)translator.GetObject(L, 1, typeof(IFramework.Hotfix.Asset.IAssetMode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localSaveDir(RealStatePtr L)
        {
		    try {
                
			    IFramework.Hotfix.Asset.AssetsInternal.localSaveDir = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
