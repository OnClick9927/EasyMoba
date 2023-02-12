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
    public class IFrameworkHotfixAssetAssetsInternalEncryptStreamWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Hotfix.Asset.AssetsInternal.EncryptStream);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Read", _m_Read);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Write", _m_Write);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "EnCode", _m_EnCode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DeCode", _m_DeCode_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 8 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && translator.Assignable<System.IO.FileMode>(L, 4) && translator.Assignable<System.IO.FileAccess>(L, 5) && translator.Assignable<System.IO.FileShare>(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7) && LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8))
				{
					string _bundleName = LuaAPI.lua_tostring(L, 2);
					string _path = LuaAPI.lua_tostring(L, 3);
					System.IO.FileMode _mode;translator.Get(L, 4, out _mode);
					System.IO.FileAccess _access;translator.Get(L, 5, out _access);
					System.IO.FileShare _share;translator.Get(L, 6, out _share);
					int _bufferSize = LuaAPI.xlua_tointeger(L, 7);
					bool _useAsync = LuaAPI.lua_toboolean(L, 8);
					
					var gen_ret = new IFramework.Hotfix.Asset.AssetsInternal.EncryptStream(_bundleName, _path, _mode, _access, _share, _bufferSize, _useAsync);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && translator.Assignable<System.IO.FileMode>(L, 4))
				{
					string _bundleName = LuaAPI.lua_tostring(L, 2);
					string _path = LuaAPI.lua_tostring(L, 3);
					System.IO.FileMode _mode;translator.Get(L, 4, out _mode);
					
					var gen_ret = new IFramework.Hotfix.Asset.AssetsInternal.EncryptStream(_bundleName, _path, _mode);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Hotfix.Asset.AssetsInternal.EncryptStream constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Read(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Asset.AssetsInternal.EncryptStream gen_to_be_invoked = (IFramework.Hotfix.Asset.AssetsInternal.EncryptStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _array = LuaAPI.lua_tobytes(L, 2);
                    int _offset = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                        var gen_ret = gen_to_be_invoked.Read( _array, _offset, _count );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Write(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                IFramework.Hotfix.Asset.AssetsInternal.EncryptStream gen_to_be_invoked = (IFramework.Hotfix.Asset.AssetsInternal.EncryptStream)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _array = LuaAPI.lua_tobytes(L, 2);
                    int _offset = LuaAPI.xlua_tointeger(L, 3);
                    int _count = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.Write( _array, _offset, _count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnCode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 1);
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 2);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.EncryptStream.EnCode( _bundleName, _buffer );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeCode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 1);
                    byte[] _buffer = LuaAPI.lua_tobytes(L, 2);
                    
                        var gen_ret = IFramework.Hotfix.Asset.AssetsInternal.EncryptStream.DeCode( _bundleName, _buffer );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
