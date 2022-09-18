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
    public class IFrameworkNetHttpHttpPayloadWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(IFramework.Net.Http.HttpPayload);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 4, 4);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Token", _g_get_Token);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Header", _g_get_Header);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HttpUri", _g_get_HttpUri);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "stream", _g_get_stream);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Token", _s_set_Token);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Header", _s_set_Header);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "HttpUri", _s_set_HttpUri);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "stream", _s_set_stream);
            
			
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
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					IFramework.Net.Http.HttpPayload gen_ret = new IFramework.Net.Http.HttpPayload();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to IFramework.Net.Http.HttpPayload constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Token(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Token);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Header(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Header);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HttpUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.HttpUri);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_stream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.stream);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Token(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Token = (IFramework.Net.SocketToken)translator.GetObject(L, 2, typeof(IFramework.Net.SocketToken));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Header(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Header = (IFramework.Net.Http.HttpHeader)translator.GetObject(L, 2, typeof(IFramework.Net.Http.HttpHeader));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HttpUri(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.HttpUri = (IFramework.Net.Http.HttpUri)translator.GetObject(L, 2, typeof(IFramework.Net.Http.HttpUri));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_stream(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                IFramework.Net.Http.HttpPayload gen_to_be_invoked = (IFramework.Net.Http.HttpPayload)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.stream = (System.IO.Stream)translator.GetObject(L, 2, typeof(System.IO.Stream));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
