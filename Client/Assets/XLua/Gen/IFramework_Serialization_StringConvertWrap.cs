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
    public class IFrameworkSerializationStringConvertWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Serialization.StringConvert);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 11, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ConvertToString", _m_ConvertToString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryConvert", _m_TryConvert_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetConverter", _m_GetConverter_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFormatter", _m_GetFormatter_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "dot", IFramework.Serialization.StringConvert.dot);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "leftBound", IFramework.Serialization.StringConvert.leftBound);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "rightBound", IFramework.Serialization.StringConvert.rightBound);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "midLeftBound", IFramework.Serialization.StringConvert.midLeftBound);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "midRightBound", IFramework.Serialization.StringConvert.midRightBound);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "colon", IFramework.Serialization.StringConvert.colon);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "IFramework.Serialization.StringConvert does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConvertToString_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object _self = translator.GetObject(L, 1, typeof(object));
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        var gen_ret = IFramework.Serialization.StringConvert.ConvertToString( _self, _type );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryConvert_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _self = LuaAPI.lua_tostring(L, 1);
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    object _obj = translator.GetObject(L, 3, typeof(object));
                    
                        var gen_ret = IFramework.Serialization.StringConvert.TryConvert( _self, _type, ref _obj );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.PushAny(L, _obj);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConverter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        var gen_ret = IFramework.Serialization.StringConvert.GetConverter( _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFormatter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        var gen_ret = IFramework.Serialization.StringConvert.GetFormatter( _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
